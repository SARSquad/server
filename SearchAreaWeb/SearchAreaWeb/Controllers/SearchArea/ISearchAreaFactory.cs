﻿using System;
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
        public SearchAreaModel GenerateSearchArea(string name, AreaType areaType, ParseGeoPoint northeastGeopoint, ParseGeoPoint southwestGeopoint);
        public List<SearchAreaBlockModel> GenerateBlocks(SearchAreaModel searchArea);
    }
}