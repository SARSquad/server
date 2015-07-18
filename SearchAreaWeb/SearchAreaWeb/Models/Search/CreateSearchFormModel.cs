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

        public CreateSearchFormModel(string name, string areaType, string northeastLongitude, string northeastLatitude, string southwestLongitude, string southwestLatitude)
        {
            Name = name;
            AreaType = areaType;
            
            try
            {
                NortheastLongitude = double.Parse(northeastLongitude);
                NortheastLatitude = double.Parse(northeastLatitude);
                SouthwestLongitude = double.Parse(southwestLongitude);
                SouthwestLatitude = double.Parse(southwestLatitude);
            }
            catch (FormatException e)
            {
                // TODO: Handle this
            }
        }

        public string Name { get; set; }
        public string AreaType { get; set; }
        public double NortheastLongitude { get; set; }
        public double NortheastLatitude { get; set; }
        public double SouthwestLongitude { get; set; }
        public double SouthwestLatitude { get; set; }
    }
}