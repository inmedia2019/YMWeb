using YMWeb.Code;
using YMWeb.Domain.SystemSecurity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using YMWeb.Service.SystemManage;
using System.Linq;
using Chloe;
using YMWeb.Domain.SystemManage;

namespace YMWeb.Service.SystemSecurity
{
    public class LogService : DataFilterService<LogEntity>, IDenpendency
    {
        //登录信息保存方式
        private string LoginProvider = GlobalContext.SystemConfig.LoginProvider;
        private string HandleLogProvider = GlobalContext.SystemConfig.HandleLogProvider;
        private ModuleService moduleservice;
        //获取类名
        private string className = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName.Split('.')[3];
        public LogService(IDbContext context) : base(context)
        {
            moduleservice = new ModuleService(context);
        }
        public async Task<List<LogEntity>> GetList(Pagination pagination, int timetype, string keyword="")
        {
            //获取数据权限
            var result = new List<LogEntity>();
            DateTime startTime = DateTime.Now.ToString("yyyy-MM-dd").ToDate();
            DateTime endTime = DateTime.Now.ToString("yyyy-MM-dd").ToDate().AddDays(1);
            switch (timetype)
            {
                case 1:
                    break;
                case 2:
                    startTime = startTime.AddDays(-7);
                    break;
                case 3:
                    startTime = startTime.AddMonths(-1);
                    break;
                case 4:
                    startTime = startTime.AddMonths(-3);
                    break;
                default:
                    break;
            }
            if (HandleLogProvider != Define.CACHEPROVIDER_REDIS)
            {
                var list = repository.IQueryable();
                if (!string.IsNullOrEmpty(keyword))
                {
                    list = list.Where(u => u.F_Account.Contains(keyword) || u.F_Description.Contains(keyword) || u.F_ModuleName.Contains(keyword));
                }

                list = list.Where(t => t.F_Date >= startTime && t.F_Date <= endTime);
                result = await repository.OrderList(list, pagination);
            }
            else
            {
                result = HandleLogHelper.HGetAll<LogEntity>(currentuser.CompanyId).Values.ToList();
                if (!string.IsNullOrEmpty(keyword))
                {
                    result = result.Where(u => u.F_Account.Contains(keyword) || u.F_Description.Contains(keyword) || u.F_ModuleName.Contains(keyword)).Where(t => t.F_Date >= startTime && t.F_Date <= endTime).ToList();
                }
                else
                {
                    result = result.Where(t => t.F_Date >= startTime && t.F_Date <= endTime).ToList();
                }
            }
            return GetFieldsFilterData(result, className.Substring(0, className.Length - 7));
        }
        public async Task<List<LogEntity>> GetList()
        {
            if (HandleLogProvider != Define.CACHEPROVIDER_REDIS)
            {
                return repository.IQueryable().ToList();
            }
            else
            {
                return HandleLogHelper.HGetAll<LogEntity>(currentuser.CompanyId).Values.ToList(); ;
            }
        }
        public async Task RemoveLog(string keepTime)
        {
            DateTime operateTime = DateTime.Now;
            if (keepTime == "7")            //保留近一周
            {
                operateTime = DateTime.Now.AddDays(-7);
            }
            else if (keepTime == "1")       //保留近一个月
            {
                operateTime = DateTime.Now.AddMonths(-1);
            }
            else if (keepTime == "3")       //保留近三个月
            {
                operateTime = DateTime.Now.AddMonths(-3);
            }
            if (HandleLogProvider != Define.CACHEPROVIDER_REDIS)
            {
                var expression = ExtLinq.True<LogEntity>();
                expression = expression.And(t => t.F_Date <= operateTime);
                await repository.Delete(expression);
            }
            else
            {
                var list = HandleLogHelper.HGetAll<LogEntity>(currentuser.CompanyId).Values.ToList();
                var strList = list.Where(t => t.F_Date <= operateTime).Select(a=>a.F_Id).ToList();
                await HandleLogHelper.HDelAsync(currentuser.CompanyId, strList.ToArray());
            }
        }
        public async Task WriteDbLog(bool result, string resultLog)
        {
            LogEntity logEntity = new LogEntity();
            logEntity.F_Id = Utils.GuId();
            logEntity.F_Date = DateTime.Now;
            logEntity.F_Account = currentuser.UserCode;
            logEntity.F_NickName = currentuser.UserName;
            logEntity.F_IPAddress = currentuser.LoginIPAddress;
            logEntity.F_IPAddressName = currentuser.LoginIPAddressName;
            logEntity.F_CompanyId = currentuser.CompanyId;
            logEntity.F_Result = result;
            logEntity.F_Description = resultLog;
            logEntity.Create();
            if (HandleLogProvider != Define.CACHEPROVIDER_REDIS)
            {
                await repository.Insert(logEntity);
            }
            else
            {
                await HandleLogHelper.HSetAsync(currentuser.CompanyId, logEntity.F_Id, logEntity);
            }
        }
        public async Task WriteDbLog(LogEntity logEntity)
        {
            logEntity.F_Id = Utils.GuId();
            logEntity.F_Date = DateTime.Now;
            try
            {
                if (currentuser == null || string.IsNullOrEmpty(currentuser.UserId))
                {
                    logEntity.F_IPAddress = LoginProvider=="WebApi"? "未连接未知": WebHelper.Ip;
                    logEntity.F_IPAddressName = "本地局域网";
                    logEntity.F_CompanyId = Define.SYSTEM_MASTERPROJECT;
                }
                else
                {
                    logEntity.F_IPAddress = currentuser.LoginIPAddress;
                    logEntity.F_IPAddressName = currentuser.LoginIPAddressName;
                    logEntity.F_CompanyId = currentuser.CompanyId;
                }
                logEntity.Create();
                if (HandleLogProvider != Define.CACHEPROVIDER_REDIS)
                {
                    await repository.Insert(logEntity);
                }
                else
                {
                    await HandleLogHelper.HSetAsync(logEntity.F_CompanyId, logEntity.F_Id, logEntity);
                }
            }
            catch (Exception ex)
            {
                logEntity.F_IPAddress = LoginProvider == "WebApi" ? "未连接未知" : WebHelper.Ip;
                logEntity.F_IPAddressName = "本地局域网";
                logEntity.F_CompanyId = Define.SYSTEM_MASTERPROJECT;
                logEntity.Create();
                if (HandleLogProvider != Define.CACHEPROVIDER_REDIS)
                {
                    await repository.Insert(logEntity);
                }
                else
                {
                    await HandleLogHelper.HSetAsync(logEntity.F_CompanyId, logEntity.F_Id, logEntity);
                }
            }
        }

        public async Task<LogEntity> CreateLog(string className, DbLogType type)
        {
            try
            {
                var moduleitem = (await moduleservice.GetList()).Where(a => a.F_IsExpand == false && a.F_EnCode == className.Substring(0, className.Length - 10)).FirstOrDefault();
                if (moduleitem==null)
                {
                    throw new Exception();
                }
                var module = (await moduleservice.GetList()).Where(a => a.F_Id == moduleitem.F_ParentId).FirstOrDefault();
                return new LogEntity(await CreateModule(module), moduleitem == null ? "" : moduleitem.F_FullName, type.ToString());
            }
            catch (Exception ex)
            {
                return new LogEntity(className, "" , type.ToString());
            }
        }
        public async Task<LogEntity> CreateLog(string className, string type)
        {
            try
            {
                var moduleitem = (await moduleservice.GetList()).Where(a => a.F_IsExpand == false && a.F_EnCode == className.Substring(0, className.Length - 10)).FirstOrDefault();
                if (moduleitem == null)
                {
                    throw new Exception();
                }
                var module = (await moduleservice.GetList()).Where(a => a.F_Id == moduleitem.F_ParentId).FirstOrDefault();
                return new LogEntity(await CreateModule(module), moduleitem == null ? "" : moduleitem.F_FullName, type);

            }
            catch (Exception ex)
            {
                return new LogEntity(className, "", type.ToString());
            }
        }
        public async Task<string> CreateModule(ModuleEntity module, string str="")
        {
            if (module==null)
            {
                return str;
            }
            str = module.F_FullName + "-" + str;
            if (module.F_ParentId=="0")
            {
                return str;
            }
            else
            {
                var temp= (await moduleservice.GetList()).Where(a =>a.F_Id==module.F_ParentId).FirstOrDefault();
                return await CreateModule(temp ,str);
            }
        }
        public async Task WriteLog<T>(string message, string className, T afterChange, T beforeChange, string keyValue = "",  DbLogType? logType = null, bool isError = false)
        {
            LogEntity logEntity;
            if (logType != null)
            {
                logEntity = await CreateLog(className, (DbLogType)logType);
                logEntity.F_Description += logType.ToDescription()+"Id为"+ keyValue;
            }
            else
            {
                if (string.IsNullOrEmpty(keyValue))
                {
                    logEntity = await CreateLog(className, DbLogType.Create);
                    logEntity.F_Description += DbLogType.Create.ToDescription()+ afterChange;
                }
                else
                {
                    var change = "";
                    if (afterChange != null && beforeChange != null)
                    {
                         change = FormUtil.ForeachCompare(afterChange, beforeChange);
                    }
                    change = change == "" ? null : "<br>" + change.Substring(0, change.Length - 2);
                    logEntity = await CreateLog(className, DbLogType.Update);
                    logEntity.F_Description += DbLogType.Update.ToDescription() + change;
                }
            }
            logEntity.F_KeyValue = keyValue;
            if (isError)
            {
                logEntity.F_Result = false;
                logEntity.F_Description += "操作失败，" + message;
            }
            else
            {
                logEntity.F_Description += message;
            }
            if (currentuser != null && currentuser.UserId != null)
            {
                logEntity.F_Account = currentuser.UserCode;
                logEntity.F_NickName = currentuser.UserName;
            }
            await WriteDbLog(logEntity);
        }
    }
}
