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
            //Properties of the search zone.
            String terrainType = "Open";

            //Calculates the "X" distance for the search area in meters.
            double horizontalDistance = calculate(searchArea.NortheastLatitude, 
                searchArea.NortheastLongitude, searchArea.SouthwestLatitude ,searchArea.NortheastLongitude);

            //Calculates the "Y" distance for the search area in meters.
            double verticalDistance = calculate(searchArea.NortheastLatitude,
                searchArea.NortheastLongitude, searchArea.NortheastLatitude, searchArea.NortheastLongitude);

            //Assignes the vertical and horizontal values of the blocks to blockHeight and blockWidth based on the entered terrainType.
            double blockHeight;
            double blockWidth;
            switch (terrainType)
            {
                case "Open":
                case "open":
                    blockHeight = verticalDistance / 50;
                    blockWidth = horizontalDistance / 50;
                    break;
                case "Forrest":
                case "forrest":
                    blockHeight = verticalDistance/25;
                    blockWidth = horizontalDistance / 25;
                    break;
                case "Dense":
                case "dense":
                    blockHeight = verticalDistance/10;
                    blockWidth = horizontalDistance / 10;
                    break;
                default:
                    blockHeight = 0;
                    blockWidth = 0;
                    throw new InvalidOperationException();
            }

            double numberOfXBlocks = horizontalDistance / blockWidth;
            double numberOfYBlocks = verticalDistance / blockHeight;
            

            for (int i = 0; i < numberOfXBlocks; i++)
            {
                for (int j = 0; j < numberOfYBlocks; i++)
                {

                }
            }

            return null;

        }

        /// <summary>
        /// Calculates the distance between two points using the haversine formula and returns the result in meters.
        /// </summary>
        /// <param name="lat1">latitude of the first point.</param>
        /// <param name="lon1">longitude of the first point.</param>
        /// <param name="lat2">latitude of the second point.</param>
        /// <param name="lon2">longitude of the second point</param>
        /// <returns>The distance in meters</returns>
        public static double calculate(double lat1, double lon1, double lat2, double lon2)
        {
            double R = 6372.8; // In kilometers
            double dLat = toRadians(lat2 - lat1);
            double dLon = toRadians(lon2 - lon1);
            lat1 = toRadians(lat1);
            lat2 = toRadians(lat2);

            double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) + Math.Sin(dLon / 2) * Math.Sin(dLon / 2) * Math.Cos(lat1) * Math.Cos(lat2);
            double c = 2 * Math.Asin(Math.Sqrt(a));
            return (R * 2 * Math.Asin(Math.Sqrt(a))) * 1000;
        }
        /// <summary>
        /// Converts degree to radians.
        /// </summary>
        /// <param name="angle"></param>
        /// <returns>radian value</returns>
        public static double toRadians(double angle)
        {
            return Math.PI * angle / 180.0;
        }
    }
}