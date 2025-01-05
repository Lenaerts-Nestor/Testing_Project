using System;
using System.Collections.Generic;
using CarDecisionApp.DecisionModule;
using CarDecisionApp.Interfaces;
using CarDecisionApp.Models;
using CarDecisionApp.Services;

string logFilePath = "application.log";
ILogger logger = new FileLogger(logFilePath);

//de locatie van de file zou in in de bin folder verschijnven, in mijn situatie is het :
//"C:\Users\dewil\Documents\Testing porject Nestor\Testing_project_nestor\Testing_project_nestor\bin\Debug\net8.0\application.log"

var decisionModule = new CarDecisionModule(logger);

//voorbeeld data :+>
var cars = new List<CarModel>
{
    new CarModel { Name = "Corolla", Horsepower = 132 },
    new CarModel { Name = "Civic", Horsepower = 158 },
    new CarModel { Name = "Camry", Horsepower = 203 }
};

Console.WriteLine("Enter the minimum horsepower threshold:");
if (int.TryParse(Console.ReadLine(), out int minHorsepower))
{
    try
    {
        var highPerformanceCars = decisionModule.GetHighPerformanceCars(cars, minHorsepower);

        Console.WriteLine($"Found {highPerformanceCars.Count} high-performance cars:");
        foreach (var car in highPerformanceCars)
        {
            Console.WriteLine($"- {car.Name} ({car.Horsepower} HP)");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
        logger.LogError($"Exception: {ex.Message}");
    }
}
else
{
    Console.WriteLine("Invalid input. Please enter a number.");
    logger.LogWarning("User entered invalid input for horsepower threshold.");
}

Console.WriteLine($"Logs have been written to {logFilePath}");