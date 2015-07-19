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

using Parse;

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
        public ActionResult Create(CreateSearchFormModel model)
        {
            ParseDBUtils.Initialize();
            ISearchAreaFactory searchAreaFactory = new SearchAreaFactory();

            var northeastGeoPoint = new ParseGeoPoint(model.NortheastLatitude, model.NortheastLongitude);
            var southwestGeopoint = new ParseGeoPoint(model.SouthwestLatitude, model.SouthwestLongitude);

            var searchAreaModel = searchAreaFactory.GenerateSearchArea(model.Name, (AreaTypes)Enum.Parse(typeof(AreaTypes), model.AreaType), northeastGeoPoint, southwestGeopoint);
            ParseDBUtils.StoreSearchArea(searchAreaModel);

            var searchAreaBlockModels = searchAreaFactory.GenerateBlocks(searchAreaModel);
            ParseDBUtils.StoreSearchAreaBlocks(searchAreaModel.Id, searchAreaBlockModels);

            return RedirectToAction("Index");
        }
    }
}