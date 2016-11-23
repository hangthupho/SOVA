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
    public class PostController : BaseController
    {
        public PostController(IDataService dataService) : base(dataService)
        {
        }

        // GET api/posts
        [HttpGet(Name = Config.PostsRoute)]

        public IActionResult Get(int page = 0, int pagesize = Config.DefaultPageSize)
        {
            var total = DataService.GetNumberOfPosts();

            var data = DataService.GetListOfPosts(page, pagesize)
                .Select(c => ModelFactory.MapPostList(c, Url));
            

            var result = new
            {
                Total = total,
                Previous = PrevUrl(Url, Config.PostsRoute, page, pagesize), 
                Next = NextUrl(Url, Config.PostsRoute, page, pagesize, total), 
                Data = data
            };

            return Ok(result);
        }

        // GET api/posts/19
        [HttpGet("{id}", Name = Config.PostRoute)]
        public IActionResult Get(int id)
        {

            PostExtended post = DataService.GetPostDetail(id);
            if (post == null) return NotFound();
            return Ok(ModelFactory.MapPostDetail(post, Url));
        }
        

    }
}
