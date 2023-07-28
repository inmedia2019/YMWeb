using System;
using System.Configuration;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NUglify.Helpers;
using YMWeb.Code;
using YMWeb.Domain.SystemOrganize;
using YMWeb.Domain.SystemSecurity;
using YMWeb.Service;
using YMWeb.Service.SystemOrganize;
using YMWeb.Service.SystemSecurity;

namespace YMWeb.WebApi.Controllers
{
    /// <summary>
    /// 用户接口
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        ////自动注入服务
        public FilterIPService _filterIPService { get; set; }
        //public UserService _userService { get; set; }
        //public LogService _logService { get; set; }
        //public SystemSetService _setService { get; set; }

        //#region 提交数据
        ///// <summary>
        ///// 用户登录
        ///// </summary>
        ///// <param name="userName">用户</param>
        ///// <param name="password">密码</param>
        ///// <param name="localurl">域名</param>
        ///// <returns></returns>
        //[HttpPost]
        //public async Task<ActionResult> Login([FromQuery] string userName, [FromQuery] string password, [FromQuery] string localurl)
        //{
        //    var apitoken = Utils.GuId();
        //    if (!string.IsNullOrEmpty(OperatorProvider.Provider.GetToken()))
        //    {
        //        apitoken = OperatorProvider.Provider.GetToken();
        //    }

        //    LogEntity logEntity = new LogEntity();
        //    logEntity.F_ModuleName = "用户Api";
        //    logEntity.F_Type = DbLogType.Login.ToString();
        //    try
        //    {
        //        if (!await CheckIP())
        //        {
        //            throw new Exception("IP受限");
        //        }
        //        UserEntity userEntity = await _userService.CheckLogin(userName, Md5.md5(password, 32).ToLower(), localurl);
        //        OperatorModel operatorModel = new OperatorModel();
        //        operatorModel.UserId = userEntity.F_Id;
        //        operatorModel.UserCode = userEntity.F_Account;
        //        operatorModel.UserName = userEntity.F_RealName;
        //        operatorModel.CompanyId = userEntity.F_OrganizeId;
        //        operatorModel.DepartmentId = userEntity.F_DepartmentId;
        //        operatorModel.RoleId = userEntity.F_RoleId;
        //        operatorModel.LoginIPAddress = Request.HttpContext.Connection.LocalIpAddress.MapToIPv4().ToString(); 
        //        operatorModel.LoginIPAddressName = "本地局域网";//Net.GetLocation(operatorModel.LoginIPAddress);
        //        operatorModel.LoginTime = DateTime.Now;
        //        operatorModel.DdUserId = userEntity.F_DingTalkUserId;
        //        operatorModel.WxOpenId = userEntity.F_WxOpenId;
        //        operatorModel.IsAdmin = userEntity.F_IsAdmin.Value;
        //        operatorModel.IsBoss = userEntity.F_IsBoss.Value;
        //        operatorModel.IsLeaderInDepts = userEntity.F_IsLeaderInDepts.Value;
        //        operatorModel.IsSenior = userEntity.F_IsSenior.Value;
        //        SystemSetEntity setEntity = await _setService.GetForm(userEntity.F_OrganizeId);
        //        operatorModel.DbString = setEntity.F_DbString;
        //        operatorModel.DBProvider = setEntity.F_DBProvider;
        //        if (userEntity.F_Account == "admin")
        //        {
        //            operatorModel.IsSystem = true;
        //        }
        //        else
        //        {
        //            operatorModel.IsSystem = false;
        //        }
        //        await OperatorProvider.Provider.AddLoginUser(operatorModel, apitoken, "api_",false);
        //        logEntity.F_Account = userEntity.F_Account;
        //        logEntity.F_NickName = userEntity.F_RealName;
        //        logEntity.F_Result = true;
        //        logEntity.F_Description = "登录成功";
        //        await _logService.WriteDbLog(logEntity);
        //        return Content(new AjaxResult<string> { state = ResultType.success.ToString(), message = "登录成功。",data= apitoken }.ToJson());
        //    }
        //    catch (Exception ex)
        //    {
        //        logEntity.F_Account = userName;
        //        logEntity.F_NickName = userName;
        //        logEntity.F_Result = false;
        //        logEntity.F_Description = "登录失败，" + ex.Message;
        //        await _logService.WriteDbLog(logEntity);
        //        return Content(new AjaxResult<string> { state = ResultType.error.ToString(), message = ex.Message,data= apitoken }.ToJson());
        //    }
        //}
        private async Task<bool> CheckIP()
        {
            string ip = Request.HttpContext.Connection.LocalIpAddress.MapToIPv4().ToString();
            return await _filterIPService.CheckIP(ip);
        }

        //  private const string LoginProviderKey = "LoginProvider";
        //  private const string Provider_WeChat = "WeChat";
        //  private readonly ILogger _logger;
        //  private readonly IHttpContextAccessor _contextAccessor;
 
        // public UserController(ILogger<UserController> logger,
        //     IHttpContextAccessor contextAccessor)
        // {
        //     _logger = logger;
        //     _contextAccessor = contextAccessor;
        //}



        // /// <summary>
        // /// 微信登录
        // /// </summary>
        // /// <param name="redirectUrl">授权成功后的跳转地址</param>
        // /// <returns></returns>
        // [HttpGet("LoginByWeChat")]
        // public IActionResult LoginByWeChat(string redirectUrl)
        // {
        //     var request = _contextAccessor.HttpContext.Request;
        //     var url = $"{request.Scheme}://{request.Host}{request.PathBase}{request.Path}Callback?provider={Provider_WeChat}&redirectUrl={redirectUrl}";
        //     var properties = new AuthenticationProperties { RedirectUri = url };
        //     properties.Items[LoginProviderKey] = Provider_WeChat;
        //     return Challenge(properties, Provider_WeChat);
        // }

        ///// <summary>
        ///// 微信授权成功后自动回调的地址
        ///// </summary>
        ///// <param name="provider"></param>
        ///// <param name="redirectUrl">授权成功后的跳转地址</param>
        ///// <returns></returns>
        //[HttpGet("LoginByWeChatCallback")]
        //public async Task<IActionResult> LoginByWeChatCallbackAsync(string provider = null, string redirectUrl = "")
        //{
        //    var authenticateResult = await _contextAccessor.HttpContext.AuthenticateAsync(provider);
            
        //    if (!authenticateResult.Succeeded) return Redirect(redirectUrl);
        //    var openIdClaim = authenticateResult.Principal.FindFirst(ClaimTypes.NameIdentifier);
        //    if (openIdClaim == null || openIdClaim.Value.IsNullOrWhiteSpace())
        //        return Redirect(redirectUrl);
        //    //TODO 记录授权成功后的微信信息 
        //    var city = authenticateResult.Principal.FindFirst("urn:wechat:city")?.Value;
        //    var country = authenticateResult.Principal.FindFirst(ClaimTypes.Country)?.Value;
        //    var headimgurl = authenticateResult.Principal.FindFirst(ClaimTypes.Uri)?.Value;
        //    var nickName = authenticateResult.Principal.FindFirst(ClaimTypes.Name)?.Value;
        //    var openId = authenticateResult.Principal.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        //    var privilege = authenticateResult.Principal.FindFirst("urn:wechat:privilege")?.Value;
        //    var province = authenticateResult.Principal.FindFirst("urn:wechat:province")?.Value;
        //    var sexClaim = authenticateResult.Principal.FindFirst(ClaimTypes.Gender);
        //    int sex = 0;
        //    if (sexClaim != null && !sexClaim.Value.IsNullOrWhiteSpace())
        //        sex = int.Parse(sexClaim.Value);
        //    var unionId = authenticateResult.Principal.FindFirst("urn:wechat:unionid")?.Value;
        //    _logger.LogDebug($"WeChat Info=> openId: {openId},nickName: {nickName}");
        //    return Redirect($"{redirectUrl}?openId={openIdClaim.Value}");
        //}

        ///// <summary>
        ///// 用户退出登录
        ///// </summary>
        ///// <returns></returns>
        //[HttpPost]
        //[AuthorizeFilter]
        //public async Task<ActionResult> LoginOff()
        //{
        //    await _logService.WriteDbLog(new LogEntity
        //    {
        //        F_ModuleName = "用户Api",
        //        F_Type = DbLogType.Exit.ToString(),
        //        F_Account = _userService.currentuser.UserCode,
        //        F_NickName = _userService.currentuser.UserName,
        //        F_Result = true,
        //        F_Description = "安全退出系统",
        //    });
        //    await OperatorProvider.Provider.EmptyCurrent("api_");
        //    return Content(new AjaxResult { state = ResultType.success.ToString() }.ToJson());
        //}
        //#endregion
    }
}
