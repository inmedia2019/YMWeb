﻿using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using YMWeb.Code;
using YMWeb.Domain.DictionaryDataBase;
using YMWeb.Service;
using Microsoft.AspNetCore.Authorization;
using YMWeb.Service.DictionaryDataBase;

namespace YMWeb.Web.Areas.DictionaryDataBase.Controllers
{
    /// <summary>
    /// 创 建：超级管理员
    /// 日 期：2022-05-04 17:14
    /// 描 述：信息列表控制器类
    /// </summary>
    [Area("DictionaryDataBase")]
    public class MemberinfoController :  ControllerBase
    {
        private string className = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName.Split('.')[5];
        public MemberinfoService _service {get;set;}

        public DepartmentService _departservice { get; set; }
        public JobtitleService _jobtitleservice { get; set; }

        #region 获取数据
        [HttpGet]
        [HandlerAjaxOnly]
        public async Task<ActionResult> GetGridJson(SoulPage<MemberinfoEntity> pagination, string keyword)
        {
            if (string.IsNullOrEmpty(pagination.field))
            {
                pagination.field = "createDate";
                pagination.order = "desc";
            }
            var data = await _service.GetLookList(pagination,keyword);
            foreach (var item in data)
            {
                var d = await _departservice.GetInfoById(item.moreCol1);
                if (d != null)
                {
                    item.department = d.F_Name;
                }
                else
                {
                    item.department = "";
                }
                var job = await _jobtitleservice.GetInfoById(item.JobTitle);
                if (job != null)
                {
                    item.jobName = job.F_Name;
                }
                else
                {
                    item.jobName = "";
                }
            }
            return Content(pagination.setData(data).ToJson());
        }

        [HttpGet]
        [HandlerAjaxOnly]
        public async Task<ActionResult> GetListJson(string keyword)
        {
            var data = await _service.GetList(keyword);
            return Content(data.ToJson());
        }

        [HttpGet]
        [HandlerAjaxOnly]
        public async Task<ActionResult> GetFormJson(string keyValue)
        {
            var data = await _service.GetLookForm(keyValue);
            return Content(data.ToJson());
        }
        #endregion

        #region 提交数据
        [HttpPost]
        [HandlerAjaxOnly]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SubmitForm(MemberinfoEntity entity, string keyValue)
        {
           MemberinfoEntity data = null;
            if (!string.IsNullOrEmpty(keyValue))
            {
            data = await _service.GetForm(keyValue);
            }
            try
            {
                await _service.SubmitForm(entity, keyValue);
                return await Success("操作成功。", className, entity, data, keyValue);
            }
            catch (Exception ex)
            {
                return await Error(ex.Message, className, entity, data, keyValue);
            }
        }

        [HttpPost]
        [HandlerAjaxOnly]
        [ServiceFilter(typeof(HandlerAuthorizeAttribute))]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteForm(string keyValue)
        {
           MemberinfoEntity data = null;
            if (!string.IsNullOrEmpty(keyValue))
            {
            data = await _service.GetForm(keyValue);
            }
            try
            {
                await _service.DeleteForm(keyValue);
                return await Success("操作成功。", className, data, data, keyValue, DbLogType.Delete);
            }
            catch (Exception ex)
            {
                return await Error(ex.Message, className, data, data, keyValue, DbLogType.Delete);
            }
        }
        #endregion
    }
}
