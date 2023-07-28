using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YMWeb.Domain.ContentManage;
using YMWeb.Service.ContentManage;
using YMWeb.WebApi.Models;
using YMWeb.WebApi.Tools;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace YMWeb.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlockController : ControllerBase
    {
        //自动注入服务
        public BlockService _blockService { get; set; }

        /// <summary>
        /// 根据栏目ID获取banner列表
        /// </summary>
        /// <param name="channelId">父级ID</param>
        /// <returns></returns>
        [HttpGet("GetBannerByChannelId")]
        public async Task<ReturnTypeList<BlockEntity>> GetBannerByChannelId(string channelId = "")
        {
            var data = await _blockService.GetBannerByChannelId(channelId);
            return Util.getReturnObjectByList(data);
        }


    }
}
