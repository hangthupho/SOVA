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
    [Route("api/comments")]
    public class CommentController : BaseController
    {
        public CommentController(IDataService dataService) : base(dataService)
        {
        }

        // GET api/comments
        [HttpGet(Name = Config.CommentsRoute)]

        public IActionResult Get(int page = 0, int pagesize = Config.DefaultPageSize)
        {
            var data = DataService.GetComment(page, pagesize)
                .Select(c => ModelFactory.MapComment(c, Url));
            var total = DataService.GetNumberOfComments();

            var result = new
            {
                Total = total,
                Previous = PrevUrl(Url, Config.CommentsRoute, page, pagesize),
                Next = NextUrl(Url, Config.CommentsRoute, page, pagesize, total),
                Data = data
            };

            return Ok(result);
        }

        // GET api/comments/5
        [HttpGet("{id}", Name = Config.CommentRoute)]
        public IActionResult Get(int id)
        {
            CommentExtended comment = DataService.GetComment(id);
            if (comment == null) return NotFound();
            return Ok(ModelFactory.MapComment(comment, Url));
        }

    }
   
}
