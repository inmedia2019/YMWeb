using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YMWeb.Domain
{
    public class LogoInfoEntity
    {
        public string title { get; set; }
        public string href { get; set; }
        public string image { get; set; }
        public LogoInfoEntity()
        {
            title = "YMWeb";
            href = "";
            image = "../icon/favicon.ico";
        }
    }
}