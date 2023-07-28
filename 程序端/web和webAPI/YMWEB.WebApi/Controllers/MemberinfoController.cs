using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TencentCloud.Common;
using TencentCloud.Common.Profile;
using TencentCloud.Sms.V20190711;
using TencentCloud.Sms.V20190711.Models;
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
    public class MemberinfoController : ControllerBase
    {
        //自动注入服务
        public MemberinfoService _minfoService { get; set; }

        public JobtitleService _jobtitleService { get; set; }

        public DepartmentService _departmentService { get; set; }

        public PhonecodeService _phonecodeServiceService { get; set; }

        public UseractioninfoService _actionInfoService { get; set; }

        /// <summary>
        ///用户注册
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<ReturnType<RegisterInfo>> AddMemberInfoInfo([FromBody] MemberinfoEntity minfo)
        {
            RegisterInfo rinfo = new RegisterInfo();
            string userId = "";
            int count = await _minfoService.GetRecordCountByPhone(minfo.phone);
            if (count == 0)
            {
                userId = await _minfoService.SubmitForm(minfo, "");
            }
            if (userId != "")
            {
                rinfo.mid = userId;
                rinfo.errorInfo = "";
                return Util.getReturnObjectInfo(rinfo, "",true);
            }
            else
            {
                rinfo.mid = userId;
                rinfo.errorInfo = "该用户已经存在";
                return Util.getReturnObjectInfo(rinfo, "",false);
            }

        }

        /// <summary>
        ///用户信息更新
        /// </summary>
        /// <returns></returns>
        [HttpPost("ModifyMemberInfoInfo")]
        public async Task<ReturnType<RegisterInfo>> ModifyMemberInfoInfo([FromBody] MemberinfoEntity minfo)
        {
            RegisterInfo rinfo = new RegisterInfo();
            string userId = "";
            userId = await _minfoService.SubmitForm(minfo, minfo.Id);
            if (userId != "")
            {
                rinfo.mid = userId;
                rinfo.errorInfo = "";
                return Util.getReturnObjectInfo(rinfo, "", true);
            }
            else
            {
                rinfo.mid = userId;
                rinfo.errorInfo = "更新失败";
                return Util.getReturnObjectInfo(rinfo, "", false);
            }

        }




        /// <summary>
        /// 根据openId获取用户信息
        /// </summary>
        /// <param name="openId">openId</param>
        /// <returns></returns>
        [HttpGet("GetUserInfoByOpenId")]
        public async Task<ActionResult> GetUserInfoByOpenId(string openId = "")
        {
           

            var data = await _minfoService.GetUserInfoByOpenId(openId);
            return Content(data.ToJson());
        }

        /// <summary>
        /// 更新用户协议书
        /// </summary>
        /// <param name="mid">用户Id</param>
        /// <param name="tid">更新类型1:用户协议 2：行为收集</param>
        /// <param name="tValue">更新值</param>
        /// <returns></returns>
        [HttpGet("ModifyUserInfoByMid")]
        public async Task<ReturnType<string>> ModifyUserInfoByMid(string mid = "", int tid = 1, bool tValue = true)
        {
            if (mid.Length > 0)
                mid = mid.Replace("'", "");
            //string result = null;
            var data = await _minfoService.GetUserInfoByMid(mid);
            if (tid == 1)
            {
                data.IsAgreeAgreement = tValue;
                UseractioninfoEntity info = new UseractioninfoEntity();
                info.createDate = DateTime.Now;
                info.descript = "";
                info.Id = "";
                info.infoid = "";
                info.InternalData = "";
                info.ipadress = "";
                info.lurl = "";
                info.mid = mid;
                info.moreCol = "";
                info.moreCol1 = "";
                info.nid = "";
                info.Phone = "";
                info.PID = "";
                info.scoreNum = 0;
                info.SpecialData = "";
                info.state = 0;
                info.tid = 14;
                info.trueName = "";
                info.vContent = "";
                await _actionInfoService.SubmitForm(info, "");
            }
            else
                data.IsAgreeActionCollect = tValue;
            string actionId = await _minfoService.SubmitForm(data, data.Id);

            return Util.getReturnObjects(actionId, "");
           
        }

        /// <summary>
        /// 注销用户
        /// </summary>
        /// <param name="mid">用户Id</param>
        /// <returns></returns>
        [HttpGet("DelUserInfoByMid")]
        public async Task<ReturnType<string>> DelUserInfoByMid(string mid = "")
        {
            if (mid.Length > 0)
                mid = mid.Replace("'", "");
            //string result = null;
            var data = await _minfoService.GetUserInfoByMid(mid);
            data.state = 3;
            string actionId = await _minfoService.SubmitForm(data, data.Id);

            return Util.getReturnObjects(actionId, "");

        }

        /// <summary>
        /// 根据手机号获取用户信息
        /// </summary>
        /// <param name="phone">手机号</param>
        /// <returns></returns>
        [HttpGet("GetUserInfoByPhone")]
        public async Task<ActionResult> GetUserInfoByPhone(string phone = "")
        {
            if (phone.Length > 0)
                phone = phone.Replace("'", "");
            //string result = null;
            var data = await _minfoService.GetUserInfoByPhone(phone);

            if (data != null)
            {
                var job = await _jobtitleService.GetInfoById(data.JobTitle);
                if (job != null)
                {
                    data.jobName = job.F_Name;
                }

                var depart = await _departmentService.GetInfoById(data.moreCol1);
                if (depart != null)
                {
                    data.department = depart.F_Name;
                }
            }

            return Content(data.ToJson());
        }

        /// <summary>
        /// 验证码发送
        /// </summary>
        /// <param name="phone">手机号</param>
        /// <returns></returns>
        [HttpGet("SenUserPhoneCode")]
        public async Task<ReturnType<PhoneCode>> SenUserPhoneCode(string phone = "")
        {
            
            string result = null;

            PhoneCode code = new PhoneCode();
            string jsonResult = "";
            code.code = Send(phone, out jsonResult);

            PhonecodeEntity codeInfo = new PhonecodeEntity();
            codeInfo.createDate = DateTime.Now;
            codeInfo.phone = phone;
            codeInfo.resultInfo = jsonResult;
            codeInfo.F_Id = Utils.GuId();
            await _phonecodeServiceService.SubmitForm(codeInfo, "");
            if (code.code != "-1")
            {
                return Util.getReturnObjectInfo(code, "true", true);
            }
            return Util.getReturnObjectInfo(code, "发送失败", false);

        }

        public static string Send(string PhoneNumber,out string resultInfo)
        {
            string data = "";
            string code = GenerateRandomCode(6);
           try
            {
                Credential cred = new Credential
                {
                    SecretId = "AKIDyrkPsukOr53lNkrjLirpdDXdWCex1pOv",
                    SecretKey = "ShjW5WoreBUaU95nGWaQK2YsJYaMte8T"
                };
                ClientProfile clientProfile = new ClientProfile();
                HttpProfile httpProfile = new HttpProfile();
                httpProfile.Endpoint = ("sms.tencentcloudapi.com");
                clientProfile.HttpProfile = httpProfile;
                SmsClient client = new SmsClient(cred, "", clientProfile);
                SendSmsRequest req = new SendSmsRequest();
                req.PhoneNumberSet = new string[] { "+86" + PhoneNumber };
                req.TemplateID = "1419754";
                req.Sign = "海策医学";
                req.TemplateParamSet = new string[] { code, "5" };
                req.SmsSdkAppid = "1400684402";
                
                SendSmsResponse resp = client.SendSmsSync(req);
                string jsonResult = AbstractModel.ToJsonString(resp);
                resultInfo = jsonResult;
               
                JObject jb = (JObject)JsonConvert.DeserializeObject(jsonResult);
                data = jb["SendStatusSet"][0]["Code"].ToString().ToLower();
                if (data.ToLower() != "ok")
                {
                    code = "-1";
                }
               
            }
            catch (Exception ex)
            {
                // receive = "";
                resultInfo = ex.Message;
                data = ex.Message;
                string error = ex.Message;
             
            }
            return code;
        }

        /// <summary>
        /// 用GUID作种子生成理论上不重复的随机数作为验证码
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        private static string GenerateRandomCode(int length)
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

    }

    public class PhoneCode
    {
        public string code { get; set; }
    }

    public class RegisterInfo
    {
        public string mid { get; set; }
        public string errorInfo { get; set; }
    }
       
}
