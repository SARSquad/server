﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Parse;

using SearchAreaWeb.Models.Search;

namespace SearchAreaWeb.Utils
{
    public static class ParseDBUtils
    { 
        public static void Initialize()
        {
            ParseClient.Initialize("SAlhWqn4ERwfsVT7MHjky4PLiURrI7tY1K3xF6Sa", 
                                   "hmS5OMLDGUfeLDwOF7EWoNgMcamuYhgABkq7N4Qy");
        }

        public async static void StoreSearchArea(SearchAreaModel searchAreaModel)
        {
            ParseObject searchArea = new ParseObject("SearchArea");

            searchArea["SearchAreaID"] = searchAreaModel.Id;
            searchArea["Location"] = searchAreaModel.Location;
            searchArea["NorthEastLng"] = searchAreaModel.NortheastLongitude;
            searchArea["NorthEastLat"] = searchAreaModel.NortheastLatitude;
            searchArea["SouthWestLng"] = searchAreaModel.SouthwestLongitude;
            searchArea["SouthWestLat"] = searchAreaModel.SouthwestLatitude;
            searchArea["isComlete"] = searchAreaModel.IsComplete;

            await searchArea.SaveAsync();
        }
    }
}