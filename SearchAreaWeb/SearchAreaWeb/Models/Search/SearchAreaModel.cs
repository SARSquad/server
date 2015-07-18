using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using SearchAreaWeb.Utils;

using Parse;

namespace SearchAreaWeb.Models.Search
{
    public class SearchAreaModel
    {
        public SearchAreaModel()
        {
        }

        public SearchAreaModel(string id, string name, AreaTypes areaType, ParseGeoPoint location, double neLng, double neLat, double swLng, double swLat, bool isComplete)
        {
            Verify.IsNotNullOrEmpty(id, "id");
            Verify.IsNotNullOrEmpty(name, "name");
            Verify.IsNotNull(location, "location");

            Id = id;
            Name = name;
            AreaType = areaType;
            Location = location;
            NortheastLongitude = neLng;
            NortheastLatitude = neLat;
            SouthwestLongitude = swLng;
            SouthwestLatitude = swLat;
            IsComplete = isComplete;
        }

        public string Id { get; private set; }
        public string Name { get; private set; }
        public AreaTypes AreaType { get; private set; }
        public ParseGeoPoint Location { get; private set; }
        public double NortheastLongitude { get; private set; }
        public double NortheastLatitude { get; private set; }
        public double SouthwestLongitude { get; private set; }
        public double SouthwestLatitude { get; private set; }
        public bool IsComplete { get; private set; }
    }
}