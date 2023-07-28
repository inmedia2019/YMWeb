using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YMWeb.Code;
using YMWeb.Domain.ContentManage;
using YMWeb.Service.ContentManage;
using YMWeb.WebApi.Models;
using YMWeb.WebApi.Tools;

namespace YMWeb.WebApi.Controllers
{
    /// <summary>
    /// cms管理
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CmsManageController : ControllerBase
    {
        //自动注入服务
        public ChannelService _channelService { get; set; }

        /// <summary>
        /// 根据父级栏目ID获取下级栏目信息
        /// </summary>
        /// <param name="parentId">父级ID</param>
        /// <param name="keyWord">搜索关键字</param>
        /// <returns></returns>
        [HttpGet("GetChannelInfoByParentId")]
        public async Task<ReturnTypeList<ChannelEntity>> GetChannelInfoByParentId(string parentId = "", string keyWord = "")
        {
            var data = await _channelService.GetListByParentId(parentId, keyWord);
            return Util.getReturnObjectByList(data);
        }


        /// <summary>
        /// 根据栏目ID获取栏目信息
        /// </summary>
        /// <param name="Id">父级ID</param>

        /// <returns></returns>
        [HttpGet("GetChannelInfoById")]
        public async Task<ReturnType<ChannelEntity>> GetChannelInfoById(string Id = "")
        {
            var data = await _channelService.GetInfoById(Id);
            
            if (data.F_ChannelImages.IndexOf("http://") < 0 && data.F_ChannelImages.IndexOf("https://") < 0)
            {
                data.F_ChannelImages = GlobalContext.SystemConfig.url + data.F_ChannelImages;
            }

           
            data.F_PictureUrl = data.F_PictureUrl.Replace("/ymweb/", GlobalContext.SystemConfig.url + "/ymweb/");

         
            return Util.getReturnObject(data);

        }

    }
}
