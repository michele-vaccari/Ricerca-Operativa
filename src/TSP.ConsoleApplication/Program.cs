using System;
using System.Collections.Generic;

namespace TSP.ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Logger.Info("Start TSP");

            Console.ReadLine();
            Logger.Info("End TSP");
        }

        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
    }
}
