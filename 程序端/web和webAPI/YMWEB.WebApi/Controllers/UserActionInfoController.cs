using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YMWeb.Code;
using YMWeb.Domain.ContentManage;
using YMWeb.Domain.DictionaryDataBase;
using YMWeb.Service.ContentManage;
using YMWeb.Service.DictionaryDataBase;
using YMWeb.WebApi.Models;
using YMWeb.WebApi.Tools;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace YMWeb.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserActionInfoController : ControllerBase
    {
        //自动注入服务
        public UseractioninfoService _actionInfoService { get; set; }

        public MemberinfoService _minfoService { get; set; }
        public BadgetypeinfoService _badgetypeinfoService { get; set; }
        public BadgeinfoService _badgetinfoService { get; set; }

        public ContentService _contentService { get; set; }
        public ChannelService _channelService { get; set; }
        /// <summary>
        /// 用户签到
        /// </summary>
        /// <param name="mid">用户ID</param>
        /// <returns></returns>
        [HttpGet("SetUserSignByMid")]
        public async Task<ReturnType<ReturnMemberAction>> SetUserSignByMid(string mid = "")
        {
            ReturnMemberAction rinfo = new ReturnMemberAction();
            //查询当前用用户今天是否有签到
            string actionId = "";
            MemberinfoEntity minfo = await _minfoService.GetUserInfoByMid(mid);

            int count = await _actionInfoService.GetSignRecordCount(mid);
            if (count == 0)
            {
                //查询签到积分规则
                BadgetypeinfoEntity btypeInfo = await _badgetypeinfoService.GetLookForm("0861e3fa-e6e3-4297-8ec0-a9ba1c2102c2");

                //查询用户是否第一次签到
                int FirstSignCount = await _actionInfoService.GetFirstSignRecordCount(mid);

                UseractioninfoEntity info = new UseractioninfoEntity();
                info.createDate = DateTime.Now;
                info.descript = "";
                info.Id = "";
                info.infoid = "";
                info.InternalData = "";
                info.ipadress = "";
                info.lurl = "";
                info.mid = mid;
                info.moreCol = "0"; //签到
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

                actionId = await _actionInfoService.SubmitForm(info, "");

                //更新用户积分
                minfo.userScore = minfo.userScore + info.scoreNum;
                await _minfoService.SubmitForm(minfo, minfo.Id);

            }
            else
            {
                //string result = null;
                return Util.getReturnObjects(rinfo, "");
            }

            if (actionId != "")
            {
                //查询本月签到次数
                int monthSignNum = await _actionInfoService.GetSignRecordCountByMonth(mid);
                //  string result = "{\"actionId\":\"" + actionId + "\",\"userScore\":\"" + minfo.userScore.ToString() + "\",\"monthSignNum\":" + monthSignNum.ToString() + "}";

                rinfo.actionId = actionId;
                rinfo.monthSignNum = monthSignNum.ToString();
                rinfo.userScore = minfo.userScore.ToString();
                return Util.getReturnObjects(rinfo, "true");
            }
            else
            {
                //string result = null;
                return Util.getReturnObjects(rinfo, "");
            }
        }

        /// <summary>
        /// 新增用户行为
        /// </summary>
        /// <param name="mid">当前用户ID</param>
        /// <param name="infoId">信息ID</param>
        /// <param name="tid">0:浏览 1:搜索 2:点赞 3:评论 4:收藏 5:广告位点击 6:视频播放时间 7:取消收藏 8:取消点赞 9:更新用户信息 10:分享 11:首次显示banner 12:停留时长 13:阅读完成百分比 14:用户是否勾选同意按钮</param>
        /// <param name="content">搜索内容/评论内容/视频播放时间</param>
        /// <param name="pageUrl">页面地址</param>
        /// <param name="options">来源场景</param>
        /// <returns></returns>
        [HttpGet("AddUserActionByMid")]
        public async Task<ReturnType<ReturnBadgeInfo>> AddUserActionByMid(string mid = "", string infoId = "", int tid = 0, string content = "", string pageUrl = "", string options = "")
        {
            var minfo = await _minfoService.GetInfoMid(mid);
            string phone = "";
            string trueName = "";
            if (minfo != null)
            {
                phone = minfo.phone;
                trueName = minfo.trueName;
            }


            ReturnBadgeInfo rinfo = new ReturnBadgeInfo();
            UseractioninfoEntity info = new UseractioninfoEntity();
            info.createDate = DateTime.Now;
            info.descript = "";
            info.Id = "";
            info.infoid = infoId;
            info.InternalData = "";
            info.ipadress = "";
            info.lurl = pageUrl;
            info.mid = mid;
            info.moreCol = "";
            info.moreCol1 = "";
            info.nid = "";
            info.Phone = phone;
            info.PID = "";
            info.scoreNum = 0;
            info.SpecialData = options;
            info.state = 0;
            info.tid = tid;
            info.trueName = trueName;
            info.vContent = content;
            if (tid == 6)
            {
                Dictionary<string, UseractioninfoEntity> list = MemoryCacheHelper.Get<Dictionary<string, UseractioninfoEntity>>("userVideoTime");

                if (!list.ContainsKey(mid + "_6_" + infoId))
                {
                    list.Add(mid + "_6_" + infoId, info);
                }
                else
                {
                    var cdata = list[mid + "_6_" + infoId];
                    cdata.createDate = DateTime.Now;
                    list.Remove(mid + "_6_" + infoId);
                    list.Add(mid + "_6_" + infoId, info);
                }
                MemoryCacheHelper.Set("userVideoTime", list);

            }
            else
            {

                if (tid == 0)
                {
                    if (infoId != "")
                    {
                        var dataInfo = await _contentService.GetInfoById(infoId);
                        if (dataInfo != null)
                        {
                            dataInfo.F_HitCount = dataInfo.F_HitCount + 1;
                            await _contentService.SubmitForm(dataInfo, infoId);
                        }
                    }
                }
                else if (tid == 2)
                {
                    var dataInfo = await _contentService.GetInfoById(infoId);
                    if (dataInfo != null)
                    {
                        dataInfo.F_LikeCount = dataInfo.F_LikeCount + 1;
                        await _contentService.SubmitForm(dataInfo, infoId);
                    }
                }
                else if (tid == 8)
                {
                    var dataInfo = await _contentService.GetInfoById(infoId);
                    if (dataInfo != null)
                    {
                        dataInfo.F_LikeCount = dataInfo.F_LikeCount - 1;
                        await _contentService.SubmitForm(dataInfo, infoId);
                    }
                }

                await _actionInfoService.SubmitForm(info, "");
            }

            rinfo.msg = "OK";
            return Util.getReturnObjects(rinfo, "true");

        }



        /// <summary>
        /// 根据获取用户Id获取积分记录信息
        /// </summary>
        /// <param name="mid">当前用户ID</param>
        /// <param name="page">当前页</param>
        /// <returns></returns>
        [HttpGet("GetScoreRecdorByMid")]
        public async Task<ReturnTypeList<UseractioninfoEntity>> GetScoreRecdorByMid(string mid = "", int page = 0)
        {
            SoulPage<UseractioninfoEntity> pagination = new SoulPage<UseractioninfoEntity>();
            pagination.field = "id";
            pagination.order = "desc";
            pagination.rows = 20;
            if (page > 0)
            {
                pagination.page = page;
            }
            var data = await _actionInfoService.GetScoreRecdorByMid(pagination, mid);
            return Util.getReturnObjectByList(data);
        }

        /// <summary>
        /// 查询信息是否已经被当前用户收藏
        /// </summary>
        /// <param name="mid">当前用户ID</param>
        /// <param name="infoId">当前信息ID</param>
        /// <returns></returns>
        [HttpGet("GetFirstFavitorRecordCount")]
        public async Task<int> GetFirstFavitorRecordCount(string mid = "", string infoId = "")
        {

            int data = await _actionInfoService.GetFirstFavitorRecordCount(mid, infoId);
            return data;
        }

        /// <summary>
        /// 查询用户首次浏览Banner
        /// </summary>
        /// <param name="mid">当前用户ID</param>
        /// <param name="vcontent">内容</param>
        /// <returns></returns>
        [HttpGet("GetFirstLookCount")]
        public async Task<int> GetFirstLookCount(string mid = "", string vcontent = "")
        {

            int data = await _actionInfoService.GetFirstLookCount(mid, vcontent);
            return data;
        }

        /// <summary>
        /// 根据用户缓存观看视频信息
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetWatchInfo")]
        public ReturnTypeList<UseractioninfoEntity> GetWatchInfo()
        {
            List<UseractioninfoEntity> list = new List<UseractioninfoEntity>();
            var data = MemoryCacheHelper.Get<Dictionary<string, UseractioninfoEntity>>("userVideoTime");
            foreach (var item in data)
            {
                list.Add(item.Value);
            }
            return Util.getReturnObjectByList(list);
        }



    }

    public class ReturnBadgeInfo
    {
        public string msg { get; set; }
    }

    public class BadgeInfoModel
    {
        public string title { get; set; }
        public string picImg { get; set; }
        public bool DL { get; set; }
        public int? sn { get; set; }
    }

    public class ReturnMemberAction
    {
     
        public string actionId { get; set; }
        public string userScore { get; set; }
        public string monthSignNum { get; set; }
    }

}
