using Chloe;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using YMWeb.Code;
using YMWeb.Domain.DictionaryDataBase;
using YMWeb.Service.DictionaryDataBase;

namespace YMWeb.Service.AutoJob.Job
{
    public class VideoInfoJob : IJobTask
    {
        public UseractioninfoService _service { get; set; }
        public VideoInfoJob(IDbContext context)
        {
            _service = new UseractioninfoService(context);
        }
        public async Task<AjaxResult> Start()
        {

            //UseractioninfoEntity info = new UseractioninfoEntity();
            //info.createDate = DateTime.Now;
            //info.descript = "";
            //info.Id = Utils.GuId();
            //info.infoid = "123";
            //info.InternalData = "";
            //info.ipadress = "";
            //info.lurl = "123";
            //info.mid = "123";
            //info.moreCol = "";
            //info.moreCol1 = "";
            //info.nid = "";
            //info.Phone = "15102105469";
            //info.PID = "";
            //info.scoreNum = 0;
            //info.SpecialData = "";
            //info.state = 0;
            //info.tid = 6;
            //info.trueName = "123123";
            //info.vContent = "0";
            //Task<string> task = _service.SubmitForm(info, "");
            try
            {
                ArrayList alist = new ArrayList();
                Dictionary<string, UseractioninfoEntity> list = MemoryCacheHelper.Get<Dictionary<string, UseractioninfoEntity>>("userVideoTime");
                if (list != null)
                {
                    foreach (var item in list)
                    {
                        UseractioninfoEntity info = (UseractioninfoEntity)item.Value;
                        if (Convert.ToInt32(info.vContent) > 0)
                        {
                            if (Convert.ToDateTime(info.createDate).AddSeconds(8) < DateTime.Now)
                            {
                                await _service.SubmitForm(info, "");
                                alist.Add(item.Key);
                            }
                        }

                    }
                }

                for (int i = 0; i < alist.Count; i++)
                {
                    list.Remove(alist[i].ToString());
                }

                MemoryCacheHelper.Set("userVideoTime", list);
            }
            catch (Exception)
            {

              
            }
          

            AjaxResult obj = new AjaxResult();

            try
            {
                
                obj.state = ResultType.success.ToString();
                obj.message = "服务器状态更新成功！";
            }
            catch (Exception ex)
            {
                obj.state = ResultType.error.ToString();
                obj.message = "服务器状态更新失败！" + ex.Message;
            }
            return obj;
        }
    }
}
