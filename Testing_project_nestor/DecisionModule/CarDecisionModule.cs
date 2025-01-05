using CarDecisionApp.Interfaces;
using CarDecisionApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDecisionApp.DecisionModule
{
    public class CarDecisionModule
    {
        private readonly ILogger _logger;

        public CarDecisionModule()
        { }

        public CarDecisionModule(ILogger logger)
        {
            _logger = logger;
        }

        public List<CarModel> GetHighPerformanceCars(List<CarModel> cars, int minHorsepower)
        {
            if (minHorsepower < 0)
            {
                _logger.LogError("Invalid horsepower threshold provided.");
                throw new ArgumentException("Horsepower must be non-negative.");
            }

            _logger.LogInfo($"Filtering cars with horsepower >= {minHorsepower}");
            var filteredCars = cars.Where(car => car.Horsepower >= minHorsepower).ToList();
            _logger.LogInfo($"Found {filteredCars.Count} high-performance cars.");

            return filteredCars;
        }
    }
}