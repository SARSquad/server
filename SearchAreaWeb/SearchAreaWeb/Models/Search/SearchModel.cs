using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SearchAreaWeb.Search.Models
{
    public class CreateSearchFormModel
    {
        public CreateSearchFormModel()
        {

        }

        public CreateSearchFormModel(string name, string areaType, string northEastLongitude, string northEastLatitude, string southWestLongitude, string southWestLatitude)
        {
            Name = name;
            AreaType = areaType;
            
            try
            {
                NortheastLongitude = double.Parse(northEastLongitude);
                NortheastLatitude = double.Parse(northEastLatitude);
                SouthwestLongitude = double.Parse(southWestLongitude);
                SouthwestLatitude = double.Parse(southWestLatitude);
            }
            catch (FormatException e)
            {
                // TODO: Handle this
            }
        }

        public string Name { get; set; }
        public string AreaType { get; set; }
        public double NortheastLongitude { get; private set; }
        public double NortheastLatitude { get; private set; }
        public double SouthwestLongitude { get; private set; }
        public double SouthwestLatitude { get; private set; }
    }
}