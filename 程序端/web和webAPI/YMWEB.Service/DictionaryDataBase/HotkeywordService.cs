using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using YMWeb.Code;
using Chloe;
using YMWeb.Domain.DictionaryDataBase;

namespace YMWeb.Service.DictionaryDataBase
{
    /// <summary>
    /// 创 建：超级管理员
    /// 日 期：2022-05-26 15:30
    /// 描 述：热门关键词服务类
    /// </summary>
    public class HotkeywordService : DataFilterService<HotkeywordEntity>, IDenpendency
    {
        private string cacheKey = "YMWeb_hotkeyworddata_";
        private string className = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName.Split('.')[3];
        public HotkeywordService(IDbContext context) : base(context)
        {
        }
        #region 获取数据
        public async Task<List<HotkeywordEntity>> GetList(string keyword = "")
        {
            var cachedata = await repository.CheckCacheList(cacheKey + "list");
            if (!string.IsNullOrEmpty(keyword))
            {
                //此处需修改
                cachedata = cachedata.Where(t => t.F_Name.Contains(keyword)).ToList();
            }
            return cachedata.Where(t => t.F_DeleteMark == false).OrderByDescending(t => t.F_CreatorTime).ToList();
        }

        public async Task<List<HotkeywordEntity>> GetList()
        {
            var cachedata = await repository.CheckCacheList(cacheKey + "list");

            return cachedata.Where(t => t.F_DeleteMark == false).OrderByDescending(t => t.F_Order).OrderByDescending(t => t.F_CreatorTime).ToList();
        }

        public async Task<List<HotkeywordEntity>> GetKeyWordList()
        {
            // var cachedata = await repository.CheckCacheList(cacheKey + "list");

            //return cachedata.Where(t => t.F_DeleteMark == false).OrderByDescending(t => t.F_Order).OrderByDescending(t => t.F_CreatorTime).ToList();
            var keyWords = await repository.FindList("SELECT * FROM dic_hotkeyword where F_DeleteMark=false");
            return keyWords.OrderByDescending(t => t.F_Order).OrderByDescending(t => t.F_CreatorTime).ToList();
        }

        public async Task<List<HotkeywordEntity>> GetLookList(string keyword = "")
        {
            var list =new List<HotkeywordEntity>();
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
                list = list.Where(u => u.F_Name.Contains(keyword)).ToList();
            }
            return GetFieldsFilterData(list.Where(t => t.F_DeleteMark == false).OrderByDescending(t => t.F_CreatorTime).ToList(),className.Substring(0, className.Length - 7));
        }

        public async Task<List<HotkeywordEntity>> GetLookList(SoulPage<HotkeywordEntity> pagination,string keyword = "")
        {
            //获取数据权限
            var list = GetDataPrivilege("u", className.Substring(0, className.Length - 7));
            if (!string.IsNullOrEmpty(keyword))
            {
                //此处需修改
                list = list.Where(u => u.F_Name.Contains(keyword));
            }
            list = list.Where(u => u.F_DeleteMark==false);
            return GetFieldsFilterData(await repository.OrderList(list, pagination),className.Substring(0, className.Length - 7));
        }

        public async Task<HotkeywordEntity> GetForm(string keyValue)
        {
            var cachedata = await repository.CheckCache(cacheKey, keyValue);
            return cachedata;
        }
        #endregion

        public async Task<HotkeywordEntity> GetLookForm(string keyValue)
        {
            var cachedata = await repository.CheckCache(cacheKey, keyValue);
            return GetFieldsFilterData(cachedata,className.Substring(0, className.Length - 7));
        }

        #region 提交数据
        public async Task SubmitForm(HotkeywordEntity entity, string keyValue)
        {
            if (string.IsNullOrEmpty(keyValue))
            {
                    //此处需修改
                    entity.F_DeleteMark = false;
                entity.Create();
                await repository.Insert(entity);
                await CacheHelper.Remove(cacheKey + "list");
            }
            else
            {
                    //此处需修改
                entity.Modify(keyValue); 
                await repository.Update(entity);
                await CacheHelper.Remove(cacheKey + keyValue);
                await CacheHelper.Remove(cacheKey + "list");
            }
        }

        public async Task DeleteForm(string keyValue)
        {
            var ids = keyValue.Split(',');
            await repository.Delete(t => ids.Contains(t.F_Id));
            foreach (var item in ids)
            {
            await CacheHelper.Remove(cacheKey + item);
            }
            await CacheHelper.Remove(cacheKey + "list");
        }
        #endregion

    }
}
