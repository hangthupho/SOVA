using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StackOverFLow.DomainModel
{
    public class Answer
    {
        [Key]
        [ForeignKey("Post")]
        public int PostId { get; set; }
        public virtual Post Post { get; set; }

        public int ParentId { get; set; }

    }
}
