using System;
using ToyFactoryLibrary;

namespace ToyFactoryConsole
{
    internal static class Program
    {
        private static void Main()
        {
            Console.WriteLine(Constants.Welcome);

            var orderManager = new OrderManager(new ConsoleResponseManager()); 

            Console.Write(Constants.HowManyOrders);
            var numOfOrders = Convert.ToInt32(Console.ReadLine());

            for (var i = 1; i <= numOfOrders; i++)
            {
                orderManager.CollectOrder();
            }

            for (int i = 1; i <= numOfOrders; i++)
            {
                orderManager.GenerateReports(i);
            }
            
            orderManager.GenerateCuttingListOverallReport();
            orderManager.GeneratePaintingOverallReport();
            
            Console.Write("What order would you like to search for?");
        }
    }
}