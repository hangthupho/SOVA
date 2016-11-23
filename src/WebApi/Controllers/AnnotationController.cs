using DatabaseService;
using DomainModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.JsonModels;

namespace WebApi.Controllers
{
    [Route("api/annotations")]
    public class AnnotationController : BaseController
    {
        public AnnotationController(IDataService dataService) : base(dataService)
        {
        }

        // GET api/annotations
        [HttpGet(Name = Config.AnnotationsRoute)]

        public IActionResult Get(int page = 0, int pagesize = Config.DefaultPageSize)
        {
            var data = DataService.GetAnnotation(page, pagesize)
                .Select(c => ModelFactory.MapAnnotation(c, Url));
            var total = DataService.GetNumberOfAnnotations();

            var result = new
            {
                Total = total,
                Previous = PrevUrl(Url, Config.AnnotationsRoute, page, pagesize),
                Next = NextUrl(Url, Config.AnnotationsRoute, page, pagesize, total),
                Data = data
            };

            return Ok(result);
        }

        // GET api/annotations/1
        [HttpGet("{id}", Name = Config.AnnotationRoute)]
        public IActionResult Get(int id)
        {
            Annotation annotation = DataService.GetAnnotation(id);
            if (annotation == null) return NotFound();
            return Ok(ModelFactory.MapAnnotation(annotation, Url));
        }

        // POST api/annotations
        [HttpPost]
        public IActionResult Annotation([FromBody] AnnotationModel model)
        {
            var annotation = ModelFactory.MapAnnotation(model);
            //return Ok(DataService.AddAnnotation(annotation));
            return Ok(DataService.AddAnnotation(annotation));
        }

        // PUT api/annotations/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] AnnotationModel model)
        {
            var annotation = ModelFactory.MapAnnotation(model);
            annotation.AnnotationId = id;
            if (!DataService.UpdateAnnotation(annotation))
            {
                return NotFound();
            }
            return Ok();
        }

        // DELETE api/annotations/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!DataService.DeleteAnnotation(id))
            {
                return NotFound();
            }

            return Ok();
        }



    }
}
