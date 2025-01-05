using CarDecisionApp.DecisionModule;
using CarDecisionApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace CarDecisionApp.Tests
{
    [Binding]
    public class AcceptanceSteps
    {
        private List<CarModel> _cars;
        private List<CarModel> _filteredCars;
        private CarDecisionModule _decisionModule;

        public AcceptanceSteps()
        {
            _decisionModule = new CarDecisionModule();
        }

        [Given(@"a list of cars")]
        public void GivenAListOfCars()
        {
            _cars = new List<CarModel>
            {
                new CarModel { Name = "Corolla", Horsepower = 132 },
                new CarModel { Name = "Civic", Horsepower = 158 },
                new CarModel { Name = "Mustang", Horsepower = 450 }
            };
        }

        [When(@"I filter the list with a minimum horsepower of (.*)")]
        public void WhenIFilterTheListWithAMinimumHorsepowerOf(int minHorsepower)
        {
            _filteredCars = _decisionModule.GetHighPerformanceCars(_cars, minHorsepower);
        }

        [Then(@"I should see only cars with horsepower above (.*)")]
        public void ThenIShouldSeeOnlyCarsWithHorsepowerAbove(int minHorsepower)
        {
            foreach (var car in _filteredCars)
            {
                Assert.IsTrue(car.Horsepower > minHorsepower, $"Car {car.Name} has horsepower {car.Horsepower}, which is not above {minHorsepower}.");
            }
        }
    }
}