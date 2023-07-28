using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using YMWeb.Code;
using Chloe;
using YMWeb.Domain.ContentManage;
using System.Collections;
using Newtonsoft.Json;

namespace YMWeb.Service.ContentManage
{
    /// <summary>
    /// 创 建：超级管理员
    /// 日 期：2020-12-23 14:41
    /// 描 述：CMS内容管理服务类
    /// </summary>
    public class ContentService : DataFilterService<ContentEntity>, IDenpendency
    {
        private string cacheKey = "YMWeb_contentdata_";
        private string className = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName.Split('.')[3];
        public LableService _labelService { get; set; }
        public ContentService(IDbContext context) : base(context)
        {
        }
        #region 获取数据
        public async Task<List<ContentEntity>> GetList(string keyword = "")
        {
            var cachedata = await repository.CheckCacheList(cacheKey + "list");
            if (!string.IsNullOrEmpty(keyword))
            {
                //此处需修改
                cachedata = cachedata.Where(t => t.F_Titile.Contains(keyword)).ToList();
            }
            return cachedata.Where(t => t.F_DeleteMark == false).OrderByDescending(t => t.F_CreatorTime).ToList();
        }

        public async Task<List<ContentEntity>> GetMeetingTimePeriodList()
        {
            var cachedata = await repository.CheckCacheList(cacheKey + "list");
            return cachedata.Where(t => t.F_DeleteMark == false && t.F_EnabledMark == true && t.F_MeetingTimePeriod != "" && t.F_MeetingTimePeriod != null && t.F_MeetingEndTime < DateTime.Now).OrderByDescending(t => t.F_CreatorTime).ToList();
        }

        public async Task<ContentEntity> GetInfoById(string id)
        {
            ContentEntity query = null;
            if (!string.IsNullOrEmpty(id))
            {
                query = await repository.FindEntity(a => a.F_Id == id && a.F_EnabledMark == true);

            }
            return query;
        }

        public async Task<List<ContentEntity>> GetListByChannelId(string channelId, int page = 1, int psize = 10)
        {

            var list = await repository.FindList("select *,(SELECT F_ChannelName FROM cms_channel WHERE F_Id=cms_content.F_ChannelId) AS ParentTitle from cms_content where F_ChannelId='" + channelId + "' and F_EnabledMark=true and F_DeleteMark=false order by F_IsTop desc, F_order desc, F_CreatorTime desc");
            list = list.Skip((page - 1) * psize).Take(psize).AsQueryable().ToList();
            return list;

        }

        public async Task<List<ContentEntity>> GetListByChannelId(string cityId, string channelId, string subChannelId = "", string keyWord = "", int page = 1, int psize = 10, int orderInfo = 0, int isRecommand = -1)
        {
            string[] temp = channelId.Replace("'", "").Split(',');
            string channel = "";
            for (int i = 0; i < temp.Length; i++)
            {
                if (temp[i].Length > 0)
                    channel += "'" + temp[i] + "',";
            }



            if (channel.Length > 0)
            {
                channel = channel.Substring(0, channel.Length - 1);
                string tempChannel = "";
                var channelList = await repository.FindList("SELECT F_Id FROM cms_channel WHERE F_ParentId in(" + channel + ") and F_EnabledMark=true and F_DeleteMark=false");
                for (int i = 0; i < channelList.Count; i++)
                {
                    tempChannel += "'" + channelList[i].F_Id + "',";
                }

                if (tempChannel.Length > 0)
                {
                    channel = tempChannel + channel;
                }
            }
            // LogHelper.Write(channel);

            string[] subtemp = subChannelId.Replace("'", "").Split(',');
            string subchannel = "";
            for (int i = 0; i < subtemp.Length; i++)
            {
                if (subtemp[i].Length > 0)
                    subchannel += "'" + subtemp[i] + "',";
            }



            if (subchannel.Length > 0)
                subchannel = subchannel.Substring(0, subchannel.Length - 1);

            string tempSql = "";

            if (channel.Length > 0)
            {
                tempSql += " and F_ChannelId in(" + channel + ")";
            }

            if (subchannel.Length > 0)
            {
                tempSql += " and F_SubChannelId in(" + subchannel + ")";
            }


            if (isRecommand > -1)
            {
                tempSql += " and F_IsRecommend=" + isRecommand;
            }

            string orderFile = "F_CreatorTime";
            if (orderInfo == 1)
                orderFile = "F_HitCount";



            var list = await repository.FindList("select *,(SELECT F_ChannelName FROM cms_channel WHERE F_Id=cms_content.F_ChannelId) AS ParentTitle from cms_content where 1=1 " + tempSql + " and F_EnabledMark=true  and F_DeleteMark=false order by F_IsTop desc, F_order desc, " + orderFile + " desc");
            foreach (var data in list)
            {
                if (data.F_Tags.Length > 0)
                {
                    List<LableEntity> tagList = await _labelService.GetListByIds(data.F_Tags);
                    foreach (var item in tagList)
                    {
                        data.F_TagsName += item.F_Name + ",";
                    }
                }
                else
                {
                    data.F_TagsName = "";
                }
            }

            if (keyWord.Length > 0)
            {
                list = list.Where(p => p.F_Titile.ToLower().Contains(keyWord.ToLower()) || p.F_TagsName.ToLower().Contains(keyWord.ToLower())).ToList();
            }

            if (cityId.Length > 0)
            {
                list = list.Where(p => p.F_City.ToLower().Contains(cityId.ToLower())).ToList();
            }

            list = list.Skip((page - 1) * psize).Take(psize).AsQueryable().ToList();
            return list;

        }

        public async Task<List<ContentEntity>> GetHomeListByChannelId(string currentCityId,string cityId, string channelId, string subChannelId = "", string keyWord = "", int page = 1, int psize = 10, int orderInfo = 0, int isRecommand = -1)
        {
            string[] temp = channelId.Replace("'", "").Split(',');
            string channel = "";
            for (int i = 0; i < temp.Length; i++)
            {
                if (temp[i].Length > 0)
                    channel += "'" + temp[i] + "',";
            }



            if (channel.Length > 0)
            {
                channel = channel.Substring(0, channel.Length - 1);
                string tempChannel = "";
                var channelList = await repository.FindList("SELECT F_Id FROM cms_channel WHERE F_ParentId in(" + channel + ") and F_EnabledMark=true and F_DeleteMark=false");
                for (int i = 0; i < channelList.Count; i++)
                {
                    tempChannel += "'" + channelList[i].F_Id + "',";
                }

                if (tempChannel.Length > 0)
                {
                    channel = tempChannel + channel;
                }
            }
            // LogHelper.Write(channel);

            string[] subtemp = subChannelId.Replace("'", "").Split(',');
            string subchannel = "";
            for (int i = 0; i < subtemp.Length; i++)
            {
                if (subtemp[i].Length > 0)
                    subchannel += "'" + subtemp[i] + "',";
            }



            if (subchannel.Length > 0)
                subchannel = subchannel.Substring(0, subchannel.Length - 1);

            string tempSql = "";
            string tempSql1 = "";
            if (channel.Length > 0)
            {
                tempSql += " and F_ChannelId in(" + channel + ")";
                tempSql1 += " and F_ChannelId in(" + channel + ")";
            }
            else
            {
                if (currentCityId != "")
                {
                    tempSql += " and F_ChannelId<>'dc3944f1-b596-4e4f-8326-5eb4d67d1e10'";
                }
            }

            if (subchannel.Length > 0)
            {
                tempSql += " and F_SubChannelId in(" + subchannel + ")";
                tempSql1 += " and F_SubChannelId in(" + subchannel + ")";
            }

            if (isRecommand > -1)
            {
                tempSql += " and F_IsRecommend=" + isRecommand;
            }

            string orderFile = "F_CreatorTime";
            if (orderInfo == 1)
                orderFile = "F_HitCount";

            ContentEntity toolData = new ContentEntity();
            if (currentCityId != "")
            {
                var toolList = await repository.FindList("select *,(SELECT F_ChannelName FROM cms_channel WHERE F_Id=cms_content.F_ChannelId) AS ParentTitle from cms_content where F_ChannelId='dc3944f1-b596-4e4f-8326-5eb4d67d1e10' and F_City='" + currentCityId.Replace("'", "") + "' " + tempSql1 + "  and F_EnabledMark=true  and F_DeleteMark=false order by F_IsTop desc, F_order desc, " + orderFile + " desc");

                toolData = toolList.FirstOrDefault();
                string infoid = "";
                if (toolData != null)
                {
                    infoid = toolData.F_Id;
                }

                if (infoid != "")
                {
                    tempSql += " and F_Id<>'" + infoid + "'";
                }
            }

            var list = await repository.FindList("select *,(SELECT F_ChannelName FROM cms_channel WHERE F_Id=cms_content.F_ChannelId) AS ParentTitle from cms_content where 1=1 " + tempSql + "  and F_EnabledMark=true  and F_DeleteMark=false order by F_IsTop desc, F_order desc, " + orderFile + " desc");
            foreach (var data in list)
            {
                if (data.F_Tags.Length > 0)
                {
                    List<LableEntity> tagList = await _labelService.GetListByIds(data.F_Tags);
                    foreach (var item in tagList)
                    {
                        data.F_TagsName += item.F_Name + ",";
                    }
                }
                else
                {
                    data.F_TagsName = "";
                }
            }

            if (keyWord.Length > 0)
            {
                list = list.Where(p => p.F_Titile.ToLower().Contains(keyWord.ToLower()) || p.F_TagsName.ToLower().Contains(keyWord.ToLower())).ToList();
            }

            if (cityId.Length > 0)
            {
                list = list.Where(p => p.F_City.ToLower().Contains(cityId.ToLower())).ToList();
            }

            list = list.Skip((page - 1) * psize).Take(psize).AsQueryable().ToList();

            if (toolData.F_Id != null)
            {
                List<ContentEntity> returnToolList = new List<ContentEntity>();
                returnToolList.Add(toolData);
                for (int i = 0; i < list.Count - 1; i++)
                {
                    returnToolList.Add(list[i]);
                }
                return returnToolList;
            }

            return list;

        }

        public async Task<List<ContentEntity>> GetLiveInfoByChannelId(string tid, string channelId, string subChannelId, string keyWord, int page = 1, int psize = 10)
        {
            string temp = "";

            string[] subtemp = subChannelId.Replace("'", "").Split(',');
            string subchannel = "";
            for (int i = 0; i < subtemp.Length; i++)
            {
                if (subtemp[i].Length > 0)
                    subchannel += "'" + subtemp[i] + "',";
            }

            if (subchannel.Length > 0)
                subchannel = subchannel.Substring(0, subchannel.Length - 1);


            if (subchannel.Length > 0)
            {
                temp += " and F_SubChannelId in(" + subchannel + ")";
            }

            if (keyWord.Length > 0)
            {
                temp += " and (F_Titile like '%" + keyWord + "%' or F_Author in(select F_Id from dic_expert where F_Name like '%" + keyWord.Replace("'", "") + "%')) ";
            }

            if (tid == "0")
            {
                temp += " and F_MeetingStartTime>'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'";
            }
            else if (tid == "1")
            {
                temp += " and F_MeetingStartTime<='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' and F_MeetingEndTime>='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'";
            }
            else if (tid == "2")
            {
                temp += " and F_MeetingEndTime<'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'";
            }

            var list = await repository.FindList("select *,(SELECT F_ChannelName FROM cms_channel WHERE F_Id=cms_content.F_ChannelId) AS ParentTitle from cms_content where F_ChannelId='" + channelId + "' and F_EnabledMark=true and  F_DeleteMark=false " + temp + " order by F_IsTop desc, F_order desc, F_MeetingStartTime desc");
            list = list.Skip((page - 1) * psize).Take(psize).AsQueryable().ToList();
            return list;

        }


        public async Task<List<ContentEntity>> GetListByInfoIds(string infoIds, int page = 1, int psize = 10, string mid = "", string tagId = "", int tid = -1)
        {
            string tempSql = "";
            if (tagId.Length > 0)
                tempSql = "and LOCATE(F_SubChannelId,'" + tagId + "')>0";

            if (tid == 0)
            {
                tempSql += " and F_MeetingStartTime>'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'";
            }
            else if (tid == 1)
            {
                tempSql += " and F_MeetingStartTime<='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "' and F_MeetingEndTime>='" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'";
            }
            else if (tid == 2)
            {
                tempSql += " and F_MeetingEndTime<'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'";
            }

            var list = await repository.FindList("select *,(select count(1) from web_subscription where userId='" + mid + "' and state=0 and infoId=cms_content.F_Id) as IsSubcri,(SELECT F_ChannelName FROM cms_channel WHERE F_Id=cms_content.F_ChannelId) AS ParentTitle from cms_content where F_Id in(" + infoIds + ") and F_EnabledMark=true and F_DeleteMark=false " + tempSql + " order by F_IsTop desc,F_order desc, F_CreatorTime desc");
            list = list.Skip((page - 1) * psize).Take(psize).AsQueryable().ToList();
            return list;
        }

        public async Task<List<ContentEntity>> GetListByInfoIds(string infoIds, int page = 1, int psize = 10, string mid = "", string tagId = "", string channelId = "")
        {
            string tempSql = "";
            if (tagId.Length > 0)
                tempSql = "and LOCATE(F_SubChannelId,'" + tagId + "')>0";

            if (channelId.Length > 0)
                tempSql += " and F_ChannelId='" + channelId + "'";

            
            if (infoIds.Length > 0)
            {
                tempSql += " and F_Id in(" + infoIds + ")";
            }

            var list = await repository.FindList("select *,(select count(1) from web_subscription where userId='" + mid + "' and state=0 and infoId=cms_content.F_Id) as IsSubcri,(SELECT F_ChannelName FROM cms_channel WHERE F_Id=cms_content.F_ChannelId) AS ParentTitle from cms_content where  F_EnabledMark=true and F_DeleteMark=false " + tempSql + " order by F_IsTop desc,F_order desc, F_CreatorTime desc");
            list = list.Skip((page - 1) * psize).Take(psize).AsQueryable().ToList();
            return list;
        }

        public async Task<List<ContentEntity>> GetListByInfoIds(string infoIds, string channelId = "")
        {
            string tempSql = "";
            if (channelId.Length > 0)
                tempSql += " and F_ChannelId='" + channelId + "'";

            if (infoIds.Length > 0)
            {
                tempSql += " and F_Id in(" + infoIds + ")";
            }

            var list = await repository.FindList("select * from cms_content where F_EnabledMark=true and F_DeleteMark=false " + tempSql + " order by F_IsTop desc,F_order desc, F_CreatorTime desc");
         
            return list;
        }

        public async Task<List<ContentEntity>> GetCityIdByChannelId(string channel, string cityId = "")
        {
            List<ContentEntity> returnList = new List<ContentEntity>();
            string tempSql = "";
            if (channel.Length > 0)
                tempSql += " and F_ChannelId='" + channel + "'";

            string tsql = "";
            if (cityId.Length > 0)
            {
                tsql += " and F_City='" + cityId + "'";
            }
            string fcity = "";
            var cityList = await repository.FindList("select * from cms_content where F_EnabledMark=true and F_DeleteMark=false " + tempSql + tsql + " order by F_IsTop desc,F_order desc, F_CreatorTime desc");
            if (cityList.Count > 0)
            {
                var data = cityList.FirstOrDefault();
                fcity = data.F_City;
                returnList.Add(data);
            }

            var list = await repository.FindList("select * from cms_content where F_EnabledMark=true and F_DeleteMark=false " + tempSql + " order by F_IsTop desc,F_order desc, F_CreatorTime desc");
            for (int i = 0; i < list.Count; i++)
            {
                var temp = list[i];
                if (temp.F_City != fcity)
                {
                    returnList.Add(temp);
                }
            }
            return returnList;
        }

        public async Task<int> GetListCountByChannelId(string channelId)
        {
            var cachedata = await repository.CheckCacheList(cacheKey + "list");
            if (!string.IsNullOrEmpty(channelId))
            {
                cachedata = cachedata.Where(t => t.F_ChannelId == channelId).ToList();

            }
            var listCount = cachedata.Where(t => t.F_DeleteMark == false).ToList().Count;
            return listCount;
        }
        public async Task<int> GetListCountByLableId(string lableId)
        {
            var cachedata = await repository.CheckCacheList(cacheKey + "list");
            if (!string.IsNullOrEmpty(lableId))
            {
                cachedata = cachedata.Where(t => t.F_Tags.Contains(lableId)).ToList();

            }
            var listCount = cachedata.Where(t => t.F_DeleteMark == false).ToList().Count;
            return listCount;
        }
        public async Task<List<ContentEntity>> GetLookList(SoulPage<ContentEntity> pagination, string itemId = "", string keyword = "")
        {
            var list = GetDataPrivilege("u", className.Substring(0, className.Length - 7));
            if (!string.IsNullOrEmpty(itemId))
            {
                list = list.Where(u => itemId.Contains(u.F_ChannelId) || (u.F_SubChannelId!="" && itemId.Contains(u.F_SubChannelId)));
            }
            if (!string.IsNullOrEmpty(keyword))
            {
                //此处需修改
                list = list.Where(u => u.F_Titile.Contains(keyword));
            }
            list = list.Where(u => u.F_DeleteMark == false);
            return GetFieldsFilterData(await repository.OrderList(list, pagination), className.Substring(0, className.Length - 7));
        }

        public async Task<List<ContentEntity>> GetLookList(SoulPage<ContentEntity> pagination, string keyword = "")
        {
            //获取数据权限
            var list = GetDataPrivilege("u", className.Substring(0, className.Length - 7));
            if (!string.IsNullOrEmpty(keyword))
            {
                //此处需修改
                list = list.Where(u => u.F_Titile.Contains(keyword));
            }
            list = list.Where(u => u.F_DeleteMark == false);
            return GetFieldsFilterData(await repository.OrderList(list, pagination), className.Substring(0, className.Length - 7));
        }

        public async Task<ContentEntity> GetForm(string keyValue)
        {
            var cachedata = await repository.CheckCache(cacheKey, keyValue);
            return cachedata;
        }
        #endregion

        public async Task<ContentEntity> GetLookForm(string keyValue)
        {
            var cachedata = await repository.CheckCache(cacheKey, keyValue);
            return GetFieldsFilterData(cachedata, className.Substring(0, className.Length - 7));
        }

        #region 提交数据
        public async Task SubmitForm(ContentEntity entity, string keyValue)
        {
            var datastr = "";
            if (string.IsNullOrEmpty(keyValue))
            {
                //此处需修改
                entity.F_DeleteMark = false;
                entity.Create();
                await repository.Insert(entity);
                //try
                //{
                //    if (!string.IsNullOrEmpty(entity.F_MeetingStartTime.ToString()))
                //    {
                //        var endDate = entity.F_MeetingEndTime == null ? "" : entity.F_MeetingEndTime.ToString().Replace("-", "/");
                //        var liveBroadcastId = entity.F_LiveBroadcastId == null ? "" : entity.F_LiveBroadcastId.ToString();
                //        LiveInfo info = new LiveInfo();
                //        info.sign = Md5.md5(entity.F_Id.ToString() + entity.F_Titile.ToString() + entity.F_MeetingStartTime.ToString().Replace("-", "/") + endDate + entity.F_ChannelId.ToString() + entity.F_Tags.ToString() + liveBroadcastId + "1" + entity.F_SubChannelId.ToString() + GlobalContext.SystemConfig.secretkey, 32).ToLower();
                //        info.Id = entity.F_Id.ToString();
                //        info.Title = entity.F_Titile.ToString();
                //        info.StarDate = entity.F_MeetingStartTime.ToString().Replace("-", "/");
                //        info.EndDate = endDate;
                //        info.ColumnId = entity.F_ChannelId.ToString();
                //        info.TagId = entity.F_Tags.ToString();
                //        info.LiveId = liveBroadcastId;
                //        info.opType = 1;
                //        info.SubColumnId = entity.F_SubChannelId.ToString();
                //        datastr = JsonConvert.SerializeObject(info);
                //        string reult = HttpHelper.Http(GlobalContext.SystemConfig.url + "/LiveInfo/OPLiveInfo", "POST", "", null, datastr);
                //    }
                //    else
                //    {
                //        NewsInfo info = new NewsInfo();
                //        info.sign = Md5.md5(entity.F_Id.ToString() + entity.F_Titile.ToString() + entity.F_ChannelId.ToString() + entity.F_Tags.ToString() + entity.F_CreatorTime.ToString().Replace("-", "/") + "1" + GlobalContext.SystemConfig.secretkey, 32).ToLower();
                //        info.Id = entity.F_Id.ToString();
                //        info.Title = entity.F_Titile.ToString();
                //        info.ParentId = entity.F_ChannelId.ToString();
                //        info.TagId = entity.F_Tags.ToString();
                //        info.Author = "";
                //        info.PubDate = entity.F_CreatorTime.ToString().Replace("-", "/");
                //        info.opType = 1;
                //        datastr = JsonConvert.SerializeObject(info);
                //        string reult = HttpHelper.Http(GlobalContext.SystemConfig.url + "/NewsInfo/OPNewsInfo", "POST", "", null, datastr);
                //    }
                //}
                //catch (Exception ex)
                //{
                //}
                await CacheHelper.Remove(cacheKey + "list");
            }
            else
            {
                //此处需修改
                entity.Modify(keyValue);
                await repository.Update(entity);
                //try
                //{
                //    var opType = entity.F_EnabledMark == false ? 4 : 2;
                //    if (!string.IsNullOrEmpty(entity.F_MeetingStartTime.ToString()))
                //    {
                //        var endDate = entity.F_MeetingEndTime == null ? "" : entity.F_MeetingEndTime.ToString().Replace("-", "/");
                //        var liveBroadcastId = entity.F_LiveBroadcastId == null ? "" : entity.F_LiveBroadcastId.ToString();
                //        LiveInfo info = new LiveInfo();
                //        info.sign = Md5.md5(entity.F_Id.ToString() + entity.F_Titile.ToString() + entity.F_MeetingStartTime.ToString().Replace("-", "/") + endDate + entity.F_ChannelId.ToString() + entity.F_Tags.ToString() + liveBroadcastId  + opType.ToString() + entity.F_SubChannelId.ToString() + GlobalContext.SystemConfig.secretkey, 32).ToLower();
                //        info.Id = entity.F_Id.ToString();
                //        info.Title = entity.F_Titile.ToString();
                //        info.StarDate = entity.F_MeetingStartTime.ToString().Replace("-", "/");
                //        info.EndDate = endDate;
                //        info.ColumnId = entity.F_ChannelId.ToString();
                //        info.TagId = entity.F_Tags.ToString();
                //        info.LiveId = liveBroadcastId;
                //        info.opType = opType;
                //        info.SubColumnId = entity.F_SubChannelId.ToString();
                //        datastr = JsonConvert.SerializeObject(info);
                //        string reult = HttpHelper.Http(GlobalContext.SystemConfig.url + "/LiveInfo/OPLiveInfo", "POST", "", null, datastr);
                //    }
                //    else
                //    {
                //        NewsInfo info = new NewsInfo();
                //        info.sign = Md5.md5(entity.F_Id.ToString() + entity.F_Titile.ToString() + entity.F_ChannelId.ToString() + entity.F_Tags.ToString() + entity.F_CreatorTime.ToString().Replace("-", "/") + opType.ToString() + GlobalContext.SystemConfig.secretkey, 32).ToLower();
                //        info.Id = entity.F_Id.ToString();
                //        info.Title = entity.F_Titile.ToString();
                //        info.ParentId = entity.F_ChannelId.ToString();
                //        info.TagId = entity.F_Tags.ToString();
                //        info.Author = "";
                //        info.PubDate = entity.F_CreatorTime.ToString().Replace("-", "/");
                //        info.opType = opType;
                //        datastr = JsonConvert.SerializeObject(info);
                //        string reult = HttpHelper.Http(GlobalContext.SystemConfig.url + "/NewsInfo/OPNewsInfo", "POST", "", null, datastr);
                //    }
                //}
                //catch (Exception ex)
                //{
                //}
                await CacheHelper.Remove(cacheKey + keyValue);
                await CacheHelper.Remove(cacheKey + "list");
            }
        }

        public async Task DeleteForm(string keyValue)
        {
            var ids = keyValue.Split(',');
            foreach (var item in ids)
            {
                var cachedata = await repository.CheckCache(cacheKey, item);
                try
                {
                    var datastr = "";
                    if (!string.IsNullOrEmpty(cachedata.F_MeetingStartTime.ToString()))
                    {
                        var endDate = cachedata.F_MeetingEndTime == null ? "" : cachedata.F_MeetingEndTime.ToString().Replace("-", "/");
                        var liveBroadcastId = cachedata.F_LiveBroadcastId == null ? "" : cachedata.F_LiveBroadcastId.ToString();
                        LiveInfo info = new LiveInfo();
                        info.sign = Md5.md5(cachedata.F_Id.ToString() + cachedata.F_Titile.ToString() + cachedata.F_MeetingStartTime.ToString().Replace("-", "/") + endDate + cachedata.F_ChannelId.ToString() + cachedata.F_Tags.ToString() + liveBroadcastId + "3" + cachedata.F_SubChannelId.ToString() + GlobalContext.SystemConfig.secretkey, 32).ToLower();
                        info.Id = cachedata.F_Id.ToString();
                        info.Title = cachedata.F_Titile.ToString();
                        info.StarDate = cachedata.F_MeetingStartTime.ToString().Replace("-", "/");
                        info.EndDate = endDate;
                        info.ColumnId = cachedata.F_ChannelId.ToString();
                        info.TagId = cachedata.F_Tags.ToString();
                        info.LiveId = liveBroadcastId;
                        info.opType = 3;
                        info.SubColumnId = cachedata.F_SubChannelId.ToString();
                        datastr = JsonConvert.SerializeObject(info);
                        string reult = HttpHelper.Http(GlobalContext.SystemConfig.url + "/LiveInfo/OPLiveInfo", "POST", "", null, datastr);
                    }
                    else
                    {
                        NewsInfo info = new NewsInfo();
                        info.sign = Md5.md5(cachedata.F_Id.ToString() + cachedata.F_Titile.ToString() + cachedata.F_ChannelId.ToString() + cachedata.F_Tags.ToString() + cachedata.F_CreatorTime.ToString().Replace("-", "/") + "3" + GlobalContext.SystemConfig.secretkey, 32).ToLower();
                        info.Id = cachedata.F_Id.ToString();
                        info.Title = cachedata.F_Titile.ToString();
                        info.ParentId = cachedata.F_ChannelId.ToString();
                        info.TagId = cachedata.F_Tags.ToString();
                        info.Author = "";
                        info.PubDate = cachedata.F_CreatorTime.ToString().Replace("-", "/");
                        info.opType = 3;
                        datastr = JsonConvert.SerializeObject(info);
                        string reult = HttpHelper.Http(GlobalContext.SystemConfig.url + "/NewsInfo/OPNewsInfo", "POST", "", null, datastr);
                    }
                }
                catch (Exception ex)
                {
                }
                cachedata.F_EnabledMark = false;
                cachedata.F_DeleteMark = true;
                cachedata.Modify(item);
                await repository.Update(cachedata);
                await CacheHelper.Remove(cacheKey + item);
            }
            //await repository.Delete(t => ids.Contains(t.F_Id));
            await CacheHelper.Remove(cacheKey + "list");
        }

        public async Task PublishForm(string keyValue)
        {
            var ids = keyValue.Split(',');
            foreach (var item in ids)
            {
                var cachedata = await repository.CheckCache(cacheKey, item);
                try
                {
                    var datastr = "";
                    if (!string.IsNullOrEmpty(cachedata.F_MeetingStartTime.ToString()))
                    {
                        var endDate = cachedata.F_MeetingEndTime == null ? "" : cachedata.F_MeetingEndTime.ToString().Replace("-", "/");
                        var liveBroadcastId = cachedata.F_LiveBroadcastId == null ? "" : cachedata.F_LiveBroadcastId.ToString();
                        LiveInfo info = new LiveInfo();
                        info.sign = Md5.md5(cachedata.F_Id.ToString() + cachedata.F_Titile.ToString() + cachedata.F_MeetingStartTime.ToString().Replace("-", "/") + endDate + cachedata.F_ChannelId.ToString() + cachedata.F_Tags.ToString() + liveBroadcastId  + "2" + cachedata.F_SubChannelId.ToString() + GlobalContext.SystemConfig.secretkey, 32).ToLower();
                        info.Id = cachedata.F_Id.ToString();
                        info.Title = cachedata.F_Titile.ToString();
                        info.StarDate = cachedata.F_MeetingStartTime.ToString().Replace("-", "/");
                        info.EndDate = endDate;
                        info.ColumnId = cachedata.F_ChannelId.ToString();
                        info.TagId = cachedata.F_Tags.ToString();
                        info.LiveId = liveBroadcastId;
                        info.opType = 2;
                        info.SubColumnId = cachedata.F_SubChannelId.ToString();
                        datastr = JsonConvert.SerializeObject(info);
                        string reult = HttpHelper.Http(GlobalContext.SystemConfig.url + "/LiveInfo/OPLiveInfo", "POST", "", null, datastr);
                    }
                    else
                    {
                        NewsInfo info = new NewsInfo();
                        info.sign = Md5.md5(cachedata.F_Id.ToString() + cachedata.F_Titile.ToString() + cachedata.F_ChannelId.ToString() + cachedata.F_Tags.ToString() + cachedata.F_CreatorTime.ToString().Replace("-", "/") + "2" + GlobalContext.SystemConfig.secretkey, 32).ToLower();
                        info.Id = cachedata.F_Id.ToString();
                        info.Title = cachedata.F_Titile.ToString();
                        info.ParentId = cachedata.F_ChannelId.ToString();
                        info.TagId = cachedata.F_Tags.ToString();
                        info.Author = "";
                        info.PubDate = cachedata.F_CreatorTime.ToString().Replace("-", "/");
                        info.opType = 2;
                        datastr = JsonConvert.SerializeObject(info);
                        string reult = HttpHelper.Http(GlobalContext.SystemConfig.url + "/NewsInfo/OPNewsInfo", "POST", "", null, datastr);
                    }
                }
                catch (Exception ex)
                {
                }
                cachedata.F_EnabledMark = true;
                cachedata.Modify(item);
                await repository.Update(cachedata);
                await CacheHelper.Remove(cacheKey + item);
            }
            //await repository.Delete(t => ids.Contains(t.F_Id));
            await CacheHelper.Remove(cacheKey + "list");
        }

        public async Task RecycleForm(string keyValue)
        {
            var ids = keyValue.Split(',');
            foreach (var item in ids)
            {
                var cachedata = await repository.CheckCache(cacheKey, item);
                //try
                //{
                //    var datastr = "";
                //    if (!string.IsNullOrEmpty(cachedata.F_MeetingStartTime.ToString()))
                //    {
                //        var endDate = cachedata.F_MeetingEndTime == null ? "" : cachedata.F_MeetingEndTime.ToString().Replace("-", "/");
                //        var liveBroadcastId = cachedata.F_LiveBroadcastId == null ? "" : cachedata.F_LiveBroadcastId.ToString();
                //        LiveInfo info = new LiveInfo();
                //        info.sign = Md5.md5(cachedata.F_Id.ToString() + cachedata.F_Titile.ToString() + cachedata.F_MeetingStartTime.ToString().Replace("-", "/") + endDate + cachedata.F_ChannelId.ToString() + cachedata.F_Tags.ToString() + liveBroadcastId + "4" + cachedata.F_SubChannelId.ToString() + GlobalContext.SystemConfig.secretkey, 32).ToLower();
                //        info.Id = cachedata.F_Id.ToString();
                //        info.Title = cachedata.F_Titile.ToString();
                //        info.StarDate = cachedata.F_MeetingStartTime.ToString().Replace("-", "/");
                //        info.EndDate = endDate;
                //        info.ColumnId = cachedata.F_ChannelId.ToString();
                //        info.TagId = cachedata.F_Tags.ToString();
                //        info.LiveId = liveBroadcastId;
                //        info.opType = 4;
                //        info.SubColumnId = cachedata.F_SubChannelId.ToString();
                //        datastr = JsonConvert.SerializeObject(info);
                //        string reult = HttpHelper.Http(GlobalContext.SystemConfig.url + "/LiveInfo/OPLiveInfo", "POST", "", null, datastr);
                //    }
                //    else
                //    {
                //        NewsInfo info = new NewsInfo();
                //        info.sign = Md5.md5(cachedata.F_Id.ToString() + cachedata.F_Titile.ToString() + cachedata.F_ChannelId.ToString() + cachedata.F_Tags.ToString() + cachedata.F_CreatorTime.ToString().Replace("-", "/") + "2" + GlobalContext.SystemConfig.secretkey, 32).ToLower();
                //        info.Id = cachedata.F_Id.ToString();
                //        info.Title = cachedata.F_Titile.ToString();
                //        info.ParentId = cachedata.F_ChannelId.ToString();
                //        info.TagId = cachedata.F_Tags.ToString();
                //        info.Author = "";
                //        info.PubDate = cachedata.F_CreatorTime.ToString().Replace("-", "/");
                //        info.opType = 4;
                //        datastr = JsonConvert.SerializeObject(info);
                //        string reult = HttpHelper.Http(GlobalContext.SystemConfig.url + "/NewsInfo/OPNewsInfo", "POST", "", null, datastr);
                //    }
                //}
                //catch (Exception ex)
                //{
                //}
                cachedata.F_EnabledMark = false;
                cachedata.Modify(item);
                await repository.Update(cachedata);
                await CacheHelper.Remove(cacheKey + item);
            }
            //await repository.Delete(t => ids.Contains(t.F_Id));
            await CacheHelper.Remove(cacheKey + "list");
        }
        #endregion

    }
}
