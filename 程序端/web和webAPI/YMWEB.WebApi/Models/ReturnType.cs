using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YMWeb.WebApi.Models
{
    /// <summary>
    /// 统一的返回类型
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ReturnType<T>
    {
        /// <summary>
        /// 是否成功
        /// </summary>
        public bool Result { get; set; }

        /// <summary>
        /// 详细信息
        /// </summary>
        public string Msg { get; set; }

        /// <summary>
        /// 数据内容
        /// </summary>
        public T Data { get; set; }
    }
}
