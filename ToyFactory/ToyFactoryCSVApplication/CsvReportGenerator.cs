using System.Collections.Generic;
using System.Globalization;
using System.IO;
using Csv;
using ToyFactoryLibrary;
using ToyFactoryLibrary.Interfaces;

namespace ToyFactoryCSVApplication
{
    // I've run out of time but I was in the process of
    // turning this csvHandler into an interface of the report generator 
    // That's why there are a lot of notImplemented Exceptions here
    internal class CsvReportGenerator : IReportGenerator
    {
        public void GenerateInvoice(IOrder order)
        {
            // TODO
        }

        public void GenerateCuttingListReport(IOrder order)
        {
            // TODO
        }

        public void GeneratePaintingReport(IOrder order)
        {
            // TODO
        }

        public void GenerateAllInvoices(List<IOrder> allOrders)
        {
            var columnNames = GenerateInvoiceColumnNames();
            var orders = new List<string[]>();

            foreach (var order in allOrders)
            {
                var info = new[]
                {
                    order.Name,
                    order.Address,
                    order.DueDate.ToString("dd-MMM-yy", CultureInfo.InvariantCulture),
                    order.OrderNumber.ToString(),
                    $"${order.SquaresPrice}",
                    $"${order.TrianglesPrice}",
                    $"${order.CirclesPrice}",
                    $"${order.RedSurchargePrice}",
                    $"${order.TotalPrice}",
                };
                orders.Add(info);
            }

            orders.ToArray();
            var csvWriter = CsvWriter.WriteToText(columnNames, orders, ',');
            File.WriteAllText("/Users/abby.thompson/Development/ToyFactory/Invoice", csvWriter);
        }

        public void GenerateCuttingListOverallReport(List<IOrder> allOrders)
        {
            var columnNames = GenerateCuttingListColumnNames();
            var orders = new List<string[]>();

            foreach (var order in allOrders)
            {
                var info = new[]
                {
                    order.Name,
                    order.Address,
                    order.DueDate.ToString("dd-MMM-yy", CultureInfo.InvariantCulture),
                    order.OrderNumber.ToString(),
                    order.ToyBlocksList.TotalSquares.ToString(),
                    order.ToyBlocksList.TotalTriangles.ToString(),
                    order.ToyBlocksList.TotalCircles.ToString(),
                };
                orders.Add(info);
            }

            orders.ToArray();
            var csvWriter = CsvWriter.WriteToText(columnNames, orders, ',');
            File.WriteAllText("/Users/abby.thompson/Development/ToyFactory/CuttingList", csvWriter);
        }

        public void GeneratePaintingListOverallReport(List<IOrder> allOrders)
        {
            var columnNames = GeneratePaintingReportColumnNames();
            var orders = new List<string[]>();

            foreach (var order in allOrders)
            {
                var info = new[]
                {
                    order.Name,
                    order.Address,
                    order.DueDate.ToString("dd-MMM-yy", CultureInfo.InvariantCulture),
                    order.OrderNumber.ToString(),
                    order.ToyBlocksList.RedSquares.ToString(),
                    order.ToyBlocksList.BlueSquares.ToString(),
                    order.ToyBlocksList.YellowSquares.ToString(),
                    order.ToyBlocksList.RedTriangles.ToString(),
                    order.ToyBlocksList.BlueTriangles.ToString(),
                    order.ToyBlocksList.YellowTriangles.ToString(),
                    order.ToyBlocksList.RedCircles.ToString(),
                    order.ToyBlocksList.BlueCircles.ToString(),
                    order.ToyBlocksList.YellowCircles.ToString(),
                };
                orders.Add(info);
            }

            orders.ToArray();
            var csvWriter = CsvWriter.WriteToText(columnNames, orders, ',');
            File.WriteAllText("/Users/abby.thompson/Development/ToyFactory/PaintingList", csvWriter);
        }


        private string[] GenerateCuttingListColumnNames()
        {
            var columnNames = new[]
            {
                Constants.ColumnName,
                Constants.ColumnAddress,
                Constants.ColumnDueDate,
                Constants.ColumnOrderNumber,
                Constants.SquaresText,
                Constants.TrianglesText,
                Constants.CirclesText
            };
            return columnNames;
        }


        private string[] GenerateInvoiceColumnNames()
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
                Constants.RedColourSurchargeText,
                Constants.TotalPriceText
            };
            return columnNames;
        }


        private string[] GeneratePaintingReportColumnNames()
        {
            var columnNames = new[]
            {
                Constants.ColumnName,
                Constants.ColumnAddress,
                Constants.ColumnDueDate,
                Constants.ColumnOrderNumber,
                Constants.ColumnRedSquares,
                Constants.ColumnBlueSquares,
                Constants.ColumnYellowSquares,
                Constants.ColumnRedTriangles,
                Constants.ColumnBlueTriangles,
                Constants.ColumnYellowTriangles,
                Constants.ColumnRedCircles,
                Constants.ColumnBlueCircles,
                Constants.ColumnYellowCircles,
            };
            return columnNames;
        }
    }
}