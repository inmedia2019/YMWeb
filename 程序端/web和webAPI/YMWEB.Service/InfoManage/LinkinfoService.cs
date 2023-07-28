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
    /// 日 期：2022-09-26 19:29
    /// 描 述：渠道链接服务类
    /// </summary>
    public class LinkinfoService : DataFilterService<LinkinfoEntity>, IDenpendency
    {
        private string cacheKey = "YMWeb_linkinfodata_";
        private string className = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName.Split('.')[3];
        public LinkinfoService(IDbContext context) : base(context)
        {
        }
        #region 获取数据
        public async Task<List<LinkinfoEntity>> GetList(string keyword = "")
        {
            var cachedata = await repository.CheckCacheList(cacheKey + "list");
            if (!string.IsNullOrEmpty(keyword))
            {
                //此处需修改
                cachedata = cachedata.Where(t => t.F_title.Contains(keyword) || t.F_LinkUrl.Contains(keyword)).ToList();
            }
            return cachedata.Where(t => t.moreCol == "false").OrderByDescending(t => t.createDate).ToList();
        }

        public async Task<List<LinkinfoEntity>> GetLookList(string keyword = "")
        {
            var list =new List<LinkinfoEntity>();
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
                list = list.Where(u => u.F_title.Contains(keyword) || u.F_LinkUrl.Contains(keyword)).ToList();
            }
            return GetFieldsFilterData(list.Where(t => t.moreCol == "false").OrderByDescending(t => t.createDate).ToList(),className.Substring(0, className.Length - 7));
        }

        public async Task<List<LinkinfoEntity>> GetLookList(SoulPage<LinkinfoEntity> pagination,string keyword = "")
        {
            //获取数据权限
            var list = GetDataPrivilege("u", className.Substring(0, className.Length - 7));
            if (!string.IsNullOrEmpty(keyword))
            {
                //此处需修改
                list = list.Where(u => u.F_title.Contains(keyword) || u.F_LinkUrl.Contains(keyword));
            }
            list = list.Where(u => u.moreCol == "false");
            return GetFieldsFilterData(await repository.OrderList(list, pagination),className.Substring(0, className.Length - 7));
        }

        public async Task<LinkinfoEntity> GetForm(string keyValue)
        {
            var cachedata = await repository.CheckCache(cacheKey, keyValue);
            return cachedata;
        }
        #endregion

        public async Task<LinkinfoEntity> GetLookForm(string keyValue)
        {
            var cachedata = await repository.CheckCache(cacheKey, keyValue);
            return GetFieldsFilterData(cachedata,className.Substring(0, className.Length - 7));
        }

        #region 提交数据
        public async Task SubmitForm(LinkinfoEntity entity, string keyValue)
        {
            if (string.IsNullOrEmpty(keyValue))
            {
                    //此处需修改
                    entity.moreCol = "false";
                entity.Id=Utils.GuId();
                await repository.Insert(entity);
                await CacheHelper.Remove(cacheKey + "list");
            }
            else
            {
                    //此处需修改
                entity.Id=keyValue;
                await repository.Update(entity);
                await CacheHelper.Remove(cacheKey + keyValue);
                await CacheHelper.Remove(cacheKey + "list");
            }
        }

        public async Task DeleteForm(string keyValue)
        {
            var ids = keyValue.Split(',');
            await repository.Delete(t => ids.Contains(t.Id));
            foreach (var item in ids)
            {
            await CacheHelper.Remove(cacheKey + item);
            }
            await CacheHelper.Remove(cacheKey + "list");
        }
        #endregion

    }
}
