﻿using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using YMWeb.Code;
using Microsoft.AspNetCore.Http;

namespace YMWeb.Web
{
    /// <summary>
    /// 全局异常过滤器
    /// </summary>
    public class GlobalExceptionFilter : IExceptionFilter, IAsyncExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            LogHelper.WriteWithTime(context);
            if (context.HttpContext.Request.IsAjaxRequest())
            {
                AjaxResult obj = new AjaxResult();
                obj.state = ResultType.error.ToString();
                obj.message = context.Exception.GetOriginalException().Message;
                if (string.IsNullOrEmpty(obj.message))
                {
                    obj.message = "抱歉，系统错误，请联系管理员！";
                }
                context.Result = new JsonResult(obj);
                context.ExceptionHandled = true;
            }
            else
            {
                //context.HttpContext.Response.WriteAsync("<script>top.location.href ='" + context.HttpContext.Request.PathBase + "/Home/Error?msg=500" + "';if(document.all) window.event.returnValue = false;</script>");
                context.Result = new RedirectResult(context.HttpContext.Request.PathBase + GlobalContext.SystemConfig.VirtualDirectory + "/Home/Error?msg=500");
                context.ExceptionHandled = true;
            }
        }

        public Task OnExceptionAsync(ExceptionContext context)
        {
            OnException(context);
            return Task.CompletedTask;
        }
    }
}