using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    public class ContentLableController : ControllerBase
    {
        //自动注入服务
        public ContentLableService _contentLableService { get; set; }

        /// <summary>
        /// 根据标签ID获取标签内容
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetContentLableInfo")]
        public async Task<ReturnTypeList<ContentLableEntity>> GetContentLableInfo(string id = "")
        {
            var data = await _contentLableService.GetListByIds(id);
            return Util.getReturnObjectByList(data);
        }
    }
}
