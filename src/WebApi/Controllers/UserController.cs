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
    [Route("api/users")]
    public class UserController : BaseController
    {
        public UserController(IDataService dataService) : base(dataService)
        {
        }
        // GET api/users
        [HttpGet(Name = Config.UsersRoute)]

        public IActionResult Get(int page = 0, int pagesize = Config.DefaultPageSize)
        {
            var data = DataService.GetUser(page, pagesize)
                .Select(u => ModelFactory.MapUser(u, Url));
            var total = DataService.GetNumberOfUsers();

            var result = new
            {
                Total = total,
                Previous = PrevUrl(Url, Config.UsersRoute, page, pagesize),
                Next = NextUrl(Url, Config.UsersRoute, page, pagesize, total),
                Data = data
            };

            return Ok(result);
        }
        // GET api/users/1
        [HttpGet("{id}", Name = Config.UserRoute)]

        public IActionResult Get(int id)
        {
            User user = DataService.GetUser(id);
            if (user == null) return NotFound();
            return Ok(ModelFactory.MapUser(user, Url));
        }
    }
}
