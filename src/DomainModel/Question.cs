using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StackOverFLow.DomainModel
{
    public class Question
    {
        [Key]
        [ForeignKey("Post")]
        public int PostId { get; set; }
        public virtual Post Post { get; set; }

        public DateTime ClosedDate { get; set; }
        public string Title { get; set; }

        public Comment Comment { get; set; }
    }
}
