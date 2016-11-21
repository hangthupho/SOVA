using StackOverFLow.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.JsonModels
{
    public class PostDetailModel
    {
        public string Url { get; set; }
        public string Title { get; set; }
        public string PostBody { get; set; }
        public int Score { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UserName { get; set; }

        public IList<string> Answers { get; set; }
    }
}
