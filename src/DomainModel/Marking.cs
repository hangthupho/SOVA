using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StackOverFLow.DomainModel
{
    public class Marking
    {
        [Key]
        public int mId { get; set; }

        [ForeignKey("Post")]
        public int PostId { get; set; }
        public virtual Post Post { get; set; }
        public bool Status { get; set; }
    }
}
