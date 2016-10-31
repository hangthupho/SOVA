using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StackOverFLow.DomainModel
{
    public class posts
    {   
        public int postID { get; set; }
        public int score { get; set; }
        public string postBody { get; set; }
        public DateTime createdDate { get; set; }
        public int userID { get; set; }
    }
}
