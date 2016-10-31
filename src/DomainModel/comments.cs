using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StackOverFLow.DomainModel
{
    public class comments
    {
        public int commentID { get; set; }
        public int postID { get; set; }
        public int userID { get; set; }
        public string commentBody { get; set; }
        public DateTime commentCreationDate { get; set; }
    }
}
