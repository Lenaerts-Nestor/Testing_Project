using CarDecisionApp.Models;
using CarDecisionApp.Services;
using Moq;
using Moq.Protected;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace CarDecisionApp.Tests
{
    [TestClass]
    public class CarApiTests
    {
        //beste leerkracht , hier heb ik Protected() gebruik bij het setup van de Httprequestmessage, dit heb ik geleerd in de volgende links wnat ik kreeg errors de hele tijd:
        // 1 = https://www.damirscorner.com/blog/posts/20231222-MockingHttpClientInUnitTests.html#:~:text=If%20you're%20using%20Moq,(%20%22SendAsync%22%2C%20ItExpr.
        // 2 = https://code-maze.com/csharp-mock-httpclient-with-unit-tests/

        //wat ben ik hier aan testen ??? ik doe het volgende, de mock verteld de handler dat als die de http aanvraagt dat hij altijd OK gaat terug sturen, we zijn zzogezegd niet echt de api aan roepen maar
        // we zijn de code eigenlijk aan testen
        [TestMethod]
        public async Task GetAllCarModelsAsync_ReturnsCorrectModels()
        {
            var mockModels = new List<CarModel>
            {
                new CarModel { Id = 1, Name = "Corolla", Horsepower = 132 },
                new CarModel { Id = 2, Name = "Civic", Horsepower = 158 }
            };

            var mockHttpHandler = new Mock<HttpMessageHandler>();
            mockHttpHandler
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = System.Net.HttpStatusCode.OK,
                    Content = JsonContent.Create(mockModels)
                });

            var httpClient = new HttpClient(mockHttpHandler.Object);
            var carModelApi = new CarModelApi(httpClient);

            var models = await carModelApi.GetAllCarModelsAsync();

            Assert.AreEqual(2, models.Count);
            Assert.AreEqual("Corolla", models[0].Name);
            Assert.AreEqual("Civic", models[1].Name);
        }

        [TestMethod]
        public async Task GetAllCarBrandsAsync_ReturnsCorrectBrands()
        {
            var mockBrands = new List<CarBrand>
            {
                new CarBrand { Id = 1, Name = "Toyota" },
                new CarBrand { Id = 2, Name = "Honda" }
            };

            var mockHttpHandler = new Mock<HttpMessageHandler>();
            mockHttpHandler
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = System.Net.HttpStatusCode.OK,
                    Content = JsonContent.Create(mockBrands)
                });

            var httpClient = new HttpClient(mockHttpHandler.Object);
            var carBrandApi = new CarBrandApi(httpClient);

            var brands = await carBrandApi.GetAllCarBrandsAsync();

            Assert.AreEqual(2, brands.Count);
            Assert.AreEqual("Toyota", brands[0].Name);
            Assert.AreEqual("Honda", brands[1].Name);
        }
    }
}