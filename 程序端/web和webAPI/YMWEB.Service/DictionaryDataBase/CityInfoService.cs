using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using YMWeb.Code;
using Chloe;
using YMWeb.Domain.DictionaryDataBase;
using YMWeb.Domain.Entity.ContentManage;
using Newtonsoft.Json;

namespace YMWeb.Service.DictionaryDataBase
{
    /// <summary>
    /// 创 建：超级管理员
    /// 日 期：2021-03-18 14:03
    /// 描 述：医院管理服务类
    /// </summary>
    public class CityInfoService : DataFilterService<CityInfoEntity>, IDenpendency
    {
        private string cacheKey = "YMWeb_CityInfodata_";
        private string className = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName.Split('.')[3];
        public CityInfoService(IDbContext context) : base(context)
        {
        }
        #region 获取数据
        public async Task<List<CityInfoEntity>> GetList(string keyword = "")
        {
            var cachedata = await repository.CheckCacheList(cacheKey + "list");
            if (!string.IsNullOrEmpty(keyword))
            {
                //此处需修改
                cachedata = cachedata.Where(t => t.F_CityName.Contains(keyword)).ToList();
            }
            return cachedata.Where(t => t.F_DeleteMark == false).OrderByDescending(t => t.F_CreatorTime).ToList();
        }

        public async Task<CityInfoEntity> GetInfoById(string keyValue)
        {
            var cachedata = await repository.FindEntity(a => a.F_Id == keyValue);
            return cachedata;
        }

        public async Task<CityInfoEntity> GetCityIdByName(string keyValue)
        {
            string sql = "select * from dic_cityinfo where F_DeleteMark=false and instr('" + keyValue.Replace("'", "") + "',F_CityName)";
            var List = await repository.FindList(sql);
            var data = List.FirstOrDefault();
            return data;
        }

        public async Task<List<CityInfoEntity>> GetLookList(string keyword = "")
        {
            var list =new List<CityInfoEntity>();
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
                list = list.Where(u => u.F_CityName.Contains(keyword)).ToList();
            }
            return GetFieldsFilterData(list.Where(t => t.F_DeleteMark == false).OrderByDescending(t => t.F_CreatorTime).ToList(),className.Substring(0, className.Length - 7));

        }

        public async Task<List<CityInfoEntity>> GetListByIds(string ids = "")
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
            string sql = "select * from dic_cityinfo where F_DeleteMark=false";
            if (searchIds.Length > 0)
                sql += " and F_Id in(" + searchIds + ")";

            var list = await repository.FindList(sql);

            return list;
        }

        public async Task<List<CityInfoEntity>> GetLookList(SoulPage<CityInfoEntity> pagination,string keyword = "")
        {
            //获取数据权限
            var list = GetDataPrivilege("u", className.Substring(0, className.Length - 7));
            if (!string.IsNullOrEmpty(keyword))
            {
                //此处需修改
                list = list.Where(u => u.F_CityName.Contains(keyword));
            }
            list = list.Where(u => u.F_DeleteMark==false);
            return GetFieldsFilterData(await repository.OrderList(list, pagination),className.Substring(0, className.Length - 7));
        }

        public async Task<CityInfoEntity> GetForm(string keyValue)
        {
            var cachedata = await repository.CheckCache(cacheKey, keyValue);
            return cachedata;
        }
        #endregion

        public async Task<CityInfoEntity> GetLookForm(string keyValue)
        {
            var cachedata = await repository.CheckCache(cacheKey, keyValue);
            return GetFieldsFilterData(cachedata,className.Substring(0, className.Length - 7));
        }

        #region 提交数据
        public async Task SubmitForm(CityInfoEntity entity, string keyValue)
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
                //    HospitalInfo info = new HospitalInfo();
                //    info.sign = Md5.md5(entity.F_Id.ToString() + entity.F_HospitalName.ToString() + province + entity.F_Code.ToString() + "1" + GlobalContext.SystemConfig.secretkey, 32).ToLower();
                //    info.Id = entity.F_Id.ToString();
                //    info.HospitalName = entity.F_HospitalName.ToString();
                //    info.Province = province;
                //    info.HospitalCode = entity.F_Code.ToString();
                //    info.opType = 1;
                //    datastr = JsonConvert.SerializeObject(info);
                //    string reult = HttpHelper.Http(GlobalContext.SystemConfig.url + "/HospitalInfo/OPHospitalInfo", "POST", "", null, datastr);
                //}
                //catch (Exception ex) { }
                await CacheHelper.Remove(cacheKey + "list");
            }
            else
            {
                    //此处需修改
                entity.Modify(keyValue); 
                await repository.Update(entity);
                //try
                //{
                //    HospitalInfo info = new HospitalInfo();
                //    info.sign = Md5.md5(entity.F_Id.ToString() + entity.F_HospitalName.ToString() + province + entity.F_Code.ToString() + "2" + GlobalContext.SystemConfig.secretkey, 32).ToLower();
                //    info.Id = entity.F_Id.ToString();
                //    info.HospitalName = entity.F_HospitalName.ToString();
                //    info.Province = province;
                //    info.HospitalCode = entity.F_Code.ToString();
                //    info.opType = 2;
                //    datastr = JsonConvert.SerializeObject(info);
                //    string reult = HttpHelper.Http(GlobalContext.SystemConfig.url + "/HospitalInfo/OPHospitalInfo", "POST", "", null, datastr);
                //}
                //catch (Exception ex) { }

                await CacheHelper.Remove(cacheKey + keyValue);
                await CacheHelper.Remove(cacheKey + "list");
            }
        }

        public async Task DeleteForm(string keyValue)
        {
            var ids = keyValue.Split(',');
            //await repository.Delete(t => ids.Contains(t.F_Id));
            foreach (var item in ids)
            {
                var cachedata = await repository.CheckCache(cacheKey, item);
                //try
                //{
                //    var datastr = "";
                //    HospitalInfo info = new HospitalInfo();
                //    info.sign = Md5.md5(cachedata.F_Id.ToString() + cachedata.F_CityName.ToString() + province + cachedata.F_Code.ToString() + "3" + GlobalContext.SystemConfig.secretkey, 32).ToLower();
                //    info.Id = cachedata.F_Id.ToString();
                //    info.HospitalName = cachedata.F_CityName.ToString();
                //    info.Province = province;
                //    info.HospitalCode = cachedata.F_Code.ToString();
                //    info.opType = 3;
                //    datastr = JsonConvert.SerializeObject(info);
                //    //string reult = HttpHelper.Http(GlobalContext.SystemConfig.url + "/HospitalInfo/OPHospitalInfo", "POST", "", null, datastr);
                //}
                //catch (Exception ex) { }
                cachedata.F_EnabledMark = false;
                cachedata.F_DeleteMark = true;
                cachedata.Modify(item);
                await repository.Update(cachedata);
                await CacheHelper.Remove(cacheKey + item);
            }
            await CacheHelper.Remove(cacheKey + "list");
        }
        #endregion

    }
}
