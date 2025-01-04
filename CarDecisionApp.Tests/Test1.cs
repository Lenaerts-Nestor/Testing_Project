namespace CarDecisionApp.Tests
{
    [TestClass]
    public class CarDecisionModuleTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            //dit is om een beetje te denken hoe ik mijn code ga schrijven
            var decisionModule = new CarDecisionModule();
            var cars = new List<CarModel>
            {
                new CarModel { Name = "Model A", Horsepower = 150 },
                new CarModel { Name = "Model B", Horsepower = 100 }
            };

            var result = decisionModule.getBestCar(cars, 120);

            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("Model A", result[0].Name);
        }
    }
}