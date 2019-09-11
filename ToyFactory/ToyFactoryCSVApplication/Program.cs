using System;
using System.IO;
using Csv;
using ToyFactoryLibrary; 

namespace ToyFactoryCSVApplication
{
    internal static class Program
    {
        private static void Main()
        {
            Console.WriteLine(Constants.Welcome);
            
            var orderManager = new OrderManager(new CsvResponseManager(), new CsvReportGenerator()); 
            
            var csvReader = File.ReadAllText("/Users/abby.thompson/Development/ToyFactory/Input");
            
            foreach (var line in CsvReader.ReadFromText(csvReader))
            { 
                orderManager.ResponseManager.Line = line;
                orderManager.CollectOrder();
            }

            foreach (var order in orderManager.Orders)
            {
                Console.WriteLine(order.Name);
                Console.WriteLine(order.Address);
                Console.WriteLine(order.DueDate);
                Console.WriteLine(order.OrderNumber);
                Console.WriteLine(order.ToyBlocksList);
            }
            
            // TODO print all to csv file
            
            var columnNames = new [] { "Id", "Name" };
            var rows = new [] 
            {
                new [] { "0", "John Doe" },
                new [] { "1", "Jane Doe" }
            };
            var csvWriter = CsvWriter.WriteToText(columnNames, rows, ',');
            File.WriteAllText("/Users/abby.thompson/Development/ToyFactory/Output", csvWriter);
        }
    }
}