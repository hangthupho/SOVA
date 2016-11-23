using DatabaseService;
using Microsoft.AspNetCore.Mvc;
using StackOverFLow.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.JsonModels;

namespace WebApi.Controllers
{
    [Route("api/posts")]
    public class TagController : BaseController
    {  
        public TagController(IDataService dataService) : base(dataService)
        {
        }

        // GET api/posts/19/tags
        [HttpGet("{postid:int}/tags", Name = Config.TagsRoute)]

        public IActionResult GetTags(int postid)
        {
            var data = DataService.GetPostTag(postid)
                .Select(c => ModelFactory.MapTag(c, Url));     
            if (data == null) return NotFound();
            return Ok(data);
        }
    }
}
