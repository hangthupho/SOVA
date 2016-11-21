﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DomainModel
{
    public class Question
    {
        [Key]
        [ForeignKey("Post")]
        public int PostId { get; set; }
        public virtual Post Post { get; set; }

        public DateTime ClosedDate { get; set; }
        public string Title { get; set; }

        public virtual Comment Comment { get; set; }
    }
}
