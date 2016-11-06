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
    public class CommentsController : BaseController
    {
        public CommentsController(IDataService dataService) : base(dataService)
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
                Previous = GetPrevCommentUrl(Url, page, pagesize),
                Next = GetNextCommentUrl(Url, page, pagesize, total),
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

        // POST api/comments
        [HttpPost]
        public IActionResult Comment([FromBody] CommentModel model)
        {
            var comment = ModelFactory.MapComment(model);
            return Ok(DataService.AddComment(comment)); //ModelFactory.MapComment(comment, Url)
        }

        // PUT api/comments/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CommentModel model)
        {
            var comment = ModelFactory.MapComment(model);
            comment.CommentId = id;
            if (!DataService.UpdateComment(comment))
            {
                return NotFound();
            }
            return Ok();
        }

        // DELETE api/comments/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!DataService.DeleteComment(id))
            {
                return NotFound();
            }

            return Ok();
        }



    }
   
}
