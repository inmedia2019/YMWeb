﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YMWeb.Domain.ContentManage
{
    public class ColumnInfo
    {
        public string sign { get; set; }
        public string Id { get; set; }
        public string Title { get; set; }
        public string ParentId { get; set; }
        public int ColumnType { get; set; }
        public int opType { get; set; }
    }
}
