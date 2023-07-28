using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Senparc.Weixin;
using Senparc.Weixin.MP.AdvancedAPIs;
using Senparc.Weixin.MP.AdvancedAPIs.OAuth;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using YMWeb.Code;
using YMWeb.Domain.DictionaryDataBase;
using YMWeb.Service.DictionaryDataBase;
using YMWeb.WebApi.Models;
using YMWeb.WebApi.Tools;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace YMWeb.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WechatController : ControllerBase
    {
        //这两个已经在web.config里面写入，所以直接利用ConfiurationManager类下的AppSetting方法获取
        public static readonly string appID = "XXX";
        public static readonly string appsecret = "XXX";

        public MemberinfoService _memberinfoService { get; set; }

        // GET api/values
        [HttpGet]
        public async Task<ReturnType<OAuthUserInfo>> GetUserInfo(string code)
        {

            Dictionary<string, OAuthUserInfo> keyValues = new Dictionary<string, OAuthUserInfo>();
            OAuthAccessTokenResult oAuthAccessTokenResult = new OAuthAccessTokenResult();
            //获取AccessToken
            oAuthAccessTokenResult = OAuthApi.GetAccessToken(appID, appsecret, code);
            if (oAuthAccessTokenResult.errcode != ReturnCode.请求成功)
            {
                //请求失败后的处理
            }
            //获取UserInfo
            OAuthUserInfo oAuthUserInfo = OAuthApi.GetUserInfo(oAuthAccessTokenResult.access_token, oAuthAccessTokenResult.openid);
           
            //keyValues.Add("Accesstoken", oAuthUserInfo);
            //返回Json对象
            return Util.getReturnObjectInfo(oAuthUserInfo, "true", true);

        }



        [HttpGet("GetWeixinSign")]
        public async Task<ReturnType<ReturnWeixinInfo>> GetWeixinSign(string url)
        {

            ReturnWeixinInfo rinfo = new ReturnWeixinInfo();
            if (!MemoryCacheHelper.Exists("WexinInfo"))
            {
                WeixinInfo winfo = new WeixinInfo();
                string ticket = "";
                string token = WeixinInfo.ModifyToken(out ticket);
                winfo.createDate = DateTime.Now;
                winfo.ticket = ticket;
                winfo.token = token;
                TimeSpan ts = DateTime.Now.AddDays(365) - DateTime.Now;
                MemoryCacheHelper.Set("WexinInfo", winfo, ts, true);
            }
            else
            {
                WeixinInfo winfo = (WeixinInfo)MemoryCacheHelper.Get<WeixinInfo>("WexinInfo");
                TimeSpan ts = DateTime.Now - winfo.createDate;
                if (ts.TotalMinutes > 15)
                {
                    string ticket = "";
                    string token = WeixinInfo.ModifyToken(out ticket);
                    winfo.createDate = DateTime.Now;
                    winfo.ticket = ticket;
                    winfo.token = token;
                    TimeSpan ts1 = DateTime.Now.AddDays(365) - DateTime.Now;
                    MemoryCacheHelper.Set("WexinInfo", winfo, ts1, true);
                }

            }
            string str1 = "";
            WeixinInfo NEWInfo = (WeixinInfo)MemoryCacheHelper.Get<WeixinInfo>("WexinInfo");
            rinfo.appid = appID;
            rinfo.nonceStr = WeixinInfo.GenerateRandomCode(16);
            rinfo.timestamp = WeixinInfo.UnixStamp().ToString();
            rinfo.signature= WeixinInfo.GetSignature(NEWInfo.ticket, rinfo.nonceStr, rinfo.timestamp, url, out str1);
            rinfo.token = NEWInfo.token;
            return Util.getReturnObjectInfo(rinfo, "true", true);

        }


        [HttpGet("GetCacheInfo")]
        public async Task<ReturnType<string>> GetCacheInfo(string url)
        {
            string str = "";
            Dictionary<string, UseractioninfoEntity> list = MemoryCacheHelper.Get<Dictionary<string, UseractioninfoEntity>>("userVideoTime");
            foreach (var item in list)
            {
                UseractioninfoEntity info = (UseractioninfoEntity)item.Value;
                if (Convert.ToInt32(info.vContent) > 0)
                {
                    str += info.mid + info.tid.ToString();
                }

            }
            return Util.getReturnObjectInfo(str, "true", true);

        }



        // GET: WeChat
        /// <summary>
        /// 授权
        /// </summary>
        /// <param name="js_code">jsCode</param>
        /// <returns></returns>
        [HttpGet("Authorize")]
        public async Task<ReturnType<jscode2sessionModel>> Authorize(string js_code)
        {


            string url = string.Format("https://api.weixin.qq.com/sns/jscode2session?appid={0}&secret={1}&js_code={2}&grant_type=authorization_code", appID, appsecret, js_code);
            string result = HttpHelper.HttpGet(url);

            jscode2sessionModel model = JsonConvert.DeserializeObject<jscode2sessionModel>(result);// HttpResponseExtension.FromJson<jscode2sessionModel>(result);

            if (model.errcode == 0)
            {
                
                MemberinfoEntity minfo = await _memberinfoService.GetUserInfoByOpenId(model.openid);
                if (minfo == null)
                {
                    minfo = new MemberinfoEntity();
                    minfo.createDate = DateTime.Now;
                    minfo.department = "";
                    minfo.descript = "";
                    minfo.Id = Guid.NewGuid().ToString();
                    minfo.IsAgreeActionCollect = true;
                    minfo.IsAgreeAgreement = true;
                    minfo.IsSgin = 0;
                    minfo.jobName = "";
                    minfo.JobTitle = "";
                    minfo.mediaName = "";
                    minfo.moreCol = "";
                    minfo.moreCol1 = "";
                    minfo.openId = model.openid;
                    minfo.phone = "";
                    minfo.Sex = 0;
                    minfo.state = 0;
                    minfo.trueName = "";
                    minfo.unionId = model.unionid;
                    minfo.userScore = 0;
                    model.mid = await _memberinfoService.SubmitForm(minfo, "");

                }
                else
                    model.mid = minfo.Id;

                return Util.getReturnObject(model);
            }
            else
            {
                return Util.getReturnObject<jscode2sessionModel>(null, "系统异常请稍后再试");
            }

        }

    }

    public class jscode2sessionModel
    {
        public string openid { get; set; }
        public string session_key { get; set; }
        public string unionid { get; set; }
        public int errcode { get; set; }
        public string errmsg { get; set; }
        public string decryptstr { get; set; }
        public string mid { get; set; }

    }



    public class WeixinInfo
    {
        public static readonly string appID = "XXX";
        public static readonly string appsecret = "XXXX";
        public DateTime createDate { get; set; }
        public string token { get; set; }
        public string ticket { get; set; }

        public static string ModifyToken(out string ticket)
        {
           // { "access_token":"57_5QT54O4ys7-wT-UU_BgbKpePvOtx83_RwTSZiZ0QYdP8VtgUyuqGvjIFbRKWC5K40vNVg-I-PpROm2J5NhBO3lp0NBl0UruH3RBKxlpHfTdzXoEYpziVTucUqSEP7uSW7XXHJL9ATDPWHa4uUIMjABACQU","expires_in":7200}
         
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid={0}&secret={1}", appID, appsecret);
            string jsonStr = HttpHelper.HttpGet(url);
            var obj = JsonConvert.DeserializeObject<WeiXinToken>(jsonStr);


            string access_token = obj.access_token;

         
            string ticketUrl = string.Format("https://api.weixin.qq.com/cgi-bin/ticket/getticket?access_token={0}&type=jsapi", access_token.ToString());
         
            string ticketJsonStr = HttpHelper.HttpGet(ticketUrl);

            //{"errcode":0,"errmsg":"ok","ticket":"bxLdikRXVbTPdHSM05e5u_ug7IyLYnfqUGlT1k4e4AAC9TLrav0fA-mnVy33SxBnTZ4ORmftFSRSIaxTj0uVvQ","expires_in":7200}

             var objticket = JsonConvert.DeserializeObject<WeiXinTicket>(ticketJsonStr);

            ticket = objticket.ticket;

            return access_token;
        }

        public static UInt32 UnixStamp()
        {

            TimeSpan ts = DateTime.Now - TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));

            return Convert.ToUInt32(ts.TotalSeconds);

        }

        /// <summary>
        /// 用GUID作种子生成理论上不重复的随机数作为验证码
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string GenerateRandomCode(int length)
        {
            var result = new StringBuilder();
            for (var i = 0; i < length; i++)
            {
                var r = new Random(Guid.NewGuid().GetHashCode());
                result.Append(r.Next(0, 10).ToString());
            }
            string code = result.ToString();

            return code;
        }

        /// <summary>
        /// 签名算法       
        /// </summary>
        /// <param name="jsapi_ticket">jsapi_ticket</param>
        /// <param name="noncestr">随机字符串(必须与wx.config中的nonceStr相同)</param>
        /// <param name="timestamp">时间戳(必须与wx.config中的timestamp相同)</param>
        /// <param name="url">当前网页的URL，不包含#及其后面部分(必须是调用JS接口页面的完整URL)</param>
        /// <returns></returns>
        public static string GetSignature(string jsapi_ticket, string noncestr, string timestamp, string url, out string string1)
        {
            var string1Builder = new StringBuilder();
            string1Builder.Append("jsapi_ticket=").Append(jsapi_ticket).Append("&")
                          .Append("noncestr=").Append(noncestr).Append("&")
                          .Append("timestamp=").Append(timestamp).Append("&")
                          .Append("url=").Append(url.IndexOf("#") >= 0 ? url.Substring(0, url.IndexOf("#")) : url);
            string1 = string1Builder.ToString();

            return Sha1Signature(string1, Encoding.UTF8);
        }

        /// <summary>
        /// Sha1签名
        /// </summary>
        /// <param name="str">内容</param>
        /// <param name="encoding">编码</param>
        /// <returns></returns>
        private static string Sha1Signature(string str, Encoding encoding = null)
        {
            if (encoding == null) encoding = Encoding.UTF8;
            var buffer = encoding.GetBytes(str);
            var data = SHA1.Create().ComputeHash(buffer);
            StringBuilder sub = new StringBuilder();
            foreach (var t in data)
            {
                sub.Append(t.ToString("x2"));
            }

            return sub.ToString();
        }


    }

    public class ReturnWeixinInfo
    {
        public string timestamp { get; set; }
        public string appid { get; set; }
        public string nonceStr { get; set; }
        public string signature { get; set; }
        public string token { get; set; }
    }

    public class WeiXinToken
    {
        public string access_token { get; set; }
        public string expires_in { get; set; }
     
    }

   
    public class WeiXinTicket
    {
        public string errcode { get; set; }
        public string errmsg { get; set; }

        public string ticket { get; set; }

        public string expires_in { get; set; }

    }
}
