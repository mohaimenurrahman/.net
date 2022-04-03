﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewsPortal.Models
{
    public class NewsModel
    {
        public int id { get; set; }
        public string title { get; set; }
        public System.DateTime post_date { get; set; }
        public int category_id { get; set; }
        public int author_id { get; set; }
    }
}