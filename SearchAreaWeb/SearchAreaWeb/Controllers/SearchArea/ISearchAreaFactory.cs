using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using SearchAreaWeb.Models.Search;
using SearchAreaWeb.Utils;

using Parse;

namespace SearchAreaWeb.Controllers.SearchArea
{
    public interface ISearchAreaFactory
    {
        SearchAreaModel GenerateSearchArea(string name, AreaTypes areaType, ParseGeoPoint northeastGeopoint, ParseGeoPoint southwestGeopoint);
        List<SearchAreaBlockModel> GenerateBlocks(SearchAreaModel searchArea);
    }
}