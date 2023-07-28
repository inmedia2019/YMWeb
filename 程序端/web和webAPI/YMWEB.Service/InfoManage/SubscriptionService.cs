using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using YMWeb.Code;
using Chloe;
using YMWeb.Domain.InfoManage;

namespace YMWeb.Service.InfoManage
{
    /// <summary>
    /// 创 建：超级管理员
    /// 日 期：2022-05-26 14:57
    /// 描 述：订阅信息服务类
    /// </summary>
    public class SubscriptionService : DataFilterService<SubscriptionEntity>, IDenpendency
    {
        private string cacheKey = "YMWeb_subscriptiondata_";
        private string className = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName.Split('.')[3];
        public SubscriptionService(IDbContext context) : base(context)
        {
        }
        #region 获取数据
        public async Task<List<SubscriptionEntity>> GetList(string keyword = "")
        {
            var cachedata = await repository.CheckCacheList(cacheKey + "list");
            if (!string.IsNullOrEmpty(keyword))
            {
                //此处需修改
                cachedata = cachedata.Where(t => t.UserId.ToString() == keyword || t.OpenId.Contains(keyword) || t.QuestionLabel.Contains(keyword) || t.Unionid.Contains(keyword)).ToList();
            }
            return cachedata.Where(t => t.State == 0).OrderByDescending(t => t.CreateTime).ToList();
        }

        public async Task<List<SubscriptionEntity>> GetListByMid(string mid = "")
        {
            //var cachedata = await repository.CheckCacheList(cacheKey + "list");

            //return cachedata.Where(t => t.mid == mid).OrderByDescending(t => t.createDate).ToList();
            var list = await repository.FindList("select * from web_subscription where userId='" + mid + "' and state=0 order by createTime desc");
            return list;
        }

        public async Task<List<SubscriptionEntity>> GetListByMidAndInfoId(string mid = "", string infoId = "")
        {
            //var cachedata = await repository.CheckCacheList(cacheKey + "list");

            //return cachedata.Where(t => t.mid == mid).OrderByDescending(t => t.createDate).ToList();
            var list = await repository.FindList("select * from web_subscription where userId='" + mid + "' and infoId='" + infoId + "' and state=0 order by createTime desc");
            return list;
        }

        public async Task<int> GetListCountByInfoId(string infoId = "", string mid = "")
        {
            //var cachedata = await repository.CheckCacheList(cacheKey + "list");

            //return cachedata.Where(t => t.mid == mid).OrderByDescending(t => t.createDate).ToList();
            var list = await repository.FindList("select * from web_subscription where userId='" + mid + "' and infoId='" + infoId + "' and state=0 order by createTime desc");
            return list.Count;
        }

        

        public async Task<List<SubscriptionEntity>> GetLookList(string keyword = "")
        {
            var list =new List<SubscriptionEntity>();
            if (!CheckDataPrivilege(className.Substring(0, className.Length - 7)))
            {
                list = await repository.CheckCacheList(cacheKey + "list");
            }
            else
            {
                var forms = GetDataPrivilege("u", className.Substring(0, className.Length - 7));
                list = forms.ToList();
            }
            if (!string.IsNullOrEmpty(keyword))
            {
                //此处需修改
                list = list.Where(u => u.UserId.ToString() == keyword || u.OpenId.Contains(keyword)).ToList();
            }
            return GetFieldsFilterData(list.Where(t => t.State == 0).OrderByDescending(t => t.CreateTime).ToList(),className.Substring(0, className.Length - 7));
        }

        public async Task<List<SubscriptionEntity>> GetLookList(SoulPage<SubscriptionEntity> pagination,string keyword = "")
        {
            //获取数据权限
            var list = GetDataPrivilege("u", className.Substring(0, className.Length - 7));
            if (!string.IsNullOrEmpty(keyword))
            {
                //此处需修改
                list = list.Where(u => u.UserId.ToString() == keyword || u.OpenId.Contains(keyword));
            }
            list = list.Where(u => u.State == 0);
            return GetFieldsFilterData(await repository.OrderList(list, pagination),className.Substring(0, className.Length - 7));
        }

        public async Task<SubscriptionEntity> GetForm(string keyValue)
        {
            var cachedata = await repository.CheckCache(cacheKey, keyValue);
            return cachedata;
        }
        #endregion

        public async Task<SubscriptionEntity> GetLookForm(string keyValue)
        {
            var cachedata = await repository.CheckCache(cacheKey, keyValue);
            return GetFieldsFilterData(cachedata,className.Substring(0, className.Length - 7));
        }

        #region 提交数据
        public async Task<string> SubmitForm(SubscriptionEntity entity, string keyValue)
        {
            if (string.IsNullOrEmpty(keyValue))
            {
                    //此处需修改
                //entity.State = 3;
                entity.ID=Utils.GuId();
                await repository.Insert(entity);
                await CacheHelper.Remove(cacheKey + "list");
            }
            else
            {
                    //此处需修改
                entity.ID=keyValue;
                await repository.Update(entity);
                await CacheHelper.Remove(cacheKey + keyValue);
                await CacheHelper.Remove(cacheKey + "list");
            }
            return entity.ID;
        }

        public async Task DeleteForm(string keyValue)
        {
            var ids = keyValue.Split(',');
            await repository.Delete(t => ids.Contains(t.ID));
            foreach (var item in ids)
            {
            await CacheHelper.Remove(cacheKey + item);
            }
            await CacheHelper.Remove(cacheKey + "list");
        }
        #endregion

    }
}
