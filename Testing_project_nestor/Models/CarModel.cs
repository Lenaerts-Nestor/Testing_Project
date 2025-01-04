using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDecisionApp.Models
{
    public class CarModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BrandId { get; set; }
        public string Type { get; set; }
        public int Year { get; set; }
        public string FuelType { get; set; }
        public int TopSpeedKmh { get; set; }
        public double Acceleration0To100Kmh { get; set; }
        public int Horsepower { get; set; }
        public string Transmission { get; set; }
        public int SeatingCapacity { get; set; }
    }
}