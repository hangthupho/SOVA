﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DomainModel
{
    public class comments
    {
        public comments()
        {
            this.Posts = new HashSet<Post>();
            this.Users = new HashSet<User>();
        }
        public int commentID { get; set; }
        public Nullable<int> postID { get; set; }
        public Nullable<int> userID { get; set; }
        public string commentBody { get; set; }
        public DateTime commentCreationDate { get; set; }

        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
    }
}
