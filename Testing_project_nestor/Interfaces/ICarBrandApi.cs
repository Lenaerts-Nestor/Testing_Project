using CarDecisionApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDecisionApp.Interfaces
{
    public interface ICarBrandApi
    {
        Task<List<CarBrand>> GetAllCarBrandsAsync();

        Task<List<CarBrand>> GetAllCarBrandsAsyncMoock();
    }
}