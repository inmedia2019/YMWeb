using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YMWeb.Domain.DictionaryDataBase;
using YMWeb.Service.DictionaryDataBase;
using YMWeb.WebApi.Models;
using YMWeb.WebApi.Tools;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace YMWeb.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotKeyWordController : ControllerBase
    {
        //自动注入服务
        public HotkeywordService _hotKeyWordService { get; set; }

        /// <summary>
        /// 获取热门关键词列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetHotHeyWordInfo")]
        public async Task<ReturnTypeList<HotkeywordEntity>> GetHotHeyWordInfo()
        {
            var data = await _hotKeyWordService.GetKeyWordList();
            return Util.getReturnObjectByList(data);
        }
    }
}
