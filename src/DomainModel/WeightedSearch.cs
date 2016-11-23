using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DomainModel
{
    public class WeightedSearch
    {
        [Key]
        public int Id { get; set; }
        [Column("rank")]
        public double? Rank { get; set; }
        [Column("postBody")]
        public string PostBody { get; set; }

    }
}
