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
    /// 日 期：2022-05-27 11:23
    /// 描 述：评论信息服务类
    /// </summary>
    public class CommentinfoService : DataFilterService<CommentinfoEntity>, IDenpendency
    {
        private string cacheKey = "YMWeb_commentinfodata_";
        private string className = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName.Split('.')[3];
        public CommentinfoService(IDbContext context) : base(context)
        {
        }
        #region 获取数据
        public async Task<List<CommentinfoEntity>> GetList(string keyword = "")
        {
            var cachedata = await repository.CheckCacheList(cacheKey + "list");
            if (!string.IsNullOrEmpty(keyword))
            {
                //此处需修改
                cachedata = cachedata.Where(t => t.infoId.Contains(keyword) || t.title.Contains(keyword) || t.mName.Contains(keyword) || t.sendDescript.Contains(keyword)).ToList();
            }
            return cachedata.Where(t => t.state == 0).OrderByDescending(t => t.createDate).ToList();
        }

        public async Task<List<CommentinfoEntity>> GetListByInfoId(string keyword = "")
        {
            var data = await repository.FindList("select *,(select trueName from web_memberinfo where id=web_commentinfo.mid) as trueName,(select moreCol from web_memberinfo where id=web_commentinfo.mid) as headPic from web_commentinfo where infoId='" + keyword + "' and state=0 order by createDate desc");
            return data;
        }


        public async Task<CommentinfoEntity> GetInfoById(string id)
        {
            CommentinfoEntity query = null;
            if (!string.IsNullOrEmpty(id))
            {
                query = await repository.FindEntity(a => a.Id == id);

            }
            return query;
        }


        public async Task<List<CommentinfoEntity>> GetLookList(string keyword = "")
        {
            var list =new List<CommentinfoEntity>();
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
                list = list.Where(u => u.infoId.Contains(keyword)).ToList();
            }
            return GetFieldsFilterData(list.Where(t => t.state == 0).OrderByDescending(t => t.createDate).ToList(),className.Substring(0, className.Length - 7));
        }

        public async Task<List<CommentinfoEntity>> GetLookList(SoulPage<CommentinfoEntity> pagination, string keyword = "")
        {
            //获取数据权限
            var list = GetDataPrivilege("u", className.Substring(0, className.Length - 7));
            if (!string.IsNullOrEmpty(keyword))
            {
                //此处需修改
                list = list.Where(u => u.infoId.Contains(keyword));
            }
            list = list.Where(u => u.state == 0);
            return GetFieldsFilterData(await repository.OrderList(list, pagination), className.Substring(0, className.Length - 7));
        }

        public async Task<CommentinfoEntity> GetForm(string keyValue)
        {
            var cachedata = await repository.CheckCache(cacheKey, keyValue);
            return cachedata;
        }
        #endregion

        public async Task<CommentinfoEntity> GetLookForm(string keyValue)
        {
            var cachedata = await repository.CheckCache(cacheKey, keyValue);
            return GetFieldsFilterData(cachedata,className.Substring(0, className.Length - 7));
        }

        #region 提交数据
        public async Task<string> SubmitForm(CommentinfoEntity entity, string keyValue)
        {
            if (string.IsNullOrEmpty(keyValue))
            {
                  //此处需修改
               
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
