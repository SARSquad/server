using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using SearchAreaWeb.Models.Search;
using SearchAreaWeb.Utils;
using Parse;

namespace SearchAreaWeb.Controllers.SearchArea.Impl
{
    public class SearchAreaFactory : ISearchAreaFactory
    {
        public Models.Search.SearchAreaModel GenerateSearchArea(string name, AreaTypes areaType, ParseGeoPoint northeastGeopoint, ParseGeoPoint southwestGeopoint)
        {
            Guid id = Guid.NewGuid();
            string id_str = id.ToString();

            double neLng = northeastGeopoint.Longitude;
            double neLat = northeastGeopoint.Latitude;
            double swLng = southwestGeopoint.Longitude;
            double swLat = southwestGeopoint.Latitude;

            SearchAreaModel searchAreaModel = new SearchAreaModel(id_str, name, areaType, northeastGeopoint, neLng, neLat, swLng, swLat, false);

            return searchAreaModel;
        }

        public List<SearchAreaBlockModel> GenerateBlocks(SearchAreaModel searchArea)
        {
            throw new NotImplementedException();
        }
    }
}