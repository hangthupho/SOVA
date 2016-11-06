using StackOverFLow.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseService
{
    public class CommentExtended : Comment
    {
        public string PostTitle { get; internal set; }
        public string UserName { get; internal set; }
    }
}
