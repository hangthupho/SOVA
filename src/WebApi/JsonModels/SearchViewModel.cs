using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.JsonModels
{
    public class SearchViewModel
    {
            public string Url { get; set; }
            public double? Rank { get; set; }
            public string PostBody { get; set; }
    }
}
