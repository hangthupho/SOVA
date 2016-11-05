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

        // GET api/values
        [HttpGet(Name = Config.PostsRoute)]

        public IActionResult Get(int page = 0, int pagesize = Config.DefaultPageSize)
        {
            var data = DataService.GetPost(page, pagesize)
                .Select(c => ModelFactory.Map(c, Url));
            var total = DataService.GetNumberOfPosts();

            var result = new
            {
                total = total,
                prev = GetPrevUrl(Url, page, pagesize),
                netx = GetNextUrl(Url, page, pagesize, total),
                data = data
            };

            return Ok(result);
        }

        // GET api/values/5
        [HttpGet("{id}", Name = Config.PostRoute)]
        public IActionResult Get(int id)
        {
            PostExtended post = DataService.GetPost(id);
            if (post == null) return NotFound();
            return Ok(ModelFactory.Map(post, Url));
        }

        //// POST api/values
        //[HttpPost]
        //public IActionResult Post([FromBody] PostModel model)
        //{
        //    var post = ModelFactory.Map(model);
        //    DataService.AddPost(post);
        //    return Ok(ModelFactory.Map(post, Url));
        //}

        //// PUT api/values/5
        //[HttpPut("{id}")]
        //public IActionResult Put(int id, [FromBody] PostModel model)
        //{
        //    var post = ModelFactory.Map(model);
        //    post.Id = id;
        //    if (!DataService.UpdatePost(post))
        //    {
        //        return NotFound();
        //    }
        //    return Ok();
        //}

        //// DELETE api/values/5
        //[HttpDelete("{id}")]
        //public IActionResult Delete(int id)
        //{
        //    if (!DataService.DeletePost(id))
        //    {
        //        return NotFound();
        //    }

        //    return Ok();
        //}


        
    }
}
