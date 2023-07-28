using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YMWeb.Code;
using YMWeb.Domain.DictionaryDataBase;
using YMWeb.Service.DictionaryDataBase;
using YMWeb.WebApi.Models;
using YMWeb.WebApi.Tools;

namespace YMWeb.WebApi.Controllers
{
    /// <summary>
    /// 基础数据管理
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [AuthorizeFilter]
    public class DictionaryController : ControllerBase
    {
        //自动注入服务
        public HospitalService _hospitalService { get; set; }
        public ExpertService _expertService { get; set; }

        public DepartmentService _departmentService { get; set; }

        public JobtitleService _jobtitleService { get; set; }

        ///// <summary>
        ///// 获取医院信息
        ///// </summary>
        ///// <param name="id">id</param>
        ///// <returns></returns>
        //[HttpGet("GetHospitalsInfo")]
        //public async Task<ActionResult> GetHospitalsInfo(string id = "")
        //{
        //    var data = await _hospitalService.GetLookForm(id);
        //    return Content(data.ToJson());
        //}

        ///// <summary>
        ///// 获取所有医院信息
        ///// </summary>
        ///// <param name="id">id</param>
        ///// <returns></returns>
        //[HttpGet("GetHospitalsList")]
        //public async Task<ReturnTypeList<HospitalEntity>> GetHospitalsList(string id = "")
        //{
        //    var data = await _hospitalService.GetList(id);
        //    return Util.getReturnObjectByList(data);
        //}

        ///// <summary>
        ///// 获取专家信息
        ///// </summary>
        ///// <param name="id">id</param>
        ///// <returns></returns>
        //[HttpGet("GetExpertsInfo")]
        //public async Task<ReturnType<ExpertEntity>> GetExpertsInfo(string id = "")
        //{
        //    var data = await _expertService.GetLookForm(id);
        //    return Util.getReturnObject(data);
        //}

        ///// <summary>
        ///// 获取所有专家信息
        ///// </summary>
        ///// <param name="id">id</param>
        ///// <returns></returns>
        //[HttpGet("{id}")]
        //public async Task<ReturnTypeList<ExpertEntity>> GetExpertsList(string id = "")
        //{
        //    var data = await _expertService.GetList(id);
        //    return Util.getReturnObjectByList(data);
        //}

        /// <summary>
        /// 获取所有科室信息
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetDepartMentList")]
        public async Task<ReturnTypeList<DepartmentEntity>> GetDepartMentList()
        {
            var data = await _departmentService.GetList();
            return Util.getReturnObjectByList(data);
        }

        /// <summary>
        /// 获取所有职称信息
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetJobTitleList")]
        public async Task<ReturnTypeList<JobtitleEntity>> GetJobTitleList()
        {
            var data = await _jobtitleService.GetList();
            return Util.getReturnObjectByList(data);
        }

    }
}
