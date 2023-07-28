﻿using YMWeb.Domain.SystemManage;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using YMWeb.Code;
using Chloe;

namespace YMWeb.Service.SystemManage
{
    public class ItemsTypeService : DataFilterService<ItemsEntity>,IDenpendency
    {
        /// <summary>
        /// 缓存操作类
        /// </summary>
        private string cacheKey = "YMWeb_itemsdata_";// 字典分类
        //获取类名
        private string className = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName.Split('.')[3];
        public ItemsTypeService(IDbContext context) : base(context)
        {
        }
        public async Task<List<ItemsEntity>> GetList()
        {
            var cachedata =await repository.CheckCacheList(cacheKey + "list");
            return cachedata.Where(a=>a.F_DeleteMark==false).OrderBy(t => t.F_SortCode).ToList();
        }
        public async Task<List<ItemsEntity>> GetLookList()
        {
            var list = new List<ItemsEntity>();
            if (!CheckDataPrivilege(className.Substring(0, className.Length - 7)))
            {
                list = await repository.CheckCacheList(cacheKey + "list");
            }
            else
            {
                var forms = GetDataPrivilege("u", className.Substring(0, className.Length - 7));
                list = forms.ToList();
            }
            return GetFieldsFilterData(list.Where(a => a.F_DeleteMark == false).OrderBy(t => t.F_SortCode).ToList(), className.Substring(0, className.Length - 7));
        }
        public async Task<ItemsEntity> GetLookForm(string keyValue)
        {
            var cachedata =await repository.CheckCache(cacheKey, keyValue);
            return GetFieldsFilterData(cachedata, className.Substring(0, className.Length - 7));

        }
        public async Task<ItemsEntity> GetForm(string keyValue)
        {
            var cachedata = await repository.CheckCache(cacheKey, keyValue);
            return cachedata;

        }
        public async Task DeleteForm(string keyValue)
        {
            if (repository.IQueryable(t => t.F_ParentId.Equals(keyValue)).Count() > 0)
            {
                throw new Exception("删除失败！操作的对象包含了下级数据。");
            }
            else
            {
                await repository.Delete(t => t.F_Id == keyValue);
                await CacheHelper.Remove(cacheKey + keyValue);
                await CacheHelper.Remove(cacheKey + "list");
            }
        }
        public async Task SubmitForm(ItemsEntity itemsEntity, string keyValue)
        {
            if (!string.IsNullOrEmpty(keyValue))
            {
                itemsEntity.Modify(keyValue);
                await repository.Update(itemsEntity);
                await CacheHelper.Remove(cacheKey + keyValue);
                await CacheHelper.Remove(cacheKey + "list");
            }
            else
            {
                itemsEntity.F_DeleteMark = false;
                itemsEntity.F_IsTree = false;
                itemsEntity.Create();
                await repository.Insert(itemsEntity);
                await CacheHelper.Remove(cacheKey + "list");
            }
        }
    }
}
