using StackOverFLow.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseService
{
    public class PostExtended : Post
    {
        public string Title { get; internal set; }
        public string UserName { get; internal set; }

        //public List<int> AnswerId { get; internal set; }
        public List<string> AnswerBody { get; internal set; }
        //public List<Post> AnswerBody { get; internal set; }
        //public List<string> AnswerUserName { get; internal set; }

        //public List<string> CommentBody { get; internal set; }
        //public List<string> CommentUserName { get; internal set; }
    }
}
