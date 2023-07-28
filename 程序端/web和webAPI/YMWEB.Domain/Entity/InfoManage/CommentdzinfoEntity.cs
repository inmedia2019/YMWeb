using System;
using Chloe.Annotations;

namespace YMWeb.Domain.InfoManage
{
    /// <summary>
    /// 创 建：超级管理员
    /// 日 期：2022-05-27 14:42
    /// 描 述：评论点赞实体类
    /// </summary>
    [TableAttribute("web_commentdzinfo")]
    public class CommentdzinfoEntity
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string commentId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DateTime? createDate { get; set; }
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
        public string infoId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string mid { get; set; }
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
        public int? state { get; set; }
    }
}
