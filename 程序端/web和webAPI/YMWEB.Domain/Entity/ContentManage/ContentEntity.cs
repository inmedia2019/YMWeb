using System;
using Chloe.Annotations;

namespace YMWeb.Domain.ContentManage
{
    /// <summary>
    /// 创 建：超级管理员
    /// 日 期：2020-12-23 14:41
    /// 描 述：CMS内容管理实体类
    /// </summary>
    [TableAttribute("cms_content")]
    public class ContentEntity : IEntity<ContentEntity>,ICreationAudited,IModificationAudited,IDeleteAudited
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
        public string F_Titile { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string F_SubTitle { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string F_Content { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string F_Summary { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string F_CoverImage { get; set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        /// <returns></returns>
        public bool? F_EnabledMark { get; set; }
        /// <summary>
        /// 逻辑删除标志
        /// </summary>
        /// <returns></returns>
        public bool? F_DeleteMark { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        /// <returns></returns>
        public DateTime? F_CreatorTime { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        /// <returns></returns>
        public string F_CreatorUserId { get; set; }
        /// <summary>
        /// 最后修改时间
        /// </summary>
        /// <returns></returns>
        public DateTime? F_LastModifyTime { get; set; }
        /// <summary>
        /// 最后修改人
        /// </summary>
        /// <returns></returns>
        public string F_LastModifyUserId { get; set; }
        /// <summary>
        /// 删除时间
        /// </summary>
        /// <returns></returns>
        public DateTime? F_DeleteTime { get; set; }
        /// <summary>
        /// 删除人
        /// </summary>
        /// <returns></returns>
        public string F_DeleteUserId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string F_ChannelId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool? F_IpLimit { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string F_Tags { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string F_Author { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool? F_IsTop { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string F_Source { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string F_ContentHref { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int? F_HitCount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool? F_IsRecommend { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool? F_Status { get; set; }
        public int? F_LikeCount { get; set; }
        public int? F_CommentCount { get; set; }
        public string F_SeoTitle { get; set; }
        public string F_SeoKeywords { get; set; }
        public string F_SeoDescription { get; set; }
        public int? F_Order { get; set; }
        public bool? F_IsAuthorization { get; set; }
        public bool? F_IsComment { get; set; }
        public string F_LiveIntroduction { get; set; }
        public string F_WonderfulContent { get; set; }
        public int? F_FavoritesCount { get; set; }
        public int? F_SubscriptionCount { get; set; }
        public bool? F_IsLive { get; set; }
        public DateTime? F_MeetingStartTime { get; set; }
        public DateTime? F_MeetingEndTime { get; set; }
        public string F_LiveBroadcast { get; set; }
        public string F_Video { get; set; }
        public int? F_HitBackToCount { get; set; }
        public string F_SubChannelId { get; set; }
        public DateTime? F_PublishTime { get; set; }
        public string F_LiveId { get; set; }
        public string F_UserPass { get; set; }
        public string F_LiveBroadcastId { get; set; }
        public string F_MeetingTimePeriod { get; set; }
        public string F_TitleLink { get; set; }

        public string F_City { get; set; }

        public string F_ContentLable { get; set; }

        [NotMapped]
        public string PicUrl { get; set; }

        [NotMapped]
        public string ParentTitle { get; set; }

        [NotMapped]
        public string VideoUrl { get; set; }
        [NotMapped]
        /// <summary>
        /// 是否订阅
        /// </summary>
        public int IsSubcri { get; set; }
        [NotMapped]
        /// <summary>
        /// 作者名称
        /// </summary>
        public string AuthorName { get; set; }
        [NotMapped]
        /// <summary>
        /// 作者职称
        /// </summary>
        public string AuthorJob { get; set; }
        [NotMapped]
        /// <summary>
        /// 作者医院
        /// </summary>
        public string AuthorHospital { get; set; }
        [NotMapped]
        /// <summary>
        /// 是否收藏
        /// </summary>
        public int IsFavitor { get; set; }
        [NotMapped]
        /// <summary>
        /// 是否点赞
        /// </summary>
        public int IsdZ { get; set; }

        [NotMapped]
        /// <summary>
        /// 页面URL
        /// </summary>
        public string PageUrl { get; set; }

        [NotMapped]
        public string F_TagsName { get; set; }

        [NotMapped]
        public string F_ChannelColor { get; set; }

        [NotMapped]
        public string F_ChannelOne { get; set; }

        [NotMapped]
        public string F_CityName { get; set; }

    }
}
