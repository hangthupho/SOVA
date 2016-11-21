﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using DomainModel;


namespace DomainModel
{
    public class Post
    {
        [Key]
        public int PostId { get; set; }
        public int Score { get; set; }
        public string PostBody { get; set; }
        public DateTime CreatedDate { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual User User { get; set; }

        public virtual Question Question { get; set; }
        public virtual Answer Answer { get; set; }
        public virtual Comment Comment { get; set; }
        public virtual Linkpost Linkpost { get; set; }
        public virtual Tag Tag { get; set; }
    }
}
