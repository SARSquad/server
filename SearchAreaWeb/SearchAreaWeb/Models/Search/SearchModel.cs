using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SearchAreaWeb.Search.Models
{
    public class SearchModel
    {
        public SearchModel()
        {

        }

        public SearchModel(string name, string areaType, string northeastGeopoint, string soutwestGeopoint)
        {
            if (name == null)

            Name = name;
            AreaType = areaType;
            NortheastGeopoint = northeastGeopoint;
            SouthwestGeopoint = soutwestGeopoint;
        }

        public string Name { get; set; }
        public string AreaType { get; set; }
        public string NortheastGeopoint { get; set; }
        public string SouthwestGeopoint { get; set; }
    }
}