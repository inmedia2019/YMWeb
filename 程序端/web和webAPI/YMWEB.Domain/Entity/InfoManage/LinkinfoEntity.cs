using System;
using Chloe.Annotations;

namespace YMWeb.Domain.InfoManage
{
    /// <summary>
    /// 创 建：超级管理员
    /// 日 期：2022-09-26 19:29
    /// 描 述：渠道链接实体类
    /// </summary>
    [TableAttribute("web_linkinfo")]
    public class LinkinfoEntity
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
        public string F_title { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string F_LinkUrl { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string descript { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string moreCol { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string moreCol1 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DateTime? createDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string ewmImg { get; set; }
    }
}
