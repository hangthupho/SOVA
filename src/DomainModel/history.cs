using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StackOverFLow.DomainModel
{
    public class History
    {
        [Key]
        public int sId { get; set; }
        public string SearchString { get; set; }
        public DateTime SearchTime { get; set; }
    }
}
