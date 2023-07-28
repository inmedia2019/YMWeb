using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YMWeb.Code;
using YMWeb.Domain.ContentManage;
using YMWeb.Domain.DictionaryDataBase;
using YMWeb.Domain.InfoManage;
using YMWeb.Service.ContentManage;
using YMWeb.Service.DictionaryDataBase;
using YMWeb.Service.InfoManage;
using YMWeb.WebApi.Models;
using YMWeb.WebApi.Tools;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace YMWeb.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionController : ControllerBase
    {
        public SubscriptionService _subscriptionService { get; set; }

        public LableService _labelService { get; set; }


        public ChannelService _channelService { get; set; }
        public ContentService _contentService { get; set; }

        public MemberinfoService _minfoService { get; set; }

        public ExpertService _expertService { get; set; }

        public HospitalService _hospitalService { get; set; }
        /// <summary>
        /// 获取用户订阅类型
        /// </summary>
        /// <param name="mid">mid</param>
        /// <param name="channelId">mid</param>
        /// <returns></returns>
        [HttpGet("GetSubscriptionInfoByMid")]
        public async Task<ReturnTypeList<SubscriptionTypeInfo>> GetSubscriptionInfoByMid(string mid = "", string channelId = "")
        {
            var data = await _subscriptionService.GetListByMid(mid);
            string searchInfoId = "";
            foreach (var item in data)
            {
                searchInfoId += "'" + item.InfoId + "',";
            }

            if (searchInfoId.Length > 0)
                searchInfoId = searchInfoId.Substring(0, searchInfoId.Length - 1);


            List<ContentEntity> infoList = await _contentService.GetListByInfoIds(searchInfoId, channelId);

            List<SubscriptionTypeInfo> returnList = new List<SubscriptionTypeInfo>();
            ArrayList typeList = new ArrayList();
            for (int i = 0; i < infoList.Count; i++)
            {
                if (typeList.Contains(infoList[i].F_Tags) == false)
                    typeList.Add(infoList[i].F_SubChannelId);
            }

            for (int i = 0; i < typeList.Count; i++)
            {
                ChannelEntity o = await _channelService.GetInfoById(typeList[i].ToString());
                SubscriptionTypeInfo info = new SubscriptionTypeInfo();
                info.InfoTitle = o.F_ChannelName;
                info.SubscriptionTypeId = o.F_Id;
                returnList.Add(info);
            }

            return Util.getReturnObjectByList(returnList);
        }

        /// <summary>
        /// 根据获取用户Id和副频道ID获取订阅信息
        /// </summary>
        /// <param name="mid">当前用户ID</param>
        /// <param name="page">当前页</param>
        /// <param name="subChannelId">副频道ID</param>
        /// <param name="tid">0:预告 1:直播中 2：回放 -1：全部</param>
        /// <returns></returns>
        [HttpGet("GetSubscriptionByMid")]
        public async Task<ReturnTypeList<ContentEntity>> GetSubscriptionByMid(string mid = "", int page = 0, string subChannelId = "", int tid = -1)
        {
            subChannelId = subChannelId.Replace("%2C", ",");
            var data = await _subscriptionService.GetListByMid(mid);
            string searchInfoId = "";
            foreach (var item in data)
            {
                searchInfoId += "'" + item.InfoId + "',";
            }

            if (searchInfoId.Length > 0)
                searchInfoId = searchInfoId.Substring(0, searchInfoId.Length - 1);

            var list = await _contentService.GetListByInfoIds(searchInfoId, page, 10, mid, subChannelId, tid);
            foreach (var item in list)
            {
                if (item.F_Author != "")
                {
                    ExpertEntity author = await _expertService.GetInfoById(item.F_Author.Split(',')[0]);
                    HospitalEntity hospitalInfo = await _hospitalService.GetInfoById(author.F_HospitalId);
                    if (author != null)
                    {
                        item.AuthorName = author.F_Name;
                        item.AuthorJob = author.F_Position;
                    }
                    if (hospitalInfo != null)
                    {
                        item.AuthorHospital = hospitalInfo.F_HospitalName;
                    }
                }

                item.PicUrl = item.F_CoverImage;
                item.VideoUrl = item.F_Video;
                if (item.F_CoverImage.IndexOf("http://") < 0)
                {
                    item.PicUrl = GlobalContext.SystemConfig.url + item.F_CoverImage;
                }

                if (item.F_Video.IndexOf("http://") < 0)
                {
                    item.VideoUrl = GlobalContext.SystemConfig.url + item.F_Video;
                }
            }

            return Util.getReturnObjectByList(list);
        }

        /// <summary>
        /// 用户预约
        /// </summary>
        /// <param name="infos">预约信息</param>
        /// <returns></returns>

        [HttpPost("SetSubscriptionInfo")]
        public async Task<ReturnType<ReturnSubscriptionInfo>> SetSubscriptionInfo([FromBody] SubscriptionRequestEntity infos)
        {

            string actionId = "";
            MemberinfoEntity minfo = await _minfoService.GetUserInfoByMid(infos.mid);

            ReturnSubscriptionInfo rinfo = new ReturnSubscriptionInfo();

            if (infos.tid == 0)
            {
                //是否已经预约
                int count = await _subscriptionService.GetListCountByInfoId(infos.infoId, infos.mid);
                if (count > 0)
                {
                    rinfo.actionId = "";
                    rinfo.msg = "您已经预约！";
                    return Util.getReturnObjectInfo(rinfo, "", false);
                }

                SubscriptionEntity info = new SubscriptionEntity();
                info.CreateTime = DateTime.Now;
                info.ID = "";
                info.InfoId = infos.infoId;
                info.IsSend = 0;
                info.MainLecturer = "";
                info.OpenId = infos.openId;
                info.Page = infos.url;
                info.QuestionLabel = infos.title;
                info.State = 0;
                info.Time = infos.time;
                info.Unionid = "";
                info.UserId = infos.mid;

                actionId = await _subscriptionService.SubmitForm(info, "");

             
                rinfo.actionId = actionId;
            }
            else
            {
                var data = await _subscriptionService.GetListByMidAndInfoId(infos.mid, infos.infoId);
                foreach (var item in data)
                {
                    await _subscriptionService.DeleteForm(item.ID);
                    actionId = item.ID;
                }
            }

            if (actionId != "")
            {


                return Util.getReturnObjects(rinfo, "true");
            }
            else
            {

                return Util.getReturnObjects(rinfo, "");
            }


        }

    }

    public class ReturnSubscriptionInfo
    {
        public string actionId { get; set; }
        public string msg { get; set; }
    }

    public class SubscriptionRequestEntity
    {

        /// <summary>
        /// 用户ID
        /// </summary>
        public string mid { get; set; }
        /// <summary>
        /// 用户openId
        /// </summary>
        public string openId { get; set; }
        /// <summary>
        /// 信息ID
        /// </summary>
        public string infoId { get; set; }
        /// <summary>
        /// 信息标题
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// 时间
        /// </summary>
        public string time { get; set; }

        /// <summary>
        /// 页面url
        /// </summary>
        public string url { get; set; }
        /// <summary>
        /// 操作类型：0：预约 1：取消预约
        /// </summary>
        public int tid { get; set; }
    }

    public class SubscriptionTypeInfo
    {
        public string SubscriptionTypeId { get; set; }
        public string InfoTitle { get; set; }
    }


}

