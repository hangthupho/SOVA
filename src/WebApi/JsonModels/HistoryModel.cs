using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.JsonModels
{
    public class HistoryModel
    {
        public string Url { get; set; }
        public string SearchString { get; set; }
        public string SearchTime { get; set; }
    }
}
