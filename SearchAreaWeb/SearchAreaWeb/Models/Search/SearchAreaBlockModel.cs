using System;

namespace SearchAreaWeb.Models
{
    public class SearchAreaBlockModel
    {
	    public SearchAreaBlockModel()
	    {
	    }

        public SearchAreaBlockModel(double longitude, double latitude, int row, int column, string searchAreaId, bool isComplete)
        {
            Latitude = longitude;
            Longitude = latitude;
            Row = row;
            Column = column;
            SearchAreaId = searchAreaId;
            IsComplete = isComplete;
        }

        public double Latitude { get; private set; }
        public double Longitude { get; private set; }
        public int Row { get; private set; }
        public int Column { get; private set; }
        public string SearchAreaId { get; private set; }
        public bool IsComplete { get; private set; }

    }
}