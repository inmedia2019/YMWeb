﻿using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using YMWeb.Code;
using YMWeb.Domain.SystemOrganize;
using YMWeb.Service;
using YMWeb.Service.SystemOrganize;
using Newtonsoft.Json;

namespace YMWeb.Web.Areas.SystemOrganize.Controllers
{
    /// <summary>
    /// 创 建：超级管理员
    /// 日 期：2020-06-01 09:44
    /// 描 述：数据权限控制器类
    /// </summary>
    [Area("SystemOrganize")]
    public class DataPrivilegeRuleController :  ControllerBase
    {
        private string className = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName.Split('.')[5];
        public DataPrivilegeRuleService _service { get; set; }

        #region 获取数据
        [HttpGet]
        [HandlerAjaxOnly]
        public async Task<ActionResult> GetGridJson(Pagination pagination, string keyword)
        {
            //此处需修改
            pagination.order = "desc";
            pagination.sort = "F_CreatorTime desc";
            //导出全部页使用
            if (pagination.rows == 0 && pagination.page == 0)
            {
                pagination.rows = 99999999;
                pagination.page = 1;
            }
            var data = await _service.GetLookList(pagination,keyword);
            return Success(pagination.records, data);
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
        [HttpGet]
        public virtual ActionResult RuleForm()
        {
            return View();
        }
        #endregion

        #region 提交数据
        [HttpPost]
        [HandlerAjaxOnly]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SubmitForm(DataPrivilegeRuleEntity entity,string listData, string keyValue)
        {
            DataPrivilegeRuleEntity data = null;
            if (!string.IsNullOrEmpty(keyValue))
            {
                data = await _service.GetForm(keyValue);
            }
            var filterList = JsonConvert.DeserializeObject<List<FilterList>>(listData);
            foreach (var item in filterList)
            {
                if (!string.IsNullOrEmpty(item.Description))
                {
                    entity.F_Description += item.Description+",";
                }
            }
            if (!string.IsNullOrEmpty(entity.F_Description))
            {
                entity.F_Description = entity.F_Description.Substring(0, entity.F_Description.Length - 1);
            }
            entity.F_PrivilegeRules = filterList.ToJson();
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
            DataPrivilegeRuleEntity data = null;
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
