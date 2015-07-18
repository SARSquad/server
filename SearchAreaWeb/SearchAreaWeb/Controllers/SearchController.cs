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
            ParseDBUtils.Initialize();
            ISearchAreaFactory searchAreaFactory = new SearchAreaFactory();

            var northeastGeoPoint = new Parse.ParseGeoPoint(model.NortheastLongitude, model.NortheastLatitude);
            var southwestGeopoint = new Parse.ParseGeoPoint(model.SouthwestLongitude, model.SouthwestLatitude);

            var searchAreaModel = searchAreaFactory.GenerateSearchArea(model.Name, (AreaTypes)Enum.Parse(typeof(AreaTypes), model.AreaType), northeastGeoPoint, southwestGeopoint);
            ParseDBUtils.StoreSearchArea(searchAreaModel);

            return RedirectToAction("Index");
        }
    }
}