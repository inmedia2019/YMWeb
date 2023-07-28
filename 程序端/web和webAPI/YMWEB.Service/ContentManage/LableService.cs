using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using YMWeb.Code;
using Chloe;
using YMWeb.Domain.ContentManage;
using Newtonsoft.Json;

namespace YMWeb.Service.ContentManage
{
    /// <summary>
    /// 创 建：超级管理员
    /// 日 期：2020-12-11 11:37
    /// 描 述：标签管理服务类
    /// </summary>
    public class LableService : DataFilterService<LableEntity>, IDenpendency
    {
        private string cacheKey = "YMWeb_labledata_";
        private string className = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName.Split('.')[3];
        public LableService(IDbContext context) : base(context)
        {
        }
        #region 获取数据
        public async Task<List<LableEntity>> GetList(string keyword = "")
        {
            var cachedata = await repository.CheckCacheList(cacheKey + "list");
            if (!string.IsNullOrEmpty(keyword))
            {
                //此处需修改
                cachedata = cachedata.Where(t => t.F_Name.Contains(keyword)).ToList();
            }
            return cachedata.Where(t => t.F_DeleteMark == false).OrderByDescending(t => t.F_CreatorTime).ToList();
        }

        public async Task<List<LableEntity>> GetListByIds(string ids = "")
        {
            string[] temp = ids.Split(',');
            string searchIds = "";
			for (int i = 0; i < temp.Length; i++)
			{
                if (temp[i].Length > 0)
                {
                    searchIds += "'" + temp[i].Replace("'", "") + "',";
                }

            }
            if (searchIds.Length > 0)
                searchIds = searchIds.Substring(0, searchIds.Length - 1);
            string sql = "select * from cms_lable";
            if (searchIds.Length > 0)
                sql += " where F_Id in(" + searchIds + ")";

            var list = await repository.FindList(sql);

            return list;
        }

        public async Task<LableEntity> GetInfoById(string id)
        {
            LableEntity query = null;
            if (!string.IsNullOrEmpty(id))
            {
                query = await repository.FindEntity(a => a.F_Id == id && a.F_EnabledMark == true);

            }
            return query;
        }

        public async Task<List<LableEntity>> GetLookList(string keyword = "")
        {
            var list = new List<LableEntity>();
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
            return GetFieldsFilterData(list.Where(t => t.F_DeleteMark == false).OrderByDescending(t => t.F_CreatorTime).ToList(), className.Substring(0, className.Length - 7));
        }

        public async Task<List<LableEntity>> GetLookList(SoulPage<LableEntity> pagination, string keyword = "")
        {
            //获取数据权限
            var list = GetDataPrivilege("u", className.Substring(0, className.Length - 7));
            if (!string.IsNullOrEmpty(keyword))
            {
                //此处需修改
                list = list.Where(u => u.F_Name.Contains(keyword));
            }
            list = list.Where(u => u.F_DeleteMark == false);
            return GetFieldsFilterData(await repository.OrderList(list, pagination), className.Substring(0, className.Length - 7));
        }

        public async Task<LableEntity> GetForm(string keyValue)
        {
            var cachedata = await repository.CheckCache(cacheKey, keyValue);
            return cachedata;
        }
        #endregion

        public async Task<LableEntity> GetLookForm(string keyValue)
        {
            var cachedata = await repository.CheckCache(cacheKey, keyValue);
            return GetFieldsFilterData(cachedata, className.Substring(0, className.Length - 7));
        }

        #region 提交数据
        public async Task SubmitForm(LableEntity entity, string keyValue)
        {
            var datastr = "";
            if (string.IsNullOrEmpty(keyValue))
            {
                //此处需修改
                entity.F_DeleteMark = false;
                entity.Create();
                await repository.Insert(entity);
                try
                {
                    TagInfo info = new TagInfo();
                    info.sign = Md5.md5(entity.F_Id.ToString() + entity.F_Name.ToString() + entity.F_ParentId.ToString() + "1" + GlobalContext.SystemConfig.secretkey, 32).ToLower();
                    info.Id = entity.F_Id.ToString();
                    info.Title = entity.F_Name.ToString();
                    info.ParentId = entity.F_ParentId.ToString();
                    info.opType = 1;
                    datastr = JsonConvert.SerializeObject(info);
                    //string reult = HttpHelper.Http(GlobalContext.SystemConfig.url + "/TagInfo/OPTagInfo", "POST", "", null, datastr);
                }
                catch (Exception ex) { }
                await CacheHelper.Remove(cacheKey + "list");
            }
            else
            {
                //此处需修改
                entity.Modify(keyValue);
                await repository.Update(entity);
                try
                {
                    var opType = entity.F_EnabledMark == false ? 4 : 2;
                    TagInfo info = new TagInfo();
                    info.sign = Md5.md5(entity.F_Id.ToString() + entity.F_Name.ToString() + entity.F_ParentId.ToString() + opType.ToString() + GlobalContext.SystemConfig.secretkey, 32).ToLower();
                    info.Id = entity.F_Id.ToString();
                    info.Title = entity.F_Name.ToString();
                    info.ParentId = entity.F_ParentId.ToString();
                    info.opType = opType;
                    datastr = JsonConvert.SerializeObject(info);
                    //string reult = HttpHelper.Http(GlobalContext.SystemConfig.url + "/TagInfo/OPTagInfo", "POST", "", null, datastr);
                }
                catch (Exception ex) { }
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
                    TagInfo info = new TagInfo();
                    info.sign = Md5.md5(cachedata.F_Id.ToString() + cachedata.F_Name.ToString() + cachedata.F_ParentId.ToString() + "3" + GlobalContext.SystemConfig.secretkey, 32).ToLower();
                    info.Id = cachedata.F_Id.ToString();
                    info.Title = cachedata.F_Name.ToString();
                    info.ParentId = cachedata.F_ParentId.ToString();
                    info.opType = 3;
                    datastr = JsonConvert.SerializeObject(info);
                    //string reult = HttpHelper.Http(GlobalContext.SystemConfig.url + "/TagInfo/OPTagInfo", "POST", "", null, datastr);
                }
                catch (Exception ex) { }
                cachedata.F_EnabledMark = false;
                cachedata.F_DeleteMark = true;
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
