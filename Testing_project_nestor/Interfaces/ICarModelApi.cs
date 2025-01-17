﻿using CarDecisionApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDecisionApp.Interfaces
{
    public interface ICarModelApi
    {
        Task<List<CarModel>> GetAllCarModelsAsync();

        Task<List<CarModel>> GetAllCarModelsAsyncMoock();
    }
}