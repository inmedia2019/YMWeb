using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YMWeb.Domain.DictionaryDataBase;
using YMWeb.Domain.InfoManage;
using YMWeb.Service.DictionaryDataBase;
using YMWeb.Service.InfoManage;
using YMWeb.WebApi.Models;
using YMWeb.WebApi.Tools;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace YMWeb.WebApi.Controllers
{
    public class ActionMessage {
        public string mid { get; set; }
        public string content { get; set; }
    }
    
    [Route("api/[controller]")]
    [ApiController]
    public class LiveMessageController : ControllerBase
    {
        public MemberinfoService _minfoService { get; set; }

        public BadgetypeinfoService _badgetypeinfoService { get; set; }

        public UseractioninfoService _actionInfoService { get; set; }

        public LivemessageService _liveMessageService { get; set; }

        /// <summary>
        /// 用户留言
        /// </summary>
        /// <param name="mid">用户ID</param>
        /// <param name="content">留言内容</param>
        /// <returns></returns>
        [HttpPost("SetLeaveMessage")]
        public async Task<ReturnType<ReturnActionInfo>> SetLeaveMessage([FromBody] ActionMessage infos)
        {
            
            string actionId = "";
            MemberinfoEntity minfo = await _minfoService.GetUserInfoByMid(infos.mid);


            //查询留言积分规则
            BadgetypeinfoEntity btypeInfo = await _badgetypeinfoService.GetInfoById("fb0d710f-bc60-4546-add6-c05d242e5ae3");

            //查询用户是否第一次留言
            int FirstSignCount = await _actionInfoService.GetFirstLiveMessageCount(infos.mid);

            LivemessageEntity lInfo = new LivemessageEntity();
            lInfo.F_createDate = DateTime.Now;
            lInfo.F_Id = "";
            lInfo.F_IsAgreeActionCollect = minfo.IsAgreeActionCollect;
            lInfo.F_IsAgreeAgreement = minfo.IsAgreeAgreement;
            lInfo.F_JobTitle = minfo.JobTitle;
            lInfo.F_MediaName = minfo.mediaName;
            lInfo.F_Message = infos.content;
            lInfo.F_Mid = minfo.Id;
            lInfo.F_Phone = minfo.phone;
            lInfo.F_Sex = minfo.Sex;
            lInfo.F_TrueName = minfo.trueName;
            actionId = await _liveMessageService.SubmitForm(lInfo, "");


            UseractioninfoEntity info = new UseractioninfoEntity();
            info.createDate = DateTime.Now;
            info.descript = "";
            info.Id = "";
            info.infoid = "";
            info.InternalData = "";
            info.ipadress = "";
            info.lurl = "";
            info.mid = infos.mid;
            info.moreCol = "3"; //留言
            info.moreCol1 = "";
            info.nid = "";
            info.Phone = minfo.phone;
            info.PID = "";
            info.scoreNum = FirstSignCount == 0 ? btypeInfo.F_FirstScore : btypeInfo.F_OneScore;
            info.SpecialData = "";
            info.state = 0;
            info.tid = 1;
            info.trueName = minfo.trueName;
            info.vContent = "";

            await _actionInfoService.SubmitForm(info, "");

            //更新用户积分
            minfo.userScore = minfo.userScore + info.scoreNum;
            await _minfoService.SubmitForm(minfo, minfo.Id);


            ReturnActionInfo rinfo = new ReturnActionInfo();
            rinfo.actionId = actionId;
            rinfo.userScore = minfo.userScore.ToString();

            if (actionId != "")
            {
              
                //string result = "{\"actionId\":\"" + actionId + "\",\"userScore\":\"" + minfo.userScore.ToString() + "\"}";
                return Util.getReturnObjects(rinfo, "true");
            }
            else
            {
               // string result = null;
                return Util.getReturnObjects(rinfo, "");
            }

        }

    }

    public class ReturnActionInfo
    {
        public string actionId { get; set; }
        public string userScore { get; set; }
    }

}
