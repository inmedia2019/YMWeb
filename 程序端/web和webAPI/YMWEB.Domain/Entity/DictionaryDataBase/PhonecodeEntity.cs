using System;
using Chloe.Annotations;

namespace YMWeb.Domain.DictionaryDataBase
{
    /// <summary>
    /// 创 建：超级管理员
    /// 日 期：2022-05-30 12:09
    /// 描 述：手机验证码实体类
    /// </summary>
    [TableAttribute("web_phonecode")]
    public class PhonecodeEntity : IEntity<PhonecodeEntity>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [ColumnAttribute("F_Id", IsPrimaryKey = true)]
        public string F_Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string phone { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string resultInfo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DateTime? createDate { get; set; }
    }
}
