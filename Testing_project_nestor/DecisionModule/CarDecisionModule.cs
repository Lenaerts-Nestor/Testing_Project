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
            //kleine error handeling hier :=>
            if (minHorsepower < 0) throw new ArgumentException("horse power needs to be a positive number");
            return cars.Where(car => car.Horsepower >= minHorsepower).ToList();
        }
    }
}