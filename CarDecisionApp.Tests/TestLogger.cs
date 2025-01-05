using CarDecisionApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDecisionApp.Tests
{
    public class TestLogger : ILogger
    {
        //dit doet niks , maar ik gebruik het om de Test1 deftig te runnen
        public void LogInfo(string message)
        { }

        public void LogWarning(string message)
        { }

        public void LogError(string message)
        { }
    }
}