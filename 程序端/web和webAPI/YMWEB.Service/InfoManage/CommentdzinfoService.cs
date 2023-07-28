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
    /// 日 期：2022-05-27 14:42
    /// 描 述：评论点赞服务类
    /// </summary>
    public class CommentdzinfoService : DataFilterService<CommentdzinfoEntity>, IDenpendency
    {
        private string cacheKey = "YMWeb_commentdzinfodata_";
        private string className = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName.Split('.')[3];
        public CommentdzinfoService(IDbContext context) : base(context)
        {
        }
        #region 获取数据
        public async Task<List<CommentdzinfoEntity>> GetList(string keyword = "")
        {
            var cachedata = await repository.CheckCacheList(cacheKey + "list");
           
            return cachedata.OrderByDescending(t => t.createDate).ToList();
        }

        public async Task<List<CommentdzinfoEntity>> GetLookList(string keyword = "")
        {
            var list =new List<CommentdzinfoEntity>();
            if (!CheckDataPrivilege(className.Substring(0, className.Length - 7)))
            {
                list = await repository.CheckCacheList(cacheKey + "list");
            }
            else
            {
                var forms = GetDataPrivilege("u", className.Substring(0, className.Length - 7));
                list = forms.ToList();
            }
            //if (!string.IsNullOrEmpty(keyword))
            //{
            //    //此处需修改
            //    list = list.Where(u => u.F_FullName.Contains(keyword) || u.F_EnCode.Contains(keyword)).ToList();
            //}
            return GetFieldsFilterData(list.OrderByDescending(t => t.createDate).ToList(),className.Substring(0, className.Length - 7));
        }

        public async Task<int> GetListCountByCommentId(string keyword = "", string mid = "")
        {
            List<CommentdzinfoEntity> list = await repository.FindList("select * from web_commentdzinfo where commentId='" + keyword + "' and mid='" + mid + "'");
            return list.Count;
        }

      
        public async Task<List<CommentdzinfoEntity>> GetLookList(SoulPage<CommentdzinfoEntity> pagination,string keyword = "")
        {
            //获取数据权限
            var list = GetDataPrivilege("u", className.Substring(0, className.Length - 7));
            //if (!string.IsNullOrEmpty(keyword))
            //{
            //    //此处需修改
            //    list = list.Where(u => u.F_FullName.Contains(keyword) || u.F_EnCode.Contains(keyword));
            //}
           // list = list.Where(u => u.F_DeleteMark==false);
            return GetFieldsFilterData(await repository.OrderList(list, pagination),className.Substring(0, className.Length - 7));
        }

        public async Task<CommentdzinfoEntity> GetForm(string keyValue)
        {
            var cachedata = await repository.CheckCache(cacheKey, keyValue);
            return cachedata;
        }
        #endregion

        public async Task<CommentdzinfoEntity> GetLookForm(string keyValue)
        {
            var cachedata = await repository.CheckCache(cacheKey, keyValue);
            return GetFieldsFilterData(cachedata,className.Substring(0, className.Length - 7));
        }

        #region 提交数据
        public async Task<string> SubmitForm(CommentdzinfoEntity entity, string keyValue)
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
