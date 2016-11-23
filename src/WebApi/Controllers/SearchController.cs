using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatabaseService;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/search")]
    public class SearchController : BaseController
    {
        public SearchController(IDataService dataService) : base(dataService)
        {
        }
        [HttpGet("{searchkeyword}", Name = Config.SearchRoute)]
        public IActionResult Get(string searchkeyword)
        {

            var result = DataService.GetSearchedPost(searchkeyword);
            return Ok(result);
            //return Ok(searchkeyword);
        }
    }
}
