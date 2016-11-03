﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.JsonModels
{
    public class PostCreateModel
    {
        public string Url { get; set; }
        public int score { get; set; }
        public string postBody { get; set; }
        public DateTime createdDate { get; set; }
        public int userID { get; set; }
        public string tag { get; set; }
    }
}
