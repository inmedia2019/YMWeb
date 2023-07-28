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
    /// 日 期：2022-05-04 19:08
    /// 描 述：积分记录服务类
    /// </summary>
    public class UseractioninfoService : DataFilterService<UseractioninfoEntity>, IDenpendency
    {
        private string cacheKey = "YMWeb_useractioninfodata_";
        private string className = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName.Split('.')[3];
        public UseractioninfoService(IDbContext context) : base(context)
        {
        }
        #region 获取数据
        public async Task<List<UseractioninfoEntity>> GetList(string keyword = "")
        {
            var cachedata = await repository.CheckCacheList(cacheKey + "list");
            if (!string.IsNullOrEmpty(keyword))
            {
                //此处需修改
                cachedata = cachedata.Where(t => t.trueName.Contains(keyword) || t.Phone.Contains(keyword)).ToList();
            }
            return cachedata.Where(t => t.tid == 1).OrderByDescending(t => t.createDate).ToList();
        }

        public async Task<List<UseractioninfoEntity>> GetLookList(string keyword = "")
        {
            var list =new List<UseractioninfoEntity>();
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
                list = list.Where(u => u.trueName.Contains(keyword) || u.Phone.Contains(keyword)).ToList();
            }
            return GetFieldsFilterData(list.Where(t => t.tid == 1).OrderByDescending(t => t.createDate).ToList(),className.Substring(0, className.Length - 7));
        }

        public async Task<List<UseractioninfoEntity>> GetLookList(SoulPage<UseractioninfoEntity> pagination,string keyword = "")
        {
            //获取数据权限
            var list = GetDataPrivilege("u", className.Substring(0, className.Length - 7));
            if (!string.IsNullOrEmpty(keyword))
            {
                //此处需修改
                list = list.Where(u => u.trueName.Contains(keyword) || u.Phone.Contains(keyword));
            }
            list = list.Where(u => u.tid == 1);
            return GetFieldsFilterData(await repository.OrderList(list, pagination),className.Substring(0, className.Length - 7));
        }

        public async Task<UseractioninfoEntity> GetForm(string keyValue)
        {
            var cachedata = await repository.CheckCache(cacheKey, keyValue);
            return cachedata;
        }
        #endregion

        public async Task<UseractioninfoEntity> GetLookForm(string keyValue)
        {
            var cachedata = await repository.CheckCache(cacheKey, keyValue);
            return GetFieldsFilterData(cachedata,className.Substring(0, className.Length - 7));
        }

        /// <summary>
        /// 查询用户是否已经点赞信息
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public async Task<int> GetFirstFavitorRecordCount(string mid = "", string infoId = "")
        {
            //var cachedata = await repository.CheckCacheList(cacheKey + "list");
            //if (!string.IsNullOrEmpty(mid))
            //{
            //    //此处需修改
            //    cachedata = cachedata.Where(t => t.mid == mid && t.tid == 2 && t.infoid == infoId).ToList();
            //}

            //return cachedata.ToList().Count;

            var list = await repository.FindList(" select * from web_useractioninfo where mid='" + mid + "' and tid=2 and infoid='"+ infoId + "'");

            return list.Count;


        }

        /// <summary>
        /// 查询用户是否已经点赞信息
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public async Task<UseractioninfoEntity> GetDZRecordCount(string mid = "", string infoId = "")
        {


            var list = await repository.FindList(" select * from web_useractioninfo where mid='" + mid + "' and tid in(2,8) and infoid='" + infoId + "'");
            var actinfo = list.OrderByDescending(p => p.createDate).FirstOrDefault();

            return actinfo;

        }

        /// <summary>
        /// 查询用户是否第一次签到
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public async Task<int> GetFirstSignRecordCount(string keyword = "")
        {
            //var cachedata = await repository.CheckCacheList(cacheKey + "list");
            //if (!string.IsNullOrEmpty(keyword))
            //{
            //    //此处需修改
            //    cachedata = cachedata.Where(t => t.mid == keyword && t.tid == 1 && t.moreCol == "0").ToList();
            //}

            var list = await repository.FindList("select * from web_useractioninfo where mid='" + keyword + "' and tid=1 and moreCol='0'");
            return list.Count;

        }

        /// <summary>
        /// 查询用户是否有行为
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public async Task<int> GetFirstLookCount(string mid = "", string vcontent = "")
        {

            var list = await repository.FindList("select * from web_useractioninfo where mid='" + mid + "' and tid=11 and vContent='" + vcontent.Replace("'", "") + "'");
            return list.Count;

        }

        /// <summary>
        /// 查询用户是否第一次留言
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public async Task<int> GetFirstLiveMessageCount(string keyword = "")
        {
            //var cachedata = await repository.CheckCacheList(cacheKey + "list");
            //if (!string.IsNullOrEmpty(keyword))
            //{
            //    //此处需修改
            //    cachedata = cachedata.Where(t => t.mid == keyword && t.tid == 1 && t.moreCol == "3").ToList();
            //}
            //return cachedata.ToList().Count;

            var list = await repository.FindList(" select * from web_useractioninfo where mid='" + keyword + "' and tid=1 and moreCol='3'");

            return list.Count;

        }


        /// <summary>
        /// 查询用户积分数
        /// </summary>
        /// <param name="mid">用户ID</param>
        /// <param name="specialData">徽章分类标签</param>
        /// <returns></returns>
        public async Task<List<UseractioninfoEntity>> GetUserRecordCount(string mid = "", string specialData="")
        {
            //var cachedata = await repository.CheckCacheList(cacheKey + "list");
            //if (!string.IsNullOrEmpty(mid))
            //{
            //    //此处需修改
            //    cachedata = cachedata.Where(t => t.mid == mid && t.tid == 1 && t.SpecialData == specialData).ToList();
            //}
           
            //return cachedata.ToList();
            var list = await repository.FindList(" select * from web_useractioninfo where mid='" + mid + "' and tid=1 and SpecialData='" + specialData + "'");

            return list;
        }


        /// <summary>
        /// 查询用户积分数
        /// </summary>
        /// <param name="mid">用户ID</param>
        /// <param name="moreCol">积分类型</param>
        /// <returns></returns>
        public async Task<List<UseractioninfoEntity>> GetRecordCounts(string mid = "", string moreCol = "")
        {
            //var cachedata = await repository.CheckCacheList(cacheKey + "list");
            //if (!string.IsNullOrEmpty(mid))
            //{
            //    //此处需修改
            //    cachedata = cachedata.Where(t => t.mid == mid && t.tid == 1 && t.SpecialData == specialData).ToList();
            //}

            //return cachedata.ToList();
            var list = await repository.FindList(" select * from web_useractioninfo where mid='" + mid + "' and tid=1 and moreCol='" + moreCol + "'");

            return list;
        }

        /// <summary>
        /// 查询用户信息阅读第一条记录
        /// </summary>
        /// <param name="mid">用户ID</param>
        /// <param name="infoId">信息ID</param>
        /// <returns></returns>
        public async Task<UseractioninfoEntity> GetTopInfo(string mid = "", string infoId = "")
        {
            //var cachedata = await repository.CheckCacheList(cacheKey + "list");
            //if (!string.IsNullOrEmpty(mid))
            //{
            //    //此处需修改
            //    cachedata = cachedata.Where(t => t.mid == mid && t.tid == 0 && t.SpecialData == specialData).ToList();
            //}

            //return cachedata.ToList();

            var list = await repository.FindList(" select * from web_useractioninfo where mid='" + mid + "' and tid=0 and infoid='" + infoId + "' limit 1");

            return list.FirstOrDefault();

        }


        /// <summary>
        /// 查询用户分类阅读记录
        /// </summary>
        /// <param name="mid">用户ID</param>
        /// <param name="specialData">徽章分类标签</param>
        /// <returns></returns>
        public async Task<List<UseractioninfoEntity>> GetUserReadRecordList(string mid = "", string specialData = "")
        {
            //var cachedata = await repository.CheckCacheList(cacheKey + "list");
            //if (!string.IsNullOrEmpty(mid))
            //{
            //    //此处需修改
            //    cachedata = cachedata.Where(t => t.mid == mid && t.tid == 0 && t.SpecialData == specialData).ToList();
            //}

            //return cachedata.ToList();

            var list = await repository.FindList(" select * from web_useractioninfo where mid='" + mid + "' and tid=0 and SpecialData='" + specialData + "'");

            return list;

        }

        /// <summary>
        /// 查询用户分类阅读数
        /// </summary>
        /// <param name="mid">用户ID</param>
        /// <param name="specialData">徽章分类标签</param>
        /// <returns></returns>
        public async Task<int> GetUserReadRecordCount(string mid = "", string specialData = "")
        {
            //var cachedata = await repository.CheckCacheList(cacheKey + "list");
            //if (!string.IsNullOrEmpty(mid))
            //{
            //    //此处需修改
            //    cachedata = cachedata.Where(t => t.mid == mid && t.tid == 0 && t.SpecialData == specialData).ToList();
            //}

            //return cachedata.ToList().Count;

            var list = await repository.FindList(" select * from web_useractioninfo where mid='" + mid + "' and tid=0 and SpecialData='" + specialData + "'");

            return list.Count;
        }

        /// <summary>
        /// 查询用户今天是否已经签到
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public async Task<int> GetSignRecordCount(string keyword = "")
        {
            //var cachedata = await repository.CheckCacheList(cacheKey + "list");
            //if (!string.IsNullOrEmpty(keyword))
            //{
            //    //此处需修改
            //    cachedata = cachedata.Where(t => t.mid == keyword && t.tid == 1 && t.moreCol == "0" && t.createDate >= Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd") + " 00:00:00") && t.createDate <= Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd") + " 23:59:59")).ToList();
            //}

            var list = await repository.FindList(" select * from web_useractioninfo where mid='" + keyword + "' and tid=1 and moreCol='0' and createDate>='" + DateTime.Now.ToString("yyyy-MM-dd") + " 00:00:00' and createDate<='" + DateTime.Now.ToString("yyyy-MM-dd") + " 23:59:59'");

            return list.Count;

        }


        /// <summary>
        /// 查询用户当前信息有没有浏览过当前文章
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public async Task<int> GetRecordCount(string keyword = "", string infoId = "")
        {
            //var cachedata = await repository.CheckCacheList(cacheKey + "list");
            //if (!string.IsNullOrEmpty(keyword))
            //{
            //    //此处需修改
            //    cachedata = cachedata.Where(t => t.mid == keyword && t.tid == 1 && t.infoid == infoId).ToList();
            //}
            //return cachedata.ToList().Count;

            var list = await repository.FindList(" select * from web_useractioninfo where mid='" + keyword + "' and tid=1 and infoid='" + infoId + "'");

            return list.Count;

        }



        /// <summary>
        /// 查询用户本月签到次数
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public async Task<int> GetSignRecordCountByMonth(string keyword = "")
        {
            //var cachedata = await repository.CheckCacheList(cacheKey + "list");
            //if (!string.IsNullOrEmpty(keyword))
            //{
            //    //此处需修改
            //    cachedata = cachedata.Where(t => t.mid == keyword && t.tid == 1 && t.moreCol == "0" && t.createDate >= Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-01") + " 00:00:00") && t.createDate <= Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd") + " 23:59:59")).ToList();
            //}
            //return cachedata.ToList().Count;

            var list = await repository.FindList(" select * from web_useractioninfo where mid='" + keyword + "' and tid=1 and moreCol='0' and createDate>='"+ DateTime.Now.ToString("yyyy-MM-01") + " 00:00:00' and createDate<='"+ DateTime.Now.ToString("yyyy-MM-dd") + " 23:59:59'");

            return list.Count;

        }

        /// <summary>
        /// 查询用户积分记录
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public async Task<List<UseractioninfoEntity>> GetScoreRecdorByMid(SoulPage<UseractioninfoEntity> pagination, string keyword = "")
        {
          
            //获取数据权限
            var list = GetDataPrivilege("u", className.Substring(0, className.Length - 7));
            if (!string.IsNullOrEmpty(keyword))
            {
                //此处需修改
                list = list.Where(u => u.mid == keyword && u.tid == 1);
            }
            return GetFieldsFilterData(await repository.OrderList(list, pagination), className.Substring(0, className.Length - 7));
        }

        /// <summary>
        /// 查询用户浏览记录
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public async Task<List<UseractioninfoEntity>> GetHistoryByMid(string keyword = "", int tid = 0)
        {
            var data = await repository.FindList("select infoId from web_useractioninfo where length(infoId)>0 and mid='" + keyword + "' and tid=" + tid + " group by infoId");
            //string searchInfoId = "";
            //foreach (var item in data)
            //{
            //    searchInfoId += "'" + item.infoid + "',";
            //}

            //if (searchInfoId.Length > 0)
            //    searchInfoId = searchInfoId.Substring(0, searchInfoId.Length - 1);

            //var list = await repository.FindList("select *,IsSubcri=(select count(1) from web_subscription where userId=" + keyword + " and state=0) from cms_content where id in(" + searchInfoId + ")");

            //list= list.Where(p=>p.)

            return data;

        }


        #region 提交数据
        public async Task<string> SubmitForm(UseractioninfoEntity entity, string keyValue)
        {
            if (string.IsNullOrEmpty(keyValue))
            {
                    //此处需修改
                   // entity.F_DeleteMark = false;
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
            return entity.Id;
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
