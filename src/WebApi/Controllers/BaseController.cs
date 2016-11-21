using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatabaseService;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class BaseController : Controller
    {
        public IDataService DataService { get; }

        public BaseController(IDataService dataService)
        {
            DataService = dataService;
        }

        protected bool IsLastPage(int page, int pagesize, int total)
        {
            if (total - page * pagesize > 0)
            {
                return false;
            }
            return true;
        }

        protected static bool IsFirstPage(int page)
        {
            return page == 0;
        }
        //Navigate pages
        protected string NextUrl(IUrlHelper url, string route, int page, int pagesize, int total)
        {
            if (IsLastPage(page, pagesize, total)) return null;
            return url.Link(route, new { page = page + 1, pagesize }); 
        }
        protected string PrevUrl(IUrlHelper url, string route, int page, int pagesize)
        {
            if (IsFirstPage(page)) return null;
            return url.Link(route, new { page = page - 1, pagesize }); 
        }
    }
}
