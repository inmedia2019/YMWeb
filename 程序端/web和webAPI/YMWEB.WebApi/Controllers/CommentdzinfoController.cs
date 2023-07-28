using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YMWeb.Domain.DictionaryDataBase;
using YMWeb.Domain.InfoManage;
using YMWeb.Service.DictionaryDataBase;
using YMWeb.Service.InfoManage;
using YMWeb.WebApi.Models;
using YMWeb.WebApi.Tools;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace YMWeb.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentdzinfoController : ControllerBase
    {
        public MemberinfoService _minfoService { get; set; }

        public CommentdzinfoService _commentdzService { get; set; }

        public CommentinfoService _commentService { get; set; }

        /// <summary>
        /// 新增用户评论点赞
        /// </summary>
        /// <param name="mid">当前用户ID</param>
        /// <param name="infoId">信息ID</param>
        /// <param name="commentId">评论ID</param>
        /// <returns></returns>
        [HttpGet("AddCommentDZ")]
        public async Task<ReturnType<ReturnCommentdzInfo>> AddCommentDZ(string mid = "", string infoId = "", string commentId="")
        {
            MemberinfoEntity minfo = await _minfoService.GetUserInfoByMid(mid);

            string actionId = "";
            ReturnCommentdzInfo rinfo = new ReturnCommentdzInfo();

            //是否已经点赞
            int count = await _commentdzService.GetListCountByCommentId(commentId, mid);
            if (count > 0)
            {
                rinfo.actionId = "";
                rinfo.msg = "您已经点赞！";
                return Util.getReturnObjectInfo(rinfo, "", false);
            }

            CommentdzinfoEntity dzInfo = new CommentdzinfoEntity();
            dzInfo.commentId = commentId;
            dzInfo.createDate = DateTime.Now;
            dzInfo.Id = "";
            dzInfo.infoId = infoId;
            dzInfo.mid = mid;
            dzInfo.morecol = "";
            dzInfo.morecol1 = "";
            dzInfo.state = 0;
            actionId = await _commentdzService.SubmitForm(dzInfo, "");


            CommentinfoEntity pareInfo = await _commentService.GetInfoById(commentId);
            pareInfo.dzNum = pareInfo.dzNum + 1;
            await _commentService.SubmitForm(pareInfo, pareInfo.Id);

            rinfo.actionId = actionId;
            rinfo.msg = "OK";
            return Util.getReturnObjects(rinfo, "true");

        }

        public class ReturnCommentdzInfo
        {
            public string actionId { get; set; }
            public string msg { get; set; }
        }
    }
}
