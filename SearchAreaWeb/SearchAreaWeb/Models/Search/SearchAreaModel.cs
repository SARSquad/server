using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using SearchAreaWeb.Utils;

namespace SearchAreaWeb.Models.Search
{
    public class SearchAreaModel
    {
        public SearchAreaModel()
        {
        }

        public SearchAreaModel(string id, string name, string location, double neLng, double neLat, double swLng, double swLat, bool isComplete)
        {
            Verify.IsNotNullOrEmpty(id, "id");
            Verify.IsNotNullOrEmpty(name, "name");
            Verify.IsNotNullOrEmpty(location, "location");

            Id = id;
            Name = name;
            Location = location;
            NorthEastLongitude = neLng;
            NorthEastLatitude = neLat;
            SouthWestLongitude = swLng;
            SouthWestLatitude = swLat;
            IsComplete = isComplete;
        }

        public string Id { get; private set; }
        public string Name { get; private set; }
        public object Location { get; private set; }
        public double NorthEastLongitude { get; private set; }
        public double NorthEastLatitude { get; private set; }
        public double SouthWestLongitude { get; private set; }
        public double SouthWestLatitude { get; private set; }
        public bool IsComplete { get; private set; }
    }
}