﻿using System.Collections.Generic;

namespace YMWeb.Code
{
    public class TreeGridModel
    {
        public string id { get; set; }
        public string code { get; set; }
        public string parentId { get; set; }
        public string title { get; set; }
        public object self { get; set; }
        public object checkArr { get; set; }
        public bool? disabled { get; set; }
        public List<TreeGridModel> children { get; set; }
    }
}
