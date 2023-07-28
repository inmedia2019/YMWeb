﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using YMWeb.Service.SystemManage;
using YMWeb.Code;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using System.Security.Policy;
using Serenity.Web;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using YMWeb.Service.SystemOrganize;
using Chloe;
using YMWeb.DataBase;
/// <summary>
/// 权限验证
/// </summary>
namespace YMWeb.Web
{
    public class HandlerAuthorizeAttribute : ActionFilterAttribute
    {
        private readonly RoleAuthorizeService _service;
        public HandlerAuthorizeAttribute(RoleAuthorizeService service)
        {
            _service = service;
        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (OperatorProvider.Provider.GetCurrent() != null&& OperatorProvider.Provider.GetCurrent().IsSystem)
            {
                return;
            }
            if (!ActionAuthorize(filterContext))
            {
                OperatorProvider.Provider.EmptyCurrent("pc_");
                //filterContext.HttpContext.Response.WriteAsync("<script>top.location.href ='" + filterContext.HttpContext.Request.PathBase + "/Home/Error?msg=403" + "';if(document.all) window.event.returnValue = false;</script>");
                filterContext.Result = new RedirectResult(filterContext.HttpContext.Request.PathBase  + "/Home/Error?msg=403");
                return;
            }
        }
        private bool ActionAuthorize(ActionExecutingContext filterContext)
        {
            try
            {
                OperatorResult result=OperatorProvider.Provider.IsOnLine("pc_").Result;
                if (result.stateCode<=0)
                {

                    return false;
                }
                var roleId = result.userInfo.RoleId;
                var action = GlobalContext.ServiceProvider?.GetService<IHttpContextAccessor>().HttpContext.Request.Path;
                action = GlobalContext.SystemConfig.VirtualDirectory + action.ToString();
                return _service.ActionValidate(roleId, action).Result;
            }
            catch (System.Exception)
            {

                return false;
            }

        }
    }
}