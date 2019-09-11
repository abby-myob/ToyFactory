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
            var orderManager = new OrderManager(new CsvResponseManager(), new ConsoleReportGenerator());
            var csvHandler = new CsvHandler(orderManager);

           csvHandler.ReadCsv(orderManager);

            foreach (var order in orderManager.Orders)
            {
                orderManager.GenerateReports(order.OrderNumber);
            }

            // TODO change the due date date time format bro. and clean everything up! BEFORE MIDDAY 
            // TODO Extract out the csv stuff into a csv handler

            csvHandler.WriteInvoiceToCsv();
            csvHandler.WriteCuttingListToCsv();
        }
    }

    public class CsvHandler
    {
        public OrderManager OrderManager { get; }

        public CsvHandler(OrderManager orderManager)
        {
            OrderManager = orderManager;
        }

        public void WriteCuttingListToCsv()
        {
            var columnNames = GenerateColumnNames();
            var orders = new List<string[]>();

            foreach (var order in OrderManager.Orders)
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
                }; // TODO can I take these and put them into the ToyBlockList? Since money is constant it shouldn't be bad. 
                orders.Add(info);
            }

            orders.ToArray();
            var csvWriter = CsvWriter.WriteToText(columnNames, orders, ',');
            File.WriteAllText("/Users/abby.thompson/Development/ToyFactory/Output", csvWriter);
        }

        public void ReadCsv()
        {
            var csvReader = File.ReadAllText("/Users/abby.thompson/Development/ToyFactory/Input");

            foreach (var line in CsvReader.ReadFromText(csvReader))
            {
                OrderManager.ResponseManager.Line = line;
                OrderManager.CollectOrder();
            }
        }

        public void WriteInvoiceToCsv()
        {
            var columnNames = GenerateColumnNames();
            var orders = new List<string[]>();

            foreach (var order in OrderManager.Orders)
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
                }; // TODO can I take these and put them into the ToyBlockList? Since money is constant it shouldn't be bad. 
                orders.Add(info);
            }

            orders.ToArray();
            var csvWriter = CsvWriter.WriteToText(columnNames, orders, ',');
            File.WriteAllText("/Users/abby.thompson/Development/ToyFactory/Output", csvWriter);
        }
        
        
        private string[] GenerateColumnNames()
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
            return columnNames;
        }
    }
}