using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using YMWeb.Code;
using YMWeb.Domain.ContentManage;
using YMWeb.Domain.DictionaryDataBase;
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
    public class ContentController : ControllerBase
    {
        public ContentService _contentService { get; set; }

        public LableService _labelService { get; set; }

        public ChannelService _channelService { get; set; }

        public ExpertService _expertService { get; set; }

        public HospitalService _hospitalService { get; set; }


        public UseractioninfoService _actionService { get; set; }

        public SubscriptionService _subscriptionService { get; set; }

        public FavitorinfoService _favitorinfoService { get; set; }

        public CityInfoService _cityInfoService { get; set; }


        /// <summary>
        /// 根据栏目ID获取信息列表
        /// </summary>
        /// <param name="channelId">频道ID</param>
        /// <param name="cityId">城市ID</param>
        /// <param name="subChannelId">副频道ID</param>
        /// <param name="orderInfo">排序:0:最新 1：最热</param>
        /// <param name="isRecommand">是否推荐:-1：全部 1：推荐 0：不推荐</param>
        /// <param name="keyWord">关键词</param>
        /// <param name="page">页码</param>
        /// <param name="psize">每页显示条数</param>
        /// <returns></returns>
        [HttpGet("GetInfoByChannelId")]
        public async Task<ReturnTypeList<ContentEntity>> GetInfoByChannelId(string cityId = "", string channelId = "", string subChannelId = "", string keyWord = "", int page = 1, int psize = 10, int orderInfo = 0, int isRecommand = -1)
        {
            subChannelId = subChannelId.Replace("%2C", ",");
            channelId = channelId.Replace("%2C", ",");

            // LogHelper.Write(channelId);
           
            keyWord = HttpUtility.UrlDecode(keyWord);
            var data = await _contentService.GetListByChannelId(cityId, channelId, subChannelId, keyWord, page, psize, orderInfo, isRecommand);
            foreach (var item in data)
            {
                try
                {
                    if (item.F_City != "")
                    {
                        var t = await _cityInfoService.GetInfoById(item.F_City);
                        item.F_CityName = t.F_CityName;
                    }
                }
                catch (Exception)
                {

                   
                }
              

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

                if (item.F_ChannelId.Length > 0)
                {
                    ChannelEntity channel = await _channelService.GetInfoById(item.F_ChannelId);
                    if (channel.F_ParentId == "0")
                    {
                        item.F_ChannelOne = channel.F_ChannelName;
                        item.F_ChannelColor = channel.F_Icon;
                    }
                    else {
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

                item.PicUrl = item.F_CoverImage;
                item.VideoUrl = item.F_Video;
               
                if (item.F_CoverImage.IndexOf("http://") < 0 && item.F_CoverImage.IndexOf("https://") < 0)
                {
                    item.PicUrl = GlobalContext.SystemConfig.url + item.F_CoverImage;
                }

                if (item.F_Video.IndexOf("http://") < 0 && item.F_Video.IndexOf("https://") < 0)
                {
                    item.VideoUrl = GlobalContext.SystemConfig.url + item.F_Video;
                }

            }
           
            return Util.getReturnObjectByList(data);

        }

        /// <summary>
        /// 首页推荐阅读获取信息列表
        /// </summary>
        /// <param name="currentCityName">当前城市名称</param>
        /// <param name="channelId">频道ID</param>
        /// <param name="cityId">城市ID</param>
        /// <param name="subChannelId">副频道ID</param>
        /// <param name="orderInfo">排序:0:最新 1：最热</param>
        /// <param name="isRecommand">是否推荐:-1：全部 1：推荐 0：不推荐</param>
        /// <param name="keyWord">关键词</param>
        /// <param name="page">页码</param>
        /// <param name="psize">每页显示条数</param>
        /// <returns></returns>
        [HttpGet("GetHomeInfoByChannelId")]
        public async Task<ReturnTypeList<ContentEntity>> GetHomeInfoByChannelId(string currentCityName = "", string cityId = "", string channelId = "", string subChannelId = "", string keyWord = "", int page = 1, int psize = 10, int orderInfo = 0, int isRecommand = -1)
        {
            subChannelId = subChannelId.Replace("%2C", ",");
            channelId = channelId.Replace("%2C", ",");

            // LogHelper.Write(channelId);
            string currentCityId = "";
            var cityInfo = await _cityInfoService.GetCityIdByName(currentCityName);
            if (cityInfo != null)
            {
                currentCityId = cityInfo.F_Id;
            }

            keyWord = HttpUtility.UrlDecode(keyWord);
            var data = await _contentService.GetHomeListByChannelId(currentCityId, cityId, channelId, subChannelId, keyWord, page, psize, orderInfo, isRecommand);
            foreach (var item in data)
            {
                try
                {
                    if (item.F_City != "")
                    {
                        var t = await _cityInfoService.GetInfoById(item.F_City);
                        item.F_CityName = t.F_CityName;
                    }
                }
                catch (Exception)
                {


                }


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

                if (item.F_ChannelId.Length > 0)
                {
                    ChannelEntity channel = await _channelService.GetInfoById(item.F_ChannelId);
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

                item.PicUrl = item.F_CoverImage;
                item.VideoUrl = item.F_Video;

                if (item.F_CoverImage.IndexOf("http://") < 0 && item.F_CoverImage.IndexOf("https://") < 0)
                {
                    item.PicUrl = GlobalContext.SystemConfig.url + item.F_CoverImage;
                }

                if (item.F_Video.IndexOf("http://") < 0 && item.F_Video.IndexOf("https://") < 0)
                {
                    item.VideoUrl = GlobalContext.SystemConfig.url + item.F_Video;
                }

            }

            return Util.getReturnObjectByList(data);

        }

        /// <summary>
        /// 根据栏目ID获取直播列表
        /// </summary>
        /// <param name="tid">直播状态:0:预告 1：直播中 2:回看</param>
        /// <param name="channelId">频道ID</param>
        /// <param name="subChannelId">副频道ID</param>
        /// <param name="keyWord">关键词</param>
        /// <param name="page">页码</param>
        /// <param name="psize">每页显示条数</param>
        /// <returns></returns>
        [HttpGet("GetLiveInfoByChannelId")]
        public async Task<ReturnTypeList<ContentEntity>> GetLiveInfoByChannelId(string tid = "-1", string channelId = "", string subChannelId = "", string keyWord = "", int page = 1, int psize = 10)
        {
            subChannelId = subChannelId.Replace("%2C", ",");
            var data = await _contentService.GetLiveInfoByChannelId(tid, channelId, subChannelId,  keyWord, page, psize);
            foreach (var item in data)
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
                if (item.F_CoverImage.IndexOf("http://") < 0 && item.F_CoverImage.IndexOf("https://") < 0)
                {
                    item.PicUrl = GlobalContext.SystemConfig.url + item.F_CoverImage;
                }

                if (item.F_Video.IndexOf("http://") < 0 && item.F_Video.IndexOf("https://") < 0)
                {
                    item.VideoUrl = GlobalContext.SystemConfig.url + item.F_Video;
                }

            }
            return Util.getReturnObjectByList(data);

        }



        /// <summary>
        /// 根据信息ID获取详细信息
        /// </summary>
        /// <param name="Id">Id</param>
        /// <param name="mid">用户ID</param>
        /// <returns></returns>
        [HttpGet("GetNewsInfoById")]
        public async Task<ActionResult> GetNewsInfoById(string Id = "", string mid = "")
        {
            var data = await _contentService.GetInfoById(Id);

            data.F_Content = data.F_Content.Replace("/ymweb/upload/", GlobalContext.SystemConfig.url + "/ymweb/upload/");
            data.F_Content = data.F_Content.Replace("\\\"", "\"");

            data.F_LiveIntroduction = data.F_LiveIntroduction.Replace("/ymweb/upload/", GlobalContext.SystemConfig.url + "/ymweb/upload/");
            data.F_LiveIntroduction = data.F_LiveIntroduction.Replace("\\\"", "\"");

            data.F_LiveIntroduction = data.F_LiveIntroduction.Replace("/ymwebTest/upload/", GlobalContext.SystemConfig.url + "/ymwebTest/upload/");

            data.PicUrl = data.F_CoverImage;
            data.VideoUrl = data.F_Video;
            if (data.F_CoverImage.IndexOf("http://") < 0 && data.F_CoverImage.IndexOf("https://") < 0)
            {
                data.PicUrl = GlobalContext.SystemConfig.url + data.F_CoverImage;
            }

            if (data.F_Video.IndexOf("http://") < 0 && data.F_Video.IndexOf("https://") < 0)
            {
                data.VideoUrl = GlobalContext.SystemConfig.url + data.F_Video;
            }

            ExpertEntity author = await _expertService.GetInfoById(data.F_Author.Split(',')[0]);
           
            if (author != null)
            {
                data.AuthorName = author.F_Name;
                data.AuthorJob = author.F_Position;
                HospitalEntity hospitalInfo = await _hospitalService.GetInfoById(author.F_HospitalId);
                if (hospitalInfo != null)
                {
                    data.AuthorHospital = hospitalInfo.F_HospitalName;
                }
            }

            if (data.F_Tags.Length > 0)
            {
                List<LableEntity> tagList = await _labelService.GetListByIds(data.F_Tags);
                foreach (var item in tagList)
                {
                    data.F_TagsName += item.F_Name + ",";
                }
            }

            var sub = await _subscriptionService.GetListByMidAndInfoId(mid, Id);
            data.IsSubcri = sub.Count > 0 ? 1 : 0;

            var fa = await _favitorinfoService.GetFavitorRecordCount(mid, Id);
            data.IsFavitor = fa > 0 ? 1 : 0;

            var dz = await _actionService.GetDZRecordCount(mid, Id);
            if (dz == null)
            {
                data.IsdZ = 0;
            }
            else
            {
                if (dz.tid == 2)
                {
                    data.IsdZ = 1;
                }
                else
                {
                    data.IsdZ = 0;
                }
            }
 
            return Content(data.ToJson());

        }

        /// <summary>
        /// 获取用户浏览记录和点赞类型
        /// </summary>
        /// <param name="mid">mid</param>
        /// <param name="channelId">mid</param>
        /// <param name="tid">tid</param>
        /// <returns></returns>
        [HttpGet("GetHistoryInfoTypeByMid")]
        public async Task<ReturnTypeList<HistoryTypeInfo>> GetHistoryInfoTypeByMid(string mid = "", int tid = 0,string channelId="")
        {
            var data = await _actionService.GetHistoryByMid(mid, tid);
            string searchInfoId = "";
            foreach (var item in data)
            {
                searchInfoId += "'" + item.infoid + "',";
            }

            if (searchInfoId.Length > 0)
                searchInfoId = searchInfoId.Substring(0, searchInfoId.Length - 1);

            List<ContentEntity> infoList = await _contentService.GetListByInfoIds(searchInfoId, channelId);
          
            List<HistoryTypeInfo> returnList = new List<HistoryTypeInfo>();
            ArrayList typeList = new ArrayList();
            for (int i = 0; i < infoList.Count; i++)
            {
                if (typeList.Contains(infoList[i].F_ChannelId) == false)
                    typeList.Add(infoList[i].F_ChannelId);
            }

            for (int i = 0; i < typeList.Count; i++)
            {
                ChannelEntity o = await _channelService.GetInfoById(typeList[i].ToString());
                HistoryTypeInfo info = new HistoryTypeInfo();
                info.InfoTitle = o.F_ChannelName;
                info.HistoryTypeId = o.F_Id;
                returnList.Add(info);
            }

            return Util.getReturnObjectByList(returnList);
        }

        /// <summary>
        /// 根据获取用户Id获取浏览历史记录信息和点赞
        /// </summary>
        /// <param name="mid">当前用户ID</param>
        /// <param name="page">当前页</param>
        /// <param name="ChannelId">栏目ID</param>
        /// <param name="fmenuId">副栏目ID</param>
        /// <param name="tid">0:浏览 2:点赞</param>
        /// <returns></returns>
        [HttpGet("GetHistoryByMid")]
        public async Task<ReturnTypeList<ContentEntity>> GetHistoryByMid(string mid = "", int page = 0, string fmenuId = "", int tid = 0, string ChannelId = "")
        {
            var data = await _actionService.GetHistoryByMid(mid, tid);
            string searchInfoId = "";
            foreach (var item in data)
            {
                searchInfoId += "'" + item.infoid + "',";
            }

            if (searchInfoId.Length > 0)
                searchInfoId = searchInfoId.Substring(0, searchInfoId.Length - 1);

            var list = await _contentService.GetListByInfoIds(searchInfoId, page, 10, mid, fmenuId, ChannelId);
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

                if (item.F_ChannelId.Length > 0)
                {
                    ChannelEntity channel = await _channelService.GetInfoById(item.F_ChannelId);
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


                var d = await _actionService.GetTopInfo(mid, item.F_Id);
                item.PageUrl = d.lurl;

                item.PicUrl = item.F_CoverImage;
                item.VideoUrl = item.F_Video;

                if (item.F_CoverImage.IndexOf("http://") < 0 && item.F_CoverImage.IndexOf("https://") < 0)
                {
                    item.PicUrl = GlobalContext.SystemConfig.url + item.F_CoverImage;
                }

                if (item.F_Video.IndexOf("http://") < 0 && item.F_Video.IndexOf("https://") < 0)
                {
                    item.VideoUrl = GlobalContext.SystemConfig.url + item.F_Video;
                }

            }

            return Util.getReturnObjectByList(list);
        }

    }

    public class HistoryTypeInfo
    {
        public string HistoryTypeId { get; set; }
        public string InfoTitle { get; set; }
    }



}
