using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;

using SearchAreaWeb.Search.Models;
using SearchAreaWeb.Utils;
using SearchAreaWeb.Controllers.SearchArea;
using SearchAreaWeb.Controllers.SearchArea.Impl;

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
        public async Task<ActionResult> Create(CreateSearchFormModel model)
        {
            ISearchAreaFactory searchAreaFactory = new SearchAreaFactory();

            var northeastGeoPoint = new Parse.ParseGeoPoint(model.NortheastLongitude, model.NortheastLatitude);
            var southwestGeopoint = new Parse.ParseGeoPoint(model.NortheastLongitude, model.NortheastLatitude);

            var searchAreaModel = searchAreaFactory.GenerateSearchArea(model.Name, (AreaType)Enum.Parse(typeof(AreaType), model.AreaType), northeastGeoPoint, southwestGeopoint);

            return RedirectToAction("Index");
        }
    }
}