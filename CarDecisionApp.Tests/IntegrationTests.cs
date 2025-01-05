using CarDecisionApp.Interfaces;
using CarDecisionApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDecisionApp.Tests
{
    [TestClass]
    public class IntegrationTests
    {
        private const string MockApiBaseUrl = "http://localhost:3001/"; // Use Mockoon's URL
        private HttpClient _httpClient;
        private ICarModelApi _carModelApi;
        private ICarBrandApi _carBrandApi;

        [TestInitialize]
        public void Setup()
        {
            _httpClient = new HttpClient { BaseAddress = new System.Uri(MockApiBaseUrl) };
            _carModelApi = new CarModelApi(_httpClient);
            _carBrandApi = new CarBrandApi(_httpClient);
        }

        [TestMethod]
        public async Task CarModelApi_ReturnsCorrectData()
        {
            // Act
            var carModels = await _carModelApi.GetAllCarModelsAsyncMoock();

            // Assert
            Assert.AreEqual(2, carModels.Count);
            Assert.AreEqual("Corolla", carModels[0].Name);
            Assert.AreEqual(132, carModels[0].Horsepower);
            Assert.AreEqual("Civic", carModels[1].Name);
        }

        [TestMethod]
        public async Task CarBrandApi_ReturnsCorrectData()
        {
            // Act
            var carBrands = await _carBrandApi.GetAllCarBrandsAsyncMoock();

            // Assert
            Assert.AreEqual(2, carBrands.Count);
            Assert.AreEqual("Toyota", carBrands[0].Name);
            Assert.AreEqual("Honda", carBrands[1].Name);
        }
    }
}