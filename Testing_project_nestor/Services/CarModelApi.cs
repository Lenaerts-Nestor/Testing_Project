using CarDecisionApp.Interfaces;
using CarDecisionApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace CarDecisionApp.Services
{
    public class CarModelApi : ICarModelApi
    {
        //ik gebruik de api van de leerkracht similon van de cursus https://similonap.github.io/webframeworks-cursus/
        // u vind de api in deze link : https://sampleapis.assimilate.be/ en hiervoor moet ik de bearer token gebruiken, ik zal de API endpoint CAR gebruiken voor deze project.
        private readonly HttpClient _httpClient;

        public CarModelApi(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<CarModel>> GetAllCarModelsAsync()
        {
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJlbWFpbCI6InMxMjI0NTJAYXAuYmUiLCJpYXQiOjE3MzYwMzI1NjZ9.EwstgT36gVWTy-iFNIeV2X7qU_SbcS13gBWO_ysFwo8");

            var response = await _httpClient.GetFromJsonAsync<List<CarModel>>("https://sampleapis.assimilate.be/car-models");
            return response ?? new List<CarModel>();
        }
    }
}