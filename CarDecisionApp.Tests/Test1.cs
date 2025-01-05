using CarDecisionApp.DecisionModule;
using CarDecisionApp.Models;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Client;

namespace CarDecisionApp.Tests
{
    [TestClass]
    public class CarDecisionModuleTests
    {
        // Deze test kijkt of de methode GetHighPerformanceCars werkt door auto's te kiezen
        // met genoeg pk (paardenkracht) boven een bepaalde grens.
        [TestMethod]
        public void GetHighPerformanceCars_retunsCorrct_whenHorsePowerIsMet()
        {
            //dit is om een beetje te denken hoe ik mijn code ga schrijven
            var logger = new TestLogger();
            var decisionModule = new CarDecisionModule(logger);
            var cars = new List<CarModel>
            {
                new CarModel { Name = "Model A", Horsepower = 150 },
                new CarModel { Name = "Model B", Horsepower = 100 }
            };

            var result = decisionModule.GetHighPerformanceCars(cars, 120);

            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("Model A", result[0].Name);
        }

        // Deze test controleert of de methode GetHighPerformanceCars een foutmelding geeft
        // als je een negatieve waarde invult voor paardenkracht (pk).
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetHighPerformanceCars_ThrowsException_whenHorsepowerIsNegative()
        {
            var logger = new TestLogger();
            var decisionModule = new CarDecisionModule(logger);
            decisionModule.GetHighPerformanceCars(new List<CarModel>(), -10);
        }
    }
}