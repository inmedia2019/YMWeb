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

    public class FavitorActionInfo
    {
        // <param name="mid">用户ID</param>
        public string mid { get; set; }
        // <param name="infoId">infoId</param>
        public string infoId { get; set; }
        /// <summary>
        /// 0:新增收藏 1:取消收藏
        /// </summary>
        public int tid { get; set; }
        /// <summary>
        /// 页面URL
        /// </summary>
        public string url { get; set; }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class FavitorinfoController : ControllerBase
    {
        //自动注入服务
        public FavitorinfoService _favitorinfoService { get; set; }

        public ContentService _contentService { get; set; }

        public MemberinfoService _minfoService { get; set; }

        public ChannelService _channelService { get; set; }

        public LableService _labelService { get; set; }

        /// <summary>
        /// 新增收藏信息
        /// </summary>
        /// <returns></returns>
        [HttpPost("SetUserFavitorInfo")]
        public async Task<ReturnType<FavitorAction>> SetUserFavitorInfo([FromBody] FavitorActionInfo infos)
        {
            FavitorAction returnInfo = new FavitorAction();
            string actionId = "";
            //查询信息
            var dataInfo = await _contentService.GetInfoById(infos.infoId);
            //查询用户
            MemberinfoEntity minfo = await _minfoService.GetUserInfoByMid(infos.mid);

            //新增
            if (infos.tid == 0)
            {
                //查询该文章是否已经被收藏
                int count = await _favitorinfoService.GetFavitorRecordCount(infos.mid, infos.infoId);
                if (count == 0)
                {
                    FavitorinfoEntity info = new FavitorinfoEntity();
                    info.createDate = DateTime.Now;
                    info.F_Id = "";
                    info.infoBanner = dataInfo.F_CoverImage;
                    info.infoCreateDate = dataInfo.F_LastModifyTime;
                    info.infoId = infos.infoId;

                    info.infoParentId = dataInfo.F_ChannelId;

                    info.infoTitle = dataInfo.F_Titile;
                    info.mid = infos.mid;
                    info.morecol = minfo.trueName;
                    info.morecol1 = minfo.phone;
                    info.state = 0;
                    info.tid = 0;
                    info.infoUrl = infos.url;
                    actionId = await _favitorinfoService.SubmitForm(info, "");

                    returnInfo.actionId = actionId;
                    // string result = "{\"actionId\":\"" + actionId + "\"}";
                    
                    dataInfo.F_FavoritesCount = dataInfo.F_FavoritesCount + 1;
                    await _contentService.SubmitForm(dataInfo, infos.infoId);

                    return Util.getReturnObjects(returnInfo, "true");
                }

            }
            else  //取消收藏
            {
                int result = await _favitorinfoService.DeleteForm(infos.mid, infos.infoId);
                if (result > 0)
                {
                    returnInfo.actionId = "";
                    dataInfo.F_FavoritesCount = dataInfo.F_FavoritesCount - 1;
                    await _contentService.SubmitForm(dataInfo, infos.infoId);

                    return Util.getReturnObjects(returnInfo, "true");
                }
            }
            
            return Util.getReturnObjects(returnInfo, "");
        }


        /// <summary>
        /// 获取用户收藏类型
        /// </summary>
        /// <param name="mid">mid</param>
        /// <returns></returns>
        [HttpGet("GetFavitorInfoByMid")]
        public async Task<ReturnTypeList<FavitorTypeInfo>> GetFavitorInfoByMid(string mid = "")
        {
            List<FavitorinfoEntity> list = await _favitorinfoService.GetListByMid(mid);
            List<FavitorTypeInfo> returnList = new List<FavitorTypeInfo>();
            ArrayList typeList = new ArrayList();
            for (int i = 0; i < list.Count; i++)
            {
                if (typeList.Contains(list[i].infoParentId) == false)
                    typeList.Add(list[i].infoParentId);
            }

            for (int i = 0; i < typeList.Count; i++)
            {
                ChannelEntity o = await _channelService.GetInfoById(typeList[i].ToString());
                FavitorTypeInfo info = new FavitorTypeInfo();
                info.InfoTitle = o.F_ChannelName;
                info.FavitorTypeId = o.F_Id;
                returnList.Add(info);
            }

            return Util.getReturnObjectByList(returnList);
        }

        /// <summary>
        /// 根据收藏类型ID获取用户收藏信息
        /// </summary>
        /// <param name="mid">用户ID</param>
        /// <param name="ParentId">信息类型</param>
        /// <returns></returns>
        [HttpGet("GetFavitorInfoByMidAndParentId")]
        public async Task<ReturnTypeList<FavitorinfoEntity>> GetFavitorInfoByMidAndParentId(string mid = "", string ParentId = "")
        {
            var data = await _favitorinfoService.GetListByMidAndParentId(mid, ParentId);
            List<FavitorinfoEntity> list = new List<FavitorinfoEntity>();
            foreach (var item in data)
            {
                var  t= await _contentService.GetInfoById(item.infoId);
                if (t != null)
                {
                    item.FNum = t.F_FavoritesCount;
                    item.clickNum = t.F_HitCount;
                    item.F_PublishTime = t.F_PublishTime.ToString();
                    var b = await _channelService.GetInfoById(t.F_ChannelId);
                    item.parentName = b.F_ChannelName;
                    item.PicUrl = item.infoBanner;
                    if (item.infoBanner.IndexOf("http://") < 0 && item.infoBanner.IndexOf("https://") < 0)
                    {
                        item.infoBanner = GlobalContext.SystemConfig.url + item.infoBanner;
                        item.PicUrl = GlobalContext.SystemConfig.url + item.PicUrl;
                    }




                    if (t.F_ChannelId.Length > 0)
                    {
                        ChannelEntity channel = await _channelService.GetInfoById(t.F_ChannelId);
                        if (channel.F_ParentId == "0")
                        {
                            item.F_ChannelOne = channel.F_ChannelName;
                            item.F_ChannelColor = channel.F_Icon;
                        }
                        else
                        {
                            while (1 == 1)
                            {
                                ChannelEntity tempChannel = channel;
                                channel = await _channelService.GetInfoById(channel.F_ParentId);
                                if (channel.F_ParentId == "0")
                                {
                                    item.F_ChannelOne = tempChannel.F_ChannelName;
                                    item.F_ChannelColor = tempChannel.F_Icon;
                                    break;
                                }
                                else
                                    continue;
                            }
                        }

                    }
                    list.Add(item);
                }
               

            }
            return Util.getReturnObjectByList(list);
        }


        /// <summary>
        /// 根据信息ID查询用户是否收藏
        /// </summary>
        /// <param name="mid">用户ID</param>
        /// <param name="infoId">infoId</param>
        /// <returns></returns>
        [HttpGet("GetUserIsFavitorInfo")]
        public async Task<ReturnType<ReturnIsFavitor>> GetUserIsFavitorInfo(string mid = "", string infoId = "")
        {
            //查询该文章是否已经被收藏
            int count = await _favitorinfoService.GetFavitorRecordCount(mid, infoId);

            ReturnIsFavitor returnInfo = new ReturnIsFavitor();
            returnInfo.IsFavitor = count > 0 ? "1" : "0";
           // string result = "{\"IsFavitor\":\"" + (count > 0 ? 1 : 0) + "\"}";
            return Util.getReturnObjects(returnInfo, "");
        }

    }

    public class FavitorTypeInfo
    {
        public string FavitorTypeId { get; set; }
        public string InfoTitle { get; set; }
    }

    public class FavitorAction
    {
        public string actionId { get; set; }
    }

    public class ReturnIsFavitor
    {
        public string IsFavitor { get; set; }
    }

}
