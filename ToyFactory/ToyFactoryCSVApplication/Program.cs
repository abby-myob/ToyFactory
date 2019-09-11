using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using Csv;
using ToyFactoryConsole;
using ToyFactoryLibrary; 

namespace ToyFactoryCSVApplication
{
    internal static class Program
    {
        private static void Main()
        {
            Console.WriteLine(Constants.Welcome);
            
            var orderManager = new OrderManager(new CsvResponseManager(), new ConsoleReportGenerator()); 
            
            ReadCsv(orderManager);
            
            foreach (var order in orderManager.Orders)
            { 
                orderManager.GenerateReports(order.OrderNumber);
            }
            
            //TODO change the due date date time format bro. and clean everything up! BEFORE MIDDAY 

            WriteToCsv(orderManager);
        }

        private static void ReadCsv(OrderManager orderManager)
        {
            var csvReader = File.ReadAllText("/Users/abby.thompson/Development/ToyFactory/Input");

            foreach (var line in CsvReader.ReadFromText(csvReader))
            {
                orderManager.ResponseManager.Line = line;
                orderManager.CollectOrder();
            }
        }

        private static void WriteToCsv(OrderManager orderManager)
        {
            var columnNames = new[]
                {
                    Constants.ColumnName, 
                    Constants.ColumnAddress, 
                    Constants.ColumnDueDate, 
                    Constants.ColumnOrderNumber, 
                    Constants.SquaresText, 
                    Constants.TrianglesText, 
                    Constants.CirclesText, 
                    Constants.RedColourSurchargeText
                };
            var orders = new List<string[]>();

            foreach (var order in orderManager.Orders)
            {
                var info = new[]
                {
                    order.Name,
                    order.Address,
                    order.DueDate.ToString(CultureInfo.InvariantCulture),
                    order.OrderNumber.ToString(),
                    $"${order.ToyBlocksList.TotalSquares * Constants.SquarePrice}",
                    $"${order.ToyBlocksList.TotalTriangles * Constants.TrianglePrice}",
                    $"${order.ToyBlocksList.TotalCircles * Constants.CirclePrice}",
                    $"${order.ToyBlocksList.TotalRedBlocks * Constants.RedColourSurcharge}"
                };
                orders.Add(info);
            }

            orders.ToArray();
            var csvWriter = CsvWriter.WriteToText(columnNames, orders, ',');
            File.WriteAllText("/Users/abby.thompson/Development/ToyFactory/Output", csvWriter);
        }
    }
}