using System;
using System.Collections.Generic;
using Chloe.Annotations;

namespace YMWeb.Domain.InfoManage
{
    /// <summary>
    /// 创 建：超级管理员
    /// 日 期：2022-05-27 11:23
    /// 描 述：评论信息实体类
    /// </summary>
    [TableAttribute("web_commentinfo")]
    public class CommentinfoEntity
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [ColumnAttribute("Id", IsPrimaryKey = true)]
        public string Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string mid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string infoId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string pid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string title { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string picUrl { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string sendDescript { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int? state { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DateTime? createDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string morecol { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string morecol1 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string mName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string mHeadImg { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string replyDescript { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int? dzNum { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int? bid { get; set; }

        [NotMapped]
        public string trueName { get; set; }
        [NotMapped]
        public string headPic { get; set; }
        [NotMapped]
        public List<CommentinfoEntity> Child { get; set; }
        [NotMapped]
        public int IsDz { get; set; }
    }
}
