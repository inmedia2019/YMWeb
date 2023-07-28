﻿using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using YMWeb.Code;
using YMWeb.Domain.ContentManage;
using YMWeb.Service;
using Microsoft.AspNetCore.Authorization;
using YMWeb.Service.ContentManage;
using YMWeb.Service.GenerateService;
using YMWeb.Service.DictionaryDataBase;
using YMWeb.Code.Web.SelectTree;
using System.Collections;

namespace YMWeb.Web.Areas.ContentManage.Controllers
{
    /// <summary>
    /// 创 建：超级管理员
    /// 日 期：2020-12-23 14:41
    /// 描 述：CMS内容管理控制器类
    /// </summary>
    [Area("ContentManage")]
    public class ContentController : ControllerBase
    {
        private string className = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName.Split('.')[5];
        public ContentService _service { get; set; }
        public ChannelService _channelservice { get; set; }
        public CityInfoService _cityInfoservice { get; set; }
        public TemplateService _templateservice { get; set; }
        public ChannelManagerCache _channelManagerCache { get; set; }
        public LableService _lableservice { get; set; }
        public ContentLableService _contentLableservice { get; set; }
        public ExpertService _expertservice { get; set; }
        public override ActionResult Form()
        {
            //控制器视图传值示例
            if (_service.currentuser.UserId == null)
            {
                return View();
            }
            var keyValue = HttpContext.Request.Query["keyValue"].ToString();
            var itemId = HttpContext.Request.Query["itemId"].ToString();
            if (!string.IsNullOrEmpty(itemId))
            {
                ViewBag.ChannelId = itemId;
                ViewBag.ChannelName = _channelservice.GetForm(itemId).Result.F_ChannelName;
            }
            else
            {
                ViewBag.ChannelId = "";
                ViewBag.ChannelName = "";
            }
            var data1 = _lableservice.GetList();
            var treeList = new List<SelectTreeModel>();
            foreach (var item in data1.Result)
            {
                //此处需修改
                SelectTreeModel treeModel = new SelectTreeModel();
                treeModel.value = item.F_Id;
                treeModel.name = item.F_Name;
                treeModel.parentId = item.F_ParentId;
                treeList.Add(treeModel);
            }
            ViewBag.lable = treeList.TreeGridJson();

            var dataCity = _cityInfoservice.GetList();
            var treeListCity = new List<SelectTreeModel>();
            foreach (var item in dataCity.Result)
            {
                //此处需修改
                SelectTreeModel treeModel = new SelectTreeModel();
                treeModel.value = item.F_Id;
                treeModel.name = item.F_CityName;
                treeListCity.Add(treeModel);
            }
            ViewBag.cityInfo = treeListCity.TreeGridJson();

            var dataContentLable = _contentLableservice.GetList();
            var treeContentLable = new List<SelectTreeModel>();
            foreach (var item in dataContentLable.Result)
            {
                //此处需修改
                SelectTreeModel treeModel = new SelectTreeModel();
                treeModel.value = item.F_Id;
                treeModel.name = item.F_Name;
                treeModel.parentId = item.F_ParentId;
                treeContentLable.Add(treeModel);
            }
            ViewBag.contentlable = treeContentLable.TreeGridJson();

            var data2 = _expertservice.GetList();
            var treeList2 = new List<SelectTreeModel>();
            foreach (var item in data2.Result)
            {
                //此处需修改
                SelectTreeModel treeModel = new SelectTreeModel();
                treeModel.value = item.F_Id;
                treeModel.name = item.F_Name;
                treeList2.Add(treeModel);
            }

            ViewBag.expert = treeList2.TreeList();


            var data3 = _channelservice.GetList();
            var treeList3 = new List<SelectTreeModel>();
            foreach (var item in data3.Result)
            {
                //此处需修改
                SelectTreeModel treeModel = new SelectTreeModel();
                treeModel.value = item.F_Id;
                treeModel.name = item.F_ChannelName;
                treeModel.parentId = item.F_ParentId;
                treeList3.Add(treeModel);
            }
            ViewBag.channel = treeList3.TreeGridJson();


            ViewBag.Content = _service.GetForm(keyValue).Result.ToJson();
            return View();
        }
        public override ActionResult Form2()
        {

            //控制器视图传值示例
            if (_service.currentuser.UserId == null)
            {
                return View();
            }
            var keyValue = HttpContext.Request.Query["keyValue"].ToString();
            var itemId = HttpContext.Request.Query["itemId"].ToString();
            if (!string.IsNullOrEmpty(itemId))
            {
                ViewBag.ChannelId = itemId;
                ViewBag.ChannelName = _channelservice.GetForm(itemId).Result.F_ChannelName;
            }
            else
            {
                ViewBag.ChannelId = "";
                ViewBag.ChannelName = "";
            }

            var data1 = _lableservice.GetList();
            var treeList = new List<SelectTreeModel>();
            foreach (var item in data1.Result)
            {
                //此处需修改
                SelectTreeModel treeModel = new SelectTreeModel();
                treeModel.value = item.F_Id;
                treeModel.name = item.F_Name;
                treeModel.parentId = item.F_ParentId;
                treeList.Add(treeModel);
            }
            ViewBag.lable = treeList.TreeGridJson();

            var data2 = _expertservice.GetList();
            var treeList2 = new List<SelectTreeModel>();
            foreach (var item in data2.Result)
            {
                //此处需修改
                SelectTreeModel treeModel = new SelectTreeModel();
                treeModel.value = item.F_Id;
                treeModel.name = item.F_Name;
                treeList2.Add(treeModel);
            }

            ViewBag.expert = treeList2.TreeList();

            var data3 = _channelservice.GetList();
            var treeList3 = new List<SelectTreeModel>();
            foreach (var item in data3.Result)
            {
                //此处需修改
                SelectTreeModel treeModel = new SelectTreeModel();
                treeModel.value = item.F_Id;
                treeModel.name = item.F_ChannelName;
                treeModel.parentId = item.F_ParentId;
                treeList3.Add(treeModel);
            }

            var dataCity = _cityInfoservice.GetList();
            var treeListCity = new List<SelectTreeModel>();
            foreach (var item in dataCity.Result)
            {
                //此处需修改
                SelectTreeModel treeModel = new SelectTreeModel();
                treeModel.value = item.F_Id;
                treeModel.name = item.F_CityName;
                treeListCity.Add(treeModel);
            }
            ViewBag.cityInfo = treeListCity.TreeList();

            var dataContentLable = _contentLableservice.GetList();
            var treeContentLable = new List<SelectTreeModel>();
            foreach (var item in dataContentLable.Result)
            {
                //此处需修改
                SelectTreeModel treeModel = new SelectTreeModel();
                treeModel.value = item.F_Id;
                treeModel.name = item.F_Name;
                treeModel.parentId = item.F_ParentId;
                treeContentLable.Add(treeModel);
            }
            ViewBag.contentlable = treeContentLable.TreeGridJson();

            ViewBag.channel = treeList3.TreeGridJson();
            ViewBag.Content = _service.GetForm(keyValue).Result.ToJson();
            return View();
        }
        public override ActionResult Form3()
        {
            //控制器视图传值示例
            if (_service.currentuser.UserId == null)
            {
                return View();
            }
            var keyValue = HttpContext.Request.Query["keyValue"].ToString();
            var itemId = HttpContext.Request.Query["itemId"].ToString();
            if (!string.IsNullOrEmpty(itemId))
            {
                ViewBag.ChannelId = itemId;
                ViewBag.ChannelName = _channelservice.GetForm(itemId).Result.F_ChannelName;
            }
            else
            {
                ViewBag.ChannelId = "";
                ViewBag.ChannelName = "";
            }

            var data1 = _lableservice.GetList();
            var treeList = new List<SelectTreeModel>();
            foreach (var item in data1.Result)
            {
                //此处需修改
                SelectTreeModel treeModel = new SelectTreeModel();
                treeModel.value = item.F_Id;
                treeModel.name = item.F_Name;
                treeModel.parentId = item.F_ParentId;
                treeList.Add(treeModel);
            }
            ViewBag.lable = treeList.TreeGridJson();

            var data2 = _expertservice.GetList();
            var treeList2 = new List<SelectTreeModel>();
            foreach (var item in data2.Result)
            {
                //此处需修改
                SelectTreeModel treeModel = new SelectTreeModel();
                treeModel.value = item.F_Id;
                treeModel.name = item.F_Name;
                treeList2.Add(treeModel);
            }

            ViewBag.expert = treeList2.TreeList();

            var data3 = _channelservice.GetList();
            var treeList3 = new List<SelectTreeModel>();
            foreach (var item in data3.Result)
            {
                //此处需修改
                SelectTreeModel treeModel = new SelectTreeModel();
                treeModel.value = item.F_Id;
                treeModel.name = item.F_ChannelName;
                treeModel.parentId = item.F_ParentId;
                treeList3.Add(treeModel);
            }
            ViewBag.channel = treeList3.TreeGridJson();
            ViewBag.Content = _service.GetForm(keyValue).Result.ToJson();
            return View();
        }

        public override ActionResult Form4()
        {
            //控制器视图传值示例
            if (_service.currentuser.UserId == null)
            {
                return View();
            }
            var keyValue = HttpContext.Request.Query["keyValue"].ToString();
            var itemId = HttpContext.Request.Query["itemId"].ToString();
            if (!string.IsNullOrEmpty(itemId))
            {
                ViewBag.ChannelId = itemId;
                ViewBag.ChannelName = _channelservice.GetForm(itemId).Result.F_ChannelName;
            }
            else
            {
                ViewBag.ChannelId = "";
                ViewBag.ChannelName = "";
            }

            var data1 = _lableservice.GetList();
            var treeList = new List<SelectTreeModel>();
            foreach (var item in data1.Result)
            {
                //此处需修改
                SelectTreeModel treeModel = new SelectTreeModel();
                treeModel.value = item.F_Id;
                treeModel.name = item.F_Name;
                treeModel.parentId = item.F_ParentId;
                treeList.Add(treeModel);
            }
            ViewBag.lable = treeList.TreeGridJson();

            var data2 = _expertservice.GetList();
            var treeList2 = new List<SelectTreeModel>();
            foreach (var item in data2.Result)
            {
                //此处需修改
                SelectTreeModel treeModel = new SelectTreeModel();
                treeModel.value = item.F_Id;
                treeModel.name = item.F_Name;
                treeList2.Add(treeModel);
            }

            ViewBag.expert = treeList2.TreeList();

            var data3 = _channelservice.GetList();
            var treeList3 = new List<SelectTreeModel>();
            foreach (var item in data3.Result)
            {
                //此处需修改
                SelectTreeModel treeModel = new SelectTreeModel();
                treeModel.value = item.F_Id;
                treeModel.name = item.F_ChannelName;
                treeModel.parentId = item.F_ParentId;
                treeList3.Add(treeModel);
            }
            ViewBag.channel = treeList3.TreeGridJson();
            ViewBag.Content = _service.GetForm(keyValue).Result.ToJson();
            return View();
        }

        public override ActionResult Form6()
        {
            //控制器视图传值示例
            if (_service.currentuser.UserId == null)
            {
                return View();
            }
            var keyValue = HttpContext.Request.Query["keyValue"].ToString();
            var itemId = HttpContext.Request.Query["itemId"].ToString();
            if (!string.IsNullOrEmpty(itemId))
            {
                ViewBag.ChannelId = itemId;
                ViewBag.ChannelName = _channelservice.GetForm(itemId).Result.F_ChannelName;
            }
            else
            {
                ViewBag.ChannelId = "";
                ViewBag.ChannelName = "";
            }

            var data1 = _lableservice.GetList();
            var treeList = new List<SelectTreeModel>();
            foreach (var item in data1.Result)
            {
                //此处需修改
                SelectTreeModel treeModel = new SelectTreeModel();
                treeModel.value = item.F_Id;
                treeModel.name = item.F_Name;
                treeModel.parentId = item.F_ParentId;
                treeList.Add(treeModel);
            }
            ViewBag.lable = treeList.TreeGridJson();

            var data2 = _expertservice.GetList();
            var treeList2 = new List<SelectTreeModel>();
            foreach (var item in data2.Result)
            {
                //此处需修改
                SelectTreeModel treeModel = new SelectTreeModel();
                treeModel.value = item.F_Id;
                treeModel.name = item.F_Name;
                treeList2.Add(treeModel);
            }

            ViewBag.expert = treeList2.TreeList();

            var data3 = _channelservice.GetList();
            var treeList3 = new List<SelectTreeModel>();
            foreach (var item in data3.Result)
            {
                //此处需修改
                SelectTreeModel treeModel = new SelectTreeModel();
                treeModel.value = item.F_Id;
                treeModel.name = item.F_ChannelName;
                treeModel.parentId = item.F_ParentId;
                treeList3.Add(treeModel);
            }
            ViewBag.channel = treeList3.TreeGridJson();
            ViewBag.Content = _service.GetForm(keyValue).Result.ToJson();
            return View();
        }
        #region 获取数据
        [HttpGet]
        [HandlerAjaxOnly]
        public async Task<ActionResult> GetGridJson(SoulPage<ContentEntity> pagination, string itemId, string keyword)
        {
            if (string.IsNullOrEmpty(pagination.field))
            {
                pagination.field = "F_CreatorTime";
                pagination.order = "desc";
            }
            var data = await _service.GetLookList(pagination, itemId, keyword);
            foreach (ContentEntity c in data)
            {
                if (!string.IsNullOrEmpty(c.F_Author))
                {
                    var arr = c.F_Author.Split(',');
                    ArrayList strTemps = new ArrayList();
                    foreach (string au in arr)
                    {
                        var expertInfo = _expertservice.GetForm(au).Result;
                        if (expertInfo != null)
                        {
                            strTemps.Add(expertInfo.F_Name);
                        }
                    }
                    c.F_Author = string.Join(",", strTemps.ToArray());
                }
                if (!string.IsNullOrEmpty(c.F_Tags))
                {
                    var arr2 = c.F_Tags.Split(',');
                    ArrayList strTemps2 = new ArrayList();
                    foreach (string ta in arr2)
                    {
                        var lableInfo = _lableservice.GetForm(ta).Result;
                        if (lableInfo != null)
                        {
                            strTemps2.Add(lableInfo.F_Name);
                        }
                    }
                    c.F_Tags = string.Join(",", strTemps2.ToArray());
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
        public async Task<ActionResult> SubmitForm(ContentEntity entity, string keyValue)
        {
            ContentEntity data = null;
            if (!string.IsNullOrEmpty(keyValue))
            {
                data = await _service.GetForm(keyValue);
            }
            try
            {
                if (!string.IsNullOrEmpty(entity.F_Content))
                {
                    entity.F_Content = entity.F_Content.Replace("\n", string.Empty).Replace("\r", string.Empty).Replace("\t", string.Empty).Replace("\"", "\\\"");
                }
                else
                {
                    entity.F_Content = "";
                }
                if (!string.IsNullOrEmpty(entity.F_LiveIntroduction))
                {
                    entity.F_LiveIntroduction = entity.F_LiveIntroduction.Replace("\n", string.Empty).Replace("\r", string.Empty).Replace("\t", string.Empty).Replace("\"", "\\\"");
                }
                else
                {
                    entity.F_LiveIntroduction = "";
                }
                if (!string.IsNullOrEmpty(entity.F_WonderfulContent))
                {
                    entity.F_WonderfulContent = entity.F_WonderfulContent.Replace("\n", string.Empty).Replace("\r", string.Empty).Replace("\t", string.Empty).Replace("\"", "\\\"");
                }
                else
                {
                    entity.F_WonderfulContent = "";
                }
                if (string.IsNullOrEmpty(entity.F_Summary))
                {
                    entity.F_Summary = "";
                }
                if (string.IsNullOrEmpty(entity.F_Summary) && !string.IsNullOrEmpty(entity.F_Content))
                {
                    entity.F_Summary = YMWeb.Code.TextHelper.GetSubString(YMWeb.Code.WebHelper.NoHtml(entity.F_Content), 255);
                }
                if (string.IsNullOrEmpty(entity.F_SubTitle))
                {
                    entity.F_SubTitle = entity.F_Titile;
                }
                if (!string.IsNullOrEmpty(entity.F_LiveBroadcast))
                {
                    entity.F_LiveBroadcast = entity.F_LiveBroadcast.Replace("\n", string.Empty).Replace("\r", string.Empty).Replace("\t", string.Empty);
                }
                await _service.SubmitForm(entity, keyValue);
                await _channelManagerCache.SetChannelLink(entity.F_ChannelId, entity.F_Id);
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
            ContentEntity data = null;
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

        [HttpPost]
        [HandlerAjaxOnly]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> PublishForm(string keyValue)
        {
            ContentEntity data = null;
            if (!string.IsNullOrEmpty(keyValue))
            {
                data = await _service.GetForm(keyValue);
            }
            try
            {
                await _service.PublishForm(keyValue);
                return await Success("，发布操作成功。", className, data, data, keyValue);
            }
            catch (Exception ex)
            {
                return await Error(ex.Message, className, data, data, keyValue);
            }
        }
        [HttpPost]
        [HandlerAjaxOnly]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> RecycleForm(string keyValue)
        {
            ContentEntity data = null;
            if (!string.IsNullOrEmpty(keyValue))
            {
                data = await _service.GetForm(keyValue);
            }
            try
            {
                await _service.RecycleForm(keyValue);
                return await Success("，下架操作成功。", className, data, data, keyValue);
            }
            catch (Exception ex)
            {
                return await Error(ex.Message, className, data, data, keyValue);
            }
        }
        #endregion
    }
}
