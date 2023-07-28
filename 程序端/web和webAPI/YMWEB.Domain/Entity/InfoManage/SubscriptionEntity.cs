using System;
using Chloe.Annotations;

namespace YMWeb.Domain.InfoManage
{
    /// <summary>
    /// 创 建：超级管理员
    /// 日 期：2022-05-26 14:57
    /// 描 述：订阅信息实体类
    /// </summary>
    [TableAttribute("web_subscription")]
    public class SubscriptionEntity
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DateTime? CreateTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [ColumnAttribute("ID", IsPrimaryKey = true)]
        public string ID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string InfoId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int? IsSend { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string MainLecturer { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string OpenId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string Page { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string QuestionLabel { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int? State { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string Time { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string Unionid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string UserId { get; set; }
    }
}
