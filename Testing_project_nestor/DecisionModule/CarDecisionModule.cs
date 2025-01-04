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
        public List<CarModel> GetHighPerformanceCars(List<CarModel> cars, int minHorsepower)
        {
            return cars.Where(car => car.Horsepower >= minHorsepower).ToList();
        }
    }
}