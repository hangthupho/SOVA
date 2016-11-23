using StackOverFLow.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseService
{
    public class PostExtended : Post
    {
        public string Title { get;  set; }
        public string UserName { get;  set; }
        public IList<string> Answers { get; set; }
    }
}
