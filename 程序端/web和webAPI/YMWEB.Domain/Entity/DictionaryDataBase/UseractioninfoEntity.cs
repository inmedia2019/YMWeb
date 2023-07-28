﻿using System;
using Chloe.Annotations;

namespace YMWeb.Domain.DictionaryDataBase
{
    /// <summary>
    /// 创 建：超级管理员
    /// 日 期：2022-05-04 19:08
    /// 描 述：积分记录实体类
    /// </summary>
    [TableAttribute("web_useractioninfo")]
    public class UseractioninfoEntity
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
        public string nid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string PID { get; set; }
        /// <summary>
        /// 获取积分数
        /// </summary>
        /// <returns></returns>
        public int? scoreNum { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string infoid { get; set; }
        /// <summary>
        /// 0：浏览 1：积分
        /// </summary>
        /// <returns></returns>
        public int? tid { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string vContent { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string ipadress { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string lurl { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int? state { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string descript { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DateTime? createDate { get; set; }
        /// <summary>
      
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
        public string SpecialData { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string InternalData { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        /// <returns></returns>
        public string trueName { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        /// <returns></returns>
        public string Phone { get; set; }

      
    }
}
