using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using YMWeb.Code;
using YMWeb.Domain.ContentManage;
using YMWeb.Service;
using Microsoft.AspNetCore.Authorization;
using YMWeb.Service.ContentManage;
using YMWeb.Domain.SystemManage;
using YMWeb.Service.SystemManage;

namespace YMWeb.Web.Areas.ContentManage.Controllers
{
    /// <summary>
    /// 创 建：超级管理员
    /// 日 期：2020-12-23 16:52
    /// 描 述：CMS栏目管理控制器类
    /// </summary>
    [Area("ContentManage")]
    public class ChannelController :  ControllerBase
    {
        private string className = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName.Split('.')[5];
        public ChannelService _service {get;set;}
        public ContentService _contentservice { get; set; }
        public TemplateService _templateservice { get; set; }
        public SourceService _sourceservice { get; set; }

        #region 获取数据
        [HttpGet]
        [HandlerAjaxOnly]
        public async Task<ActionResult> GetTreeGridJson(string keyword)
        {
            var data = await _service.GetLookList(keyword);
            if (!string.IsNullOrEmpty(keyword))
            {
                 //此处需修改
                 data = data.TreeWhere(t => t.F_ChannelName.Contains(keyword));
            }
            data = data.TreeWhere(t => t.F_ContentTemplate != "");
            foreach (ChannelEntity c in data)
            {
                if (!string.IsNullOrEmpty(c.F_ContentTemplate))
                {
                    c.F_FileContent = _templateservice.GetForm(c.F_ContentTemplate).Result.F_FileContent;
                }
            }

            var treeList = new List<TreeGridModel>();
            foreach (var item in data)
            {
                TreeGridModel treeModel = new TreeGridModel();
                treeModel.id = item.F_Id;
                treeModel.title = item.F_ChannelName;
                treeModel.parentId = item.F_ParentId;
                treeModel.code = item.F_FileContent;
                treeModel.checkArr = "0";
                //treeModel.self = item;
                treeList.Add(treeModel);
            }
            return ResultDTree(treeList.TreeList());
        }
        [HttpGet]
        [HandlerAjaxOnly]
        public async Task<ActionResult> GetGridJson(string keyword)
        {
            var data = await _service.GetLookList();
            foreach (ChannelEntity c in data)
            {
                c.F_Number = await _contentservice.GetListCountByChannelId(c.F_Id);
            }
            if (!string.IsNullOrEmpty(keyword))
            {
                data = data.TreeWhere(t => t.F_ChannelName.Contains(keyword));
            }
            return Success(data.Count, data);
        }

        [HttpGet]
        [HandlerAjaxOnly]
        public async Task<ActionResult> GetTreeSelectJson()
        {
            var data = await _service.GetList();
            var treeList = new List<TreeSelectModel>();
            foreach (var item in data)
            {
                //此处需修改
                TreeSelectModel treeModel = new TreeSelectModel();
                treeModel.id = item.F_Id;
                treeModel.text = item.F_ChannelName;
                treeModel.parentId = item.F_ParentId;
                treeList.Add(treeModel);
            }
            return Content(treeList.TreeSelectJson());
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
        public async Task<ActionResult> SubmitForm(ChannelEntity entity, string keyValue)
        {
            ChannelEntity data = null;
            if (!string.IsNullOrEmpty(keyValue))
            {
                data = await _service.GetForm(keyValue);
            }
            try
            {
                await _service.SubmitForm(entity, keyValue);
                SourceEntity sentity = new SourceEntity
                {
                    F_Id = entity.F_Id,
                    F_Name = entity.F_ChannelName,
                    F_EnabledMark = entity.F_EnabledMark,
                    F_DeleteMark = entity.F_DeleteMark,
                    F_CreatorUserId = entity.F_CreatorUserId,
                    F_CreatorTime = entity.F_CreatorTime,
                    F_LastModifyUserId = entity.F_LastModifyUserId,
                    F_LastModifyTime = entity.F_LastModifyTime,
                    F_DeleteUserId = entity.F_DeleteUserId,
                    F_DeleteTime = entity.F_DeleteTime,
                    F_ParentId = entity.F_ParentId,
                    F_FrontLink = entity.F_FrontLink,
                    F_Type = "1001",
                    F_Link = ""
                };
                await _sourceservice.SubmitForm(sentity, keyValue);
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
            ChannelEntity data = null;
            if (!string.IsNullOrEmpty(keyValue))
            {
                data = await _service.GetForm(keyValue);
            }
            try
            {
                await _sourceservice.DeleteForm(keyValue);
                await _service.DeleteForm(keyValue);
                return await Success("操作成功。", className, data, data, keyValue, DbLogType.Delete);
            }
            catch (Exception ex)
            {
                return await Error(ex.Message, className, data, data, keyValue, DbLogType.Delete);
            }
        }
        /// <summary>
        /// 选择栏目内容属性
        /// </summary>
        /// <returns></returns>
        public ActionResult Choose()
        {
            return View();
        }
        #endregion
    }
}
