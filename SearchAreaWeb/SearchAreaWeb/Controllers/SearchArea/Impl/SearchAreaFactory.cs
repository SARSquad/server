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

            //Calculates the "X" distance for the search area in meters.
<<<<<<< HEAD
            double horizontalDistance = calculate(searchArea.NortheastLatitude,
                searchArea.NortheastLongitude, searchArea.NortheastLatitude, searchArea.SouthwestLongitude);
=======
            double horizontalDistance = calculate(searchArea.NortheastLatitude, 
                searchArea.NortheastLongitude, searchArea.NortheastLatitude ,searchArea.SouthwestLongitude);
>>>>>>> 9b599ba81b0a039a1a2dbae7a06d9c110831616e

            //Calculates the "Y" distance for the search area in meters.
            double verticalDistance = calculate(searchArea.NortheastLatitude,
                searchArea.NortheastLongitude, searchArea.SouthwestLatitude, searchArea.NortheastLongitude);

            //Calculates NE Corner Coordinates
<<<<<<< HEAD
            Tuple<double, double> NWCorner = new Tuple<double, double>(searchArea.NortheastLatitude, searchArea.SouthwestLongitude);
=======
            Tuple<double,double> NWCorner = new Tuple<double,double>(searchArea.NortheastLatitude,searchArea.SouthwestLongitude);
>>>>>>> 9b599ba81b0a039a1a2dbae7a06d9c110831616e

            //Assignes the vertical and horizontal values of the blocks to blockHeight and blockWidth based on the entered terrainType.
            double blockHeight;
            double blockWidth;
            switch (searchArea.AreaType)
            {
                case AreaTypes.Field:
                    blockHeight = 50;
                    blockWidth = 50;
                    break;
                case AreaTypes.Forest:
                    blockHeight = 25;
                    blockWidth = 25;
                    break;
                case AreaTypes.DenseForest:
                    blockHeight = 10;
                    blockWidth = 10;
                    break;
                case AreaTypes.Mountains:
                    blockHeight = 5;
                    blockWidth = 5;
                    break;
                default:
                    blockHeight = 0;
                    blockWidth = 0;
                    throw new InvalidOperationException();
            }
            //Calculates the number of blocks needed and creates an array with that ammount.
            int numberOfXBlocks = (int)Math.Ceiling(horizontalDistance / blockWidth);
            int numberOfYBlocks = (int)Math.Ceiling(verticalDistance / blockHeight);
            SearchAreaBlockModel[,] blockArray = new SearchAreaBlockModel[numberOfXBlocks, numberOfYBlocks];

            //creates a tuple with the coordinates for the first block.
            Tuple<double, double> block0Coords = calculateDisplacement(NWCorner.Item1, NWCorner.Item2, blockWidth / 2, -(blockHeight / 2));
            double arrayLatitude = block0Coords.Item1;
            double arrayLongitude = block0Coords.Item2;

            for (int row = 0; row < numberOfXBlocks; row++)
            {
                //if we're not on the first row, a change in the vertical coordinates for the array.
                if (row != 0)
                {
                    Tuple<double, double> vertChangeCoords = calculateDisplacement(arrayLatitude, arrayLongitude, 0, blockHeight);
                    arrayLatitude = vertChangeCoords.Item1;
                }
                for (int column = 0; column < numberOfYBlocks; column++)
                {
                    //if the end of the column is reached then the longitude is reset to the first blocks coordinates. 
                    if (column == 0)
                    {
                        //sets the array longitude to the first blocks longitude.
                        arrayLongitude = block0Coords.Item2;
                    }
<<<<<<< HEAD
                    //A random ID and a Geopoint for the block is created.
                    Guid randomID = System.Guid.NewGuid();
                    string id = randomID.ToString();
                    ParseGeoPoint arrayLocation = new ParseGeoPoint(arrayLatitude, arrayLongitude);

                    //A new searchAreaBlockModel is created in the curent cell with all the given information.
                    blockArray[row, column] = new SearchAreaBlockModel(arrayLongitude, arrayLatitude, arrayLocation, row, column, id, false);

                    //implements longitude change
                    Tuple<double, double> horizChangeCoords = calculateDisplacement(arrayLatitude, arrayLongitude, blockWidth, 0);
                    arrayLongitude = horizChangeCoords.Item2;
=======
                    //Otherwise the standard longitude change is calculated and enacted.
                    else
                    {
                        Tuple<double,double> horizChangeCoords = calculateDisplacement(arrayLatitude,arrayLongitude,blockWidth,0);
                        arrayLongitude = horizChangeCoords.Item2;
                    }
                    //A new searchAreaBlockModel is created in the curent cell.
                    ParseGeoPoint arrayLocation = new ParseGeoPoint(arrayLatitude, arrayLongitude);
                    blockArray[row, column] = new SearchAreaBlockModel(arrayLongitude,arrayLatitude, arrayLocation,row, column, id, false);
>>>>>>> 9b599ba81b0a039a1a2dbae7a06d9c110831616e

                }
            }

            //Adds the blockArray to a list in order from the top left to the bottom right.
            List<SearchAreaBlockModel> lastList = new List<SearchAreaBlockModel>();
            for (int row = 0; row < numberOfXBlocks; row++)
            {
                for (int column = 0; column < numberOfYBlocks; column++)
                {
                    lastList.Add(blockArray[row, column]);
                }
            }
            return lastList;

        }

        public static Tuple<double,double> calculateDisplacement(double lat, double lon, double EOffset, double NOffset )
        {
            //If you’re willing to accept errors above 10m for points offset more than approx 200m you may use a simplified flat earth calculation. 
            //I think the errors still will be less than 50m for offsets up to 1km.
            //source: http://gis.stackexchange.com/questions/2951/algorithm-for-offsetting-a-latitude-longitude-by-some-amount-of-meters?lq=1
            //what follows is the simplified flat earth method.
            
            //Earth’s radius, sphere
            int R=6378137;

            //Coordinate offsets in radians
            double dLat = NOffset/R;
            double dLon = EOffset/(R*Math.Cos(Math.PI*lat/180));

            //OffsetPosition, decimal degrees
            double latO = lat + dLat * 180/Math.PI;
            double lonO = lon + dLon * 180/Math.PI;
            return new Tuple<double, double>(latO, lonO);
        }
        public static Tuple<double,double> calculateComplexDisplacement(double lat, double lon, double bearing, double distance)
        {
                 //Most accurate and complex method
                double lat1 = Math.Asin(Math.Sin(lat)*Math.Cos(distance)+Math.Cos(lat)*Math.Sin(distance)*Math.Cos(bearing));
                double lon1;
                if(Math.Cos(lat1)==0)
                {
                    lon1 = lon;
                }
                else 
                {
                    lon1 = ((lon-Math.Asin(Math.Sin(bearing)*Math.Sin(distance)/Math.Cos(lat1)) + Math.PI)%(2*Math.PI)) - Math.PI;
                }
                return new Tuple<double,double>(lat1,lon1);
            
         
            //Original Equation in pseudocode
            /*
            lat=asin(sin(lat1)*cos(d)+cos(lat1)*sin(d)*cos(tc))
            IF (cos(lat)=0)
                lon=lon1      // endpoint a pole
            ELSE
                lon=mod(lon1-asin(sin(tc)*sin(d)/cos(lat))+pi,2*pi)-pi
             * This algorithm is limited to distances such that dlon <pi/2, 
             * i.e those that extend around less than one quarter of the circumference of the earth in longitude. 
             * A completely general, but more complicated algorithm is necessary if greater distances are allowed:
             * find here http://williams.best.vwh.net/avform.htm#LL
             */
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