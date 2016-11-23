using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.JsonModels
{
    public class CommentModel
    {
        public string Url { get; set; }
        //public int CommentId { get; set; }
        public int PostId { get; set; }
        public int UserId { get; set; }
        public string CommentBody { get; set; }
        public DateTime CommentCreationDate { get; set; }
        public string UserName { get; set; }
        public string PostTitle { get; set; }
    }
}
