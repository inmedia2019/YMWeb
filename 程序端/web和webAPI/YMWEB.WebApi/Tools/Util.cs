using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YMWeb.WebApi.Models;

namespace YMWeb.WebApi.Tools
{
    /// <summary>
    /// 工具类
    /// </summary>
    public class Util
    {
      /// <summary>
      /// 获取返回类型
      /// </summary>
      /// <typeparam name="T">泛型</typeparam>
      /// <param name="data">数据</param>
      /// <returns></returns>
        public static ReturnTypeList<T> getReturnObjectByList<T>(IEnumerable<T> data)
        {
            var returnMsg = new ReturnTypeList<T>();
            if (data != null && data.Any())
            {
                returnMsg.Result = true;
                returnMsg.Data = data;
                returnMsg.Msg = "查询成功";
            }
            else
            {
                returnMsg.Result = false;
                returnMsg.Data = null;
                returnMsg.Msg = "查询内容为空";
            }
            return returnMsg;
        }
        /// <summary>
        /// 获取返回类型
        /// </summary>
        /// <typeparam name="T">泛型</typeparam>
        /// <param name="data">数据</param>
        /// <param name="msg">信息</param>
        /// <returns></returns>
        public static ReturnType<T> getReturnObject<T>(T data, string msg = "查询成功")
        {
            var returnMsg = new ReturnType<T>();
            if (data != null)
            {
                returnMsg.Result = true;
                returnMsg.Data = data;
                returnMsg.Msg = msg;
            }
            else
            {
                returnMsg.Result = false;
                returnMsg.Data = default(T);
                returnMsg.Msg = "查询内容为空";
            }
            return returnMsg;
        }

        /// <summary>
        /// 获取返回类型
        /// </summary>
        /// <typeparam name="T">泛型</typeparam>
        /// <param name="data">数据</param>
        /// <param name="msg">信息</param>
        /// <returns></returns>
        public static ReturnType<T> getReturnObjects<T>(T data, string msg = "操作成功")
        {
            var returnMsg = new ReturnType<T>();
            if (data != null)
            {
                returnMsg.Result = true;
                returnMsg.Data = data;
                returnMsg.Msg = msg;
            }
            else
            {
                returnMsg.Result = false;
                returnMsg.Data = default(T);
                returnMsg.Msg = "操作失败";
            }
            return returnMsg;
        }

        /// <summary>
        /// 获取返回类型
        /// </summary>
        /// <typeparam name="T">泛型</typeparam>
        /// <param name="data">数据</param>
        /// <param name="msg">信息</param>
        /// <returns></returns>
        public static ReturnType<T> getReturnObjectInfo<T>(T data, string msg = "操作成功", bool result = true)
        {
            var returnMsg = new ReturnType<T>();
            if (data != null)
            {
                if (result == false)
                {
                    returnMsg.Result = false;
                    returnMsg.Data = data;
                    returnMsg.Msg = "操作失败";
                }
                else
                {
                    returnMsg.Result = true;
                    returnMsg.Data = data;
                    returnMsg.Msg = msg;
                }
            }
            else
            {
                returnMsg.Result = false;
                returnMsg.Data = default(T);
                returnMsg.Msg = "操作失败";
            }
            return returnMsg;
        }

    }
}
