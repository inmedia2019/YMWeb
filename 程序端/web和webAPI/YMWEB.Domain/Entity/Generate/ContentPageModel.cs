﻿using System;
using System.Collections.Generic;
using System.Text;

namespace YMWeb.Domain.Entity.Generate
{
    public class ContentPageModel
    {
        public string PageHtml { get; set; } = "";
        public List<ContentModel> Contents { get; set; } = new List<ContentModel>();
    }
}
