using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DomainModel
{
    public class SearchedResult
    {
        [Key]
        public int PostId { get; set; }
        public string PostBody { get; set; }
        public int Score { get; set; }
        public int UserId { get; set; }
    }
}