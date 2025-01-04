using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace CarDecisionApp.Models
{
    public class CarBrand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public int Founded { get; set; }
        public CityInfo City { get; set; }
        public string Website { get; set; }
        public string Logo { get; set; }
    }

    public class CityInfo
    {
        public string Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}