using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using YMWeb.Code;
using YMWeb.Domain.InfoManage;
using YMWeb.Service;
using Microsoft.AspNetCore.Authorization;
using YMWeb.Service.InfoManage;
using System.Net;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;

namespace YMWeb.Web.Areas.InfoManage.Controllers
{
    /// <summary>
    /// 创 建：超级管理员
    /// 日 期：2022-09-26 19:29
    /// 描 述：渠道链接控制器类
    /// </summary>
    [Area("InfoManage")]
    public class LinkinfoController :  ControllerBase
    {
        private string className = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.FullName.Split('.')[5];
        public LinkinfoService _service {get;set;}

        private readonly IHostingEnvironment _hostingEnvironment;

        public LinkinfoController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }


        #region 获取数据
        [HttpGet]
        [HandlerAjaxOnly]
        public async Task<ActionResult> GetGridJson(SoulPage<LinkinfoEntity> pagination, string keyword)
        {
            if (string.IsNullOrEmpty(pagination.field))
            {
                pagination.field = "createdate";
                pagination.order = "desc";
            }
            var data = await _service.GetLookList(pagination,keyword);
            return Content(pagination.setData(data).ToJson());
        }

        [HttpGet]
        [HandlerAjaxOnly]
        public async Task<ActionResult> GetListJson(string keyword)
        {
            var data = await _service.GetList(keyword);
            return Content(data.ToJson());
        }

        [HttpGet]
        [HandlerAjaxOnly]
        public async Task<ActionResult> GetFormJson(string keyValue)
        {
            var data = await _service.GetLookForm(keyValue);
            return Content(data.ToJson());
        }
        #endregion

        #region 提交数据
        [HttpPost]
        [HandlerAjaxOnly]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SubmitForm(LinkinfoEntity entity, string keyValue)
        {
           LinkinfoEntity data = null;
            if (!string.IsNullOrEmpty(keyValue))
            {
               data = await _service.GetForm(keyValue);
            }
            try
            {
                entity.createDate = DateTime.Now;
                if (string.IsNullOrEmpty(entity.ewmImg))
                {
                    entity.ewmImg = CreateDownLineQRCode(entity.F_LinkUrl);
                }

                await _service.SubmitForm(entity, keyValue);
                return await Success("操作成功。", className, entity, data, keyValue);

            }
            catch (Exception ex)
            {
                return await Error(ex.Message, className, entity, data, keyValue);
            }
        }

        /// <summary>
        /// 活动线下二维码
        /// </summary>
        /// <param name="infoId"></param>
        /// <returns></returns>
        public string CreateDownLineQRCode(string linkInfo)
        {
            string tokenUrl = "https://msdym.atline.cn/webapi/api/wechat/GetWeixinSign?url=https://msdym.atline.cn";

            string jsonToken = HttpHelper.HttpGet(tokenUrl);
            var obj = JsonConvert.DeserializeObject<WeiXinApiTokenInfo>(jsonToken);

          

            string url = "https://api.weixin.qq.com/wxa/getwxacode?access_token=" + obj.Data.token;
            string jsonStr = "{\"path\":\"" + linkInfo + "\",\"width\":1280}";
            string codeImg = PostMoths(url, jsonStr);
            return codeImg;
        }


        public string PostMoths(string url, string param)
        {
            string strURL = url;
            System.Net.HttpWebRequest request;
            request = (System.Net.HttpWebRequest)WebRequest.Create(strURL);
            request.Method = "POST";
            request.ContentType = "application/json;charset=UTF-8";
            string paraUrlCoded = param;
            byte[] payload;
            payload = System.Text.Encoding.UTF8.GetBytes(paraUrlCoded);
            request.ContentLength = payload.Length;
            Stream writer = request.GetRequestStream();
            writer.Write(payload, 0, payload.Length);
            writer.Close();
            System.Net.HttpWebResponse response;
            response = (System.Net.HttpWebResponse)request.GetResponse();
            System.IO.Stream s;
            s = response.GetResponseStream();//返回图片数据流
            byte[] tt = StreamToBytes(s);//将数据流转为byte[]


            string fileName = DateTime.Now.ToString("yyyyMMddHHmmss") + Guid.NewGuid().ToString() + ".jpg";

            string webRootPath = _hostingEnvironment.WebRootPath;
            //string contentRootPath = _hostingEnvironment.ContentRootPath;

            string path = webRootPath + "/uploads/" + fileName; //HttpContext.Server.MapPath("~/uploads/" + fileName);


            System.IO.File.WriteAllBytes(path, tt);//讲byte[]存储为图片
            return "/uploads/" + fileName;
        }

        public static byte[] StreamToBytes(Stream stream)
        {
            List<byte> bytes = new List<byte>();
            int temp = stream.ReadByte();
            while (temp != -1)
            {
                bytes.Add((byte)temp);
                temp = stream.ReadByte();
            }
            return bytes.ToArray();
        }

        [HttpPost]
        [HandlerAjaxOnly]
        [ServiceFilter(typeof(HandlerAuthorizeAttribute))]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteForm(string keyValue)
        {
           LinkinfoEntity data = null;
            if (!string.IsNullOrEmpty(keyValue))
            {
            data = await _service.GetForm(keyValue);
            }
            try
            {
                await _service.DeleteForm(keyValue);
                return await Success("操作成功。", className, data, data, keyValue, DbLogType.Delete);
            }
            catch (Exception ex)
            {
                return await Error(ex.Message, className, data, data, keyValue, DbLogType.Delete);
            }
        }
        #endregion
    }

    public class WeiXinApiTokenInfo
    { 
        public string Result { get; set; }
        public string Msg { get; set; }
        public WeixinTokenInfo Data { get; set; }
    }

    public class WeixinTokenInfo
    {
        public string timestamp { get; set; }
        public string appid { get; set; }
        public string nonceStr { get; set; }
        public string signature { get; set; }
        public string token { get; set; }
    }

}
