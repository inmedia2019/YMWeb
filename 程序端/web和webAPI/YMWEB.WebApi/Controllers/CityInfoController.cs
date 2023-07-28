using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    public class CityInfoController : ControllerBase
    {
        //自动注入服务
        public CityInfoService _cityInfoService { get; set; }

        public ContentService _contentService { get; set; }

        /// <summary>
        /// 获取城市信息列表
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetCityInfo")]
        public async Task<ReturnTypeList<CityInfoEntity>> GetCityInfo(string id = "")
        {
            var data = await _cityInfoService.GetListByIds(id);
            return Util.getReturnObjectByList(data);
        }

        /// <summary>
        /// 根据城市名称获取城市ID
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetCityIdByName")]
        public async Task<ReturnType<CityInfoEntity>> GetCityIdByName(string name = "")
        {
            var data = await _cityInfoService.GetCityIdByName(name);
            return Util.getReturnObjectInfo(data, "", true);
        }

        /// <summary>
        /// 根据栏目ID获取用户当前位置城市和最新发布城市位置
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetCityIdByChannelId")]
        public async Task<ReturnTypeList<ReturnCityInfo>> GetCityIdByChannelId(string channel = "", string cityName = "")
        {
            string currentCityId = "";
            var cityInfo = await _cityInfoService.GetCityIdByName(cityName);
            if (cityInfo != null)
            {
                currentCityId = cityInfo.F_Id;
            }

            var data = await _contentService.GetCityIdByChannelId(channel, currentCityId);

            List<ReturnCityInfo> list = new List<ReturnCityInfo>();
            for (int i = 0; i < data.Count; i++)
            {
                ReturnCityInfo info = new ReturnCityInfo();
                info.F_Id = data[i].F_City;
                var city = await _cityInfoService.GetInfoById(data[i].F_City);
                info.F_Name = city.F_CityName;
                list.Add(info);
            } 

            return Util.getReturnObjectByList(list);
        }
    }

    public class ReturnCityInfo
    {
        public string F_Id { get; set; }
        public string F_Name { get; set; }
    }

}
