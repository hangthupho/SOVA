using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.JsonModels
{
    public class UserModel
    {
        public string name { get; set; }
        public string location { get; set; }
        public int age { get; set; }
        public DateTime creationDate { get; set; }
    }
}
