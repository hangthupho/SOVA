using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatabaseService;
using Microsoft.AspNetCore.Mvc;
using WebApi.JsonModels;

namespace WebApi.Controllers
{
    [Route("api/posts")]
    public class PostsController : BaseController
    {
        public PostsController(IDataService dataService) : base(dataService)
        {
        }

        // GET api/posts
        [HttpGet(Name = Config.PostsRoute)]

        public IActionResult Get(int page = 0, int pagesize = Config.DefaultPageSize)
        {
            var data = DataService.GetPost(page, pagesize)
                .Select(c => ModelFactory.MapPost(c, Url));
            var total = DataService.GetNumberOfPosts();

            var result = new
            {
                Total = total,
                Previous = GetPrevUrl(Url, page, pagesize),
                Next = GetNextUrl(Url, page, pagesize, total),
                Data = data
            };

            return Ok(result);
        }

        // GET api/posts/19
        [HttpGet("{id}", Name = Config.PostRoute)]
        public IActionResult Get(int id)
        {
            PostExtended post = DataService.GetPost(id);
            if (post == null) return NotFound();
            return Ok(ModelFactory.MapPost(post, Url));
        }

    }
}
