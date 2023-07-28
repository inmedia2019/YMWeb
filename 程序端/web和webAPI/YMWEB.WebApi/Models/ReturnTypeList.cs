using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YMWeb.WebApi.Models
{
    /// <summary>
    /// 统一的数组返回类型
    /// </summary>
    public class ReturnTypeList<T>
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
        public IEnumerable<T> Data { get; set; }
    }
}
