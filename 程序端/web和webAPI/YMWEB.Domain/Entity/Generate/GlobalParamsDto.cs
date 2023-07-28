﻿using System;
using System.Collections.Generic;
using System.Text;

namespace YMWeb.Domain.Entity.Generate
{
    public class GlobalParamsDto
    {
        public static string RpcUname { get; set; }
        public static string RpcPwd { get; set; }

        /// <summary>
        /// 网站根目录
        /// </summary>
        public static string WebRoot { get; set; }

        public static string LastConnectionString { get; set; }

        /// <summary>
        /// 域名
        /// </summary>
        public static string Host { get; set; }

    }
}
