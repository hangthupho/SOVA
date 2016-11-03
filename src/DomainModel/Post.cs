﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DomainModel
{
    public class Post
    {
        public Post()
        {
            //this.tag = new HashSet<Tag>();
           
        }
        public int postID { get; set; }
        public int score { get; set; }
        public string postBody { get; set; }
        public DateTime createdDate { get; set; }
        public int userID { get; set; }

        public virtual User Users { get; set; }
        public ICollection<Tag> Tags { get; set; }

    }
}
