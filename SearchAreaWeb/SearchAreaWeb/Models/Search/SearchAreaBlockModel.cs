using System;

using Parse;

namespace SearchAreaWeb.Models.Search
{
    public class SearchAreaBlockModel
    {
	    public SearchAreaBlockModel()
	    {
	    }

        public SearchAreaBlockModel(double longitude, double latitude, ParseGeoPoint location, int row, int column, string searchAreaId, bool isComplete)
        {
            Latitude = longitude;
            Longitude = latitude;
            Location = location;
            Row = row;
            Column = column;
            SearchAreaId = searchAreaId;
            IsComplete = isComplete;
        }

        public double Latitude { get; private set; }
        public double Longitude { get; private set; }
        public ParseGeoPoint Location { get; private set; }
        public int Row { get; private set; }
        public int Column { get; private set; }
        public string SearchAreaId { get; private set; }
        public bool IsComplete { get; private set; }

    }
}