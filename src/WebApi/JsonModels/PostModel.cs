using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.JsonModels
{
    public class PostModel
    {
        public string Url { get; set; }
        public string Title { get; set; }
        public string PostBody { get; set; }
        public int Score { get; set; }
        public DateTime CreationDate { get; set; }
        public int UserID { get; set; }
        public string UserName { get; set; }

        //public virtual CommentModel CommentModel { get; set; }
    }
}
