using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StackOverFLow.DomainModel
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

        public Question Question { get; set; }

    }
}
