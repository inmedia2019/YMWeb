﻿using System;
using System.ComponentModel;
using Chloe.Annotations;

namespace YMWeb.Domain.SystemSecurity
{
    /// <summary>
	/// 定时任务
	/// </summary>
    [Table("sys_openjob")]
    public partial class OpenJobEntity : IEntity<OpenJobEntity>, ICreationAudited, IDeleteAudited, IModificationAudited
    {
        [ColumnAttribute("F_Id", IsPrimaryKey = true)]
        public string F_Id { get; set; }
        /// <summary>
        /// 任务名称
        /// </summary>
        [Description("任务名称")]
        public string F_JobName { get; set; }
        /// <summary>
        /// 任务组别
        /// </summary>
        [Description("任务组别")]
        public string F_JobGroup { get; set; }
        /// <summary>
        /// 文件名称
        /// </summary>
        [Description("文件名称")]
        public string F_FileName { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        [Description("开始时间")]
        public System.DateTime? F_StarRunTime { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        [Description("结束时间")]
        public System.DateTime? F_EndRunTime { get; set; }
        /// <summary>
        /// 最近执行时间
        /// </summary>
        [Description("最近执行时间")]
        public System.DateTime? F_LastRunTime { get; set; }
        /// <summary>
        /// CRON表达式
        /// </summary>
        [Description("CRON表达式")]
        public string F_CronExpress { get; set; }
        public bool? F_DeleteMark { get; set; }
        public bool? F_EnabledMark { get; set; }
        public string F_Description { get; set; }
        public DateTime? F_CreatorTime { get; set; }
        public string F_CreatorUserId { get; set; }
        public DateTime? F_LastModifyTime { get; set; }
        public string F_LastModifyUserId { get; set; }
        public DateTime? F_DeleteTime { get; set; }
        public string F_DeleteUserId { get; set; }
    }
}