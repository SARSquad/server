using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using SearchAreaWeb.Search.Models;
using SearchAreaWeb.Utils;
using System.Threading.Tasks;

namespace SearchAreaWeb.Controllers
{
    public class SearchController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(SearchModel model)
        {
            await Task.Run(() => ParseDBUtils.Test());

            return RedirectToAction("Index");
        }
    }
}