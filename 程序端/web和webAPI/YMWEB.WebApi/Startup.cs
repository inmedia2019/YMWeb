using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Autofac;
using CSRedis;
using Microsoft.AspNetCore.Authentication.WeChat;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;
using Quartz;
using Quartz.Impl;
using Quartz.Spi;
using Senparc.CO2NET;
using Senparc.Weixin.Entities;
using Senparc.Weixin.RegisterServices;
using YMWeb.Code;
using YMWeb.Code.Model;
using YMWeb.DataBase;
using YMWeb.Domain.DictionaryDataBase;
using YMWeb.Service;
using YMWeb.Service.AutoJob;

namespace YMWeb.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            GlobalContext.LogWhenStart(env);
            GlobalContext.HostingEnvironment = env;

            Dictionary<string, UseractioninfoEntity> list = new Dictionary<string, UseractioninfoEntity>();

            MemoryCacheHelper.Set("userVideoTime", list);
 
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy
                    (name: "myCors",
                        builde =>
                        {
                            builde.WithOrigins("*", "*", "*")
                            .AllowAnyOrigin()
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                        }
                    );
            });

            services.AddMemoryCache()//使用本地缓存必须添加
            .AddSenparcWeixinServices(Configuration);//Senparc.Weixin 注册（必须）



            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            //services.AddAuthentication()
            //    .AddWeChat(wechatOptions =>
            //    {
            //        wechatOptions.AppId = Configuration["Authentication:WeChat:AppId"];
            //        wechatOptions.AppSecret = Configuration["Authentication:WeChat:AppSecret"];
            //        wechatOptions.UseCachedStateDataFormat = true;
            //    });

            services.AddSwaggerGen(config =>
            {
                config.SwaggerDoc("v1", new OpenApiInfo { Title = "YMWeb Api", Version = "v1" });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                config.IncludeXmlComments(xmlPath, true); //添加控制器层注释（true表示显示控制器注释）                
            });

            //缓存选择
            if (Configuration.GetSection("SystemConfig:CacheProvider").Value != Define.CACHEPROVIDER_REDIS)
            {
                services.AddMemoryCache();
            }
            else
            {
                //redis 注入服务
                string redisConnectiong = Configuration.GetSection("SystemConfig:RedisConnectionString").Value;
                // 多客户端 1、基础 2、操作日志
                var redisDB1 = new CSRedisClient(redisConnectiong + ",defaultDatabase=" + 0);
                BaseHelper.Initialization(redisDB1);
                var redisDB2 = new CSRedisClient(redisConnectiong + ",defaultDatabase=" + 1);
                HandleLogHelper.Initialization(redisDB2);
                services.AddSingleton(redisDB1);
                services.AddSingleton(redisDB2);
            }
            //注入数据库连接
            services.AddScoped<Chloe.IDbContext>((serviceProvider) =>
            {
                return DBContexHelper.Contex();
            });

            #region 注入 Quartz调度类
            services.AddSingleton<JobCenter>();
            services.AddSingleton<JobExecute>();
            //注册ISchedulerFactory的实例。
            services.AddSingleton<ISchedulerFactory, StdSchedulerFactory>();
            services.AddSingleton<IJobFactory, IOCJobFactory>();
            #endregion
            //注入SignalR实时通讯，默认用json传输
            services.AddSignalR(options =>
            {
                //客户端发保持连接请求到服务端最长间隔，默认30秒，改成4分钟，网页需跟着设置connection.keepAliveIntervalInMilliseconds = 12e4;即2分钟
                options.ClientTimeoutInterval = TimeSpan.FromMinutes(4);
                //服务端发保持连接请求到客户端间隔，默认15秒，改成2分钟，网页需跟着设置connection.serverTimeoutInMilliseconds = 24e4;即4分钟
                options.KeepAliveInterval = TimeSpan.FromMinutes(2);
            });

            //代替HttpContext.Current
            services.AddHttpContextAccessor();
            services.AddOptions();
            //跨域
            services.AddCors();
            services.AddControllers(options =>
            {
                options.ModelMetadataDetailsProviders.Add(new ModelBindingMetadataProvider());
            }).AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ContractResolver = new DefaultContractResolver();
            });
          
            services.AddControllers().AddControllersAsServices();
            services.AddDataProtection().PersistKeysToFileSystem(new DirectoryInfo(GlobalContext.HostingEnvironment.ContentRootPath + Path.DirectorySeparatorChar + "DataProtection"));
            GlobalContext.SystemConfig = Configuration.GetSection("SystemConfig").Get<SystemConfig>();
            GlobalContext.Services = services;
            GlobalContext.Configuration = Configuration;
        }
        public void ConfigureContainer(ContainerBuilder builder)
        {
            var assemblys = Assembly.Load("YMWeb.Service");//Service是继承接口的实现方法类库名称
            var baseType = typeof(IDenpendency);//IDenpendency 是一个接口（所有要实现依赖注入的借口都要继承该接口）
            builder.RegisterAssemblyTypes(assemblys).Where(m => baseType.IsAssignableFrom(m) && m != baseType)
              .InstancePerLifetimeScope()//生命周期
              .PropertiesAutowired();//属性注入
            //ControllerBase中使用属性注入
            var controllerBaseType = typeof(ControllerBase);
            builder.RegisterAssemblyTypes(typeof(Program).Assembly)
            .Where(t => controllerBaseType.IsAssignableFrom(t) && t != controllerBaseType)
            .PropertiesAutowired();
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IOptions<SenparcSetting> senparcSetting, IOptions<SenparcWeixinSetting> senparcWeixinSetting)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseDeveloperExceptionPage();
            }

            
        

 


            app.UseStaticFiles(new StaticFileOptions
            {
                OnPrepareResponse = GlobalContext.SetCacheControl
            });
            app.UseMiddleware(typeof(GlobalExceptionMiddleware));

            app.UseCors("myCors");
            //app.UseCors(builder =>
            //{
            //    builder.WithOrigins(GlobalContext.SystemConfig.AllowCorsSite.Split(',')).AllowAnyHeader().AllowAnyMethod().AllowCredentials();
            //});
            app.UseSwagger(c =>
            {
                c.RouteTemplate = "api-doc/{documentName}/swagger.json";
            });
            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = "api-doc";
                c.SwaggerEndpoint("v1/swagger.json", "YMWeb Api v1");
            });
            app.UseRouting();
            //跨域设置
            app.UseCors(builder => builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller=ApiHome}/{action=Index}/{id?}");
            });
            GlobalContext.ServiceProvider = app.ApplicationServices;
            //获取前面注入的Quartz调度类
            var quartz = app.ApplicationServices.GetRequiredService<JobCenter>();
            quartz.Start();
            //注册 Senparc.Weixin 及基础库
            //app.UseSenparcGlobal(env, senparcSetting.Value, _ => { })
            //    .UseSenparcWeixin(senparcWeixinSetting.Value,
            //        weixinRegister => weixinRegister.RegisterMpAccount(senparcWeixinSetting.Value));
        }
    }
}
