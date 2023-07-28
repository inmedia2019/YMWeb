using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YMWeb.Code;
using YMWeb.Domain.ContentManage;
using YMWeb.Domain.DictionaryDataBase;
using YMWeb.Domain.InfoManage;
using YMWeb.Service.ContentManage;
using YMWeb.Service.DictionaryDataBase;
using YMWeb.Service.InfoManage;
using YMWeb.WebApi.Models;
using YMWeb.WebApi.Tools;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace YMWeb.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentInfoController : ControllerBase
    {

        public CommentinfoService _commentinfoService { get; set; }

        public MemberinfoService _minfoService { get; set; }

        public UseractioninfoService _actionInfoService { get; set; }

        public ContentService _contentService { get; set; }

        public CommentdzinfoService _commentdzinfoService { get; set; }

        /// <summary>
        /// 根据信息ID获取评论信息
        /// </summary>
        /// <param name="infoId">信息ID</param>
        /// <param name="mid">用户ID</param>
        /// <returns></returns>
        [HttpGet("GetCommentByInfoId")]
        public async Task<ReturnTypeList<CommentinfoEntity>> GetCommentByInfoId(string infoId = "", string mid = "")
        {
            int getChildCount = 0;
            var menuAll = await _commentinfoService.GetListByInfoId(infoId);

            var menuRoot = menuAll.Where(p => p.pid == "");


            // 为一级菜单设置子菜单，getChild是递归调用的
            foreach (var item in menuRoot)
            {
                item.Child = GetChild(item.Id, menuAll.ToList(), 1, getChildCount);
                item.IsDz = await _commentdzinfoService.GetListCountByCommentId(item.Id, mid);
            }

            return Util.getReturnObjectByList(menuRoot);

        }
        private List<CommentinfoEntity> GetChild(string id, List<CommentinfoEntity> menuAll, int excouteCout, int getChildCount)
        {
            if (getChildCount > 0 && excouteCout > getChildCount)
            {
                return null;
            }
            //子菜单
            List<CommentinfoEntity> childList = new List<CommentinfoEntity>();
            // 遍历所有节点，将父菜单id与传过来的id比较
            var list = menuAll.Where(x => x.pid == id).ToList();
            if (!list.Any())
            {
                return null;
            }
            foreach (var item in list)
            {
                if (item.pid == id)
                {
                    childList.Add(new CommentinfoEntity
                    {
                        Id = item.Id,
                        pid = item.pid,
                        trueName = item.trueName,
                        headPic = GlobalContext.SystemConfig.url + item.headPic,
                        sendDescript = item.sendDescript,
                        createDate = item.createDate,
                        dzNum = item.dzNum,
                        bid = item.bid
                    });
                }
            }

            foreach (var item in childList)
            {
                item.Child = GetChild(item.Id, menuAll, excouteCout + 1, getChildCount);
            }
            // 递归退出条件
            if (childList.Count == 0)
            {
                return null;
            }
            return childList;
        }


        /// <summary>
        /// 用户评论
        /// </summary>
        [HttpPost("SetCommentInfo")]
        public async Task<ReturnType<ReturnCommentInfo>> SetCommentInfo([FromBody] CommentRequestEntity infos)
        {

            string actionId = "";
            MemberinfoEntity minfo = await _minfoService.GetUserInfoByMid(infos.mid);


            CommentinfoEntity cinfo = new CommentinfoEntity();
            cinfo.bid = 0;
            cinfo.Child = null;
            cinfo.createDate = DateTime.Now;
            cinfo.dzNum = 0;
            cinfo.headPic = "";
            cinfo.Id = Guid.NewGuid().ToString();
            cinfo.infoId = infos.infoId;
            cinfo.mHeadImg = infos.headPic;
            cinfo.mid = infos.mid;
            cinfo.mName = infos.trueName;
            cinfo.morecol = "";
            cinfo.morecol1 = "";
            cinfo.picUrl = "";
            cinfo.pid = infos.pid;
            cinfo.replyDescript = "";
            cinfo.sendDescript = infos.content;
            cinfo.state = 0;
            cinfo.title = infos.infoTitle;
            cinfo.trueName = infos.trueName;
            actionId = await _commentinfoService.SubmitForm(cinfo, "");

            //更新评论的数量
            if (infos.pid.Length > 0)
            {
                CommentinfoEntity pInfo = await _commentinfoService.GetInfoById(infos.pid);
                pInfo.bid = pInfo.bid + 1;
                await _commentinfoService.SubmitForm(pInfo, pInfo.Id);
            }
            else {
                var dataInfo = await _contentService.GetInfoById(infos.infoId);
                dataInfo.F_CommentCount = dataInfo.F_CommentCount + 1;
                await _contentService.SubmitForm(dataInfo, infos.infoId);
            }

            UseractioninfoEntity info = new UseractioninfoEntity();
            info.createDate = DateTime.Now;
            info.descript = "";
            info.Id = "";
            info.infoid = "";
            info.InternalData = "";
            info.ipadress = "";
            info.lurl = infos.url;
            info.mid = infos.mid;
            info.moreCol = ""; 
            info.moreCol1 = "";
            info.nid = "";
            info.Phone = minfo.phone;
            info.PID = "";
            info.scoreNum = 0;
            info.SpecialData = "";
            info.state = 0;
            info.tid = 3;
            info.trueName = minfo.trueName;
            info.vContent = "";

            await _actionInfoService.SubmitForm(info, "");

            ReturnCommentInfo rinfo = new ReturnCommentInfo();
            rinfo.actionId = actionId;
       

            if (actionId != "")
            {

             
                return Util.getReturnObjects(rinfo, "true");
            }
            else
            {
               
                return Util.getReturnObjects(rinfo, "");
            }

        }

    }

    public class ReturnCommentInfo
    {
        public string actionId { get; set; }
    }

    public class CommentRequestEntity
    {
       
        /// <summary>
        /// 用户ID
        /// </summary>
        public string mid { get; set; }
        /// <summary>
        /// 评论内容
        /// </summary>
        public string content { get; set; }
        /// <summary>
        /// 信息ID
        /// </summary>
        public string infoId { get; set; }
        /// <summary>
        /// 信息标题
        /// </summary>
        public string infoTitle { get; set; }
        /// <summary>
        /// 父级评论ID
        /// </summary>
        public string pid { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string trueName { get; set; }
        /// <summary>
        /// 图片
        /// </summary>
        public string headPic { get; set; }
        /// <summary>
        /// 页面url
        /// </summary>
        public string url { get; set; }
    }


}
