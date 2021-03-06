﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

using SearchAreaWeb.Models.Search;

using Parse;

namespace SearchAreaWeb.Utils
{
    public static class ParseDBUtils
    { 
        public static void Initialize()
        {
            ParseClient.Initialize("SAlhWqn4ERwfsVT7MHjky4PLiURrI7tY1K3xF6Sa", 
                                   "hmS5OMLDGUfeLDwOF7EWoNgMcamuYhgABkq7N4Qy");
        }

        public static void StoreSearchArea(SearchAreaModel searchAreaModel)
        {
            ParseObject searchArea = new ParseObject("SearchArea");

            searchArea["SearchAreaID"] = searchAreaModel.Id;
            searchArea["Name"] = searchAreaModel.Name;
            searchArea["Location"] = searchAreaModel.Location;
            searchArea["NorthEastLng"] = searchAreaModel.NortheastLongitude;
            searchArea["NorthEastLat"] = searchAreaModel.NortheastLatitude;
            searchArea["SouthWestLng"] = searchAreaModel.SouthwestLongitude;
            searchArea["SouthWestLat"] = searchAreaModel.SouthwestLatitude;
            searchArea["IsComplete"] = searchAreaModel.IsComplete;

            searchArea.SaveAsync();
        }

        public static void StoreSearchAreaBlocks(string searchAreaId, List<SearchAreaBlockModel> searchAreaBlockModels)
        {
            List<ParseObject> searchAreaBlocks = new List<ParseObject>();

            foreach(SearchAreaBlockModel blockModel in searchAreaBlockModels) 
            {
                ParseObject block = new ParseObject("Block");

                block["Column"] = blockModel.Column;
                block["Row"] = blockModel.Row;
                block["Location"] = blockModel.Location;
                block["Latitude"] = blockModel.Location.Latitude;
                block["Longitude"] = blockModel.Location.Longitude;
                block["SearchAreaID"] = searchAreaId.ToString();
                block["IsComplete"] = blockModel.IsComplete;

                searchAreaBlocks.Add(block);
            }

            ParseObject.SaveAllAsync<ParseObject>(searchAreaBlocks);
            
        }
    }
}