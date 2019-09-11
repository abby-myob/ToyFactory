using System.Collections.Generic;
using System.Globalization;
using System.IO;
using Csv;
using ToyFactoryLibrary;

namespace ToyFactoryCSVApplication
{
    public class CsvHandler
    {
        private OrderManager OrderManager { get; }

        public CsvHandler(OrderManager orderManager)
        {
            OrderManager = orderManager;
        }

        public void ReadCsv(string path)
        {
            var csvReader = File.ReadAllText(path);

            foreach (var line in CsvReader.ReadFromText(csvReader))
            {
                OrderManager.ResponseManager.Line = line;
                OrderManager.CollectOrder();
            }
        }

        public void WriteInvoice(string path)
        {
            var columnNames = GenerateInvoiceColumnNames();
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
                };
                orders.Add(info);
            }

            orders.ToArray();
            var csvWriter = CsvWriter.WriteToText(columnNames, orders, ',');
            File.WriteAllText(path, csvWriter);
        }

        public void WriteCuttingList(string path)
        {
            var columnNames = GenerateCuttingListColumnNames();
            var orders = new List<string[]>();

            foreach (var order in OrderManager.Orders)
            {
                var info = new[]
                {
                    order.Name,
                    order.Address,
                    order.DueDate.ToString(CultureInfo.InvariantCulture),
                    order.OrderNumber.ToString(),
                    order.ToyBlocksList.TotalSquares.ToString(),
                    order.ToyBlocksList.TotalTriangles.ToString(),
                    order.ToyBlocksList.TotalCircles.ToString(),
                };
                orders.Add(info);
            }

            orders.ToArray();
            var csvWriter = CsvWriter.WriteToText(columnNames, orders, ',');
            File.WriteAllText(path, csvWriter);
        }

        public void WritePaintingReport(string path)
        {
            var columnNames = GeneratePaintingReportColumnNames();
            var orders = new List<string[]>();

            foreach (var order in OrderManager.Orders)
            {
                var info = new[]
                {
                    order.Name,
                    order.Address,
                    order.DueDate.ToString(CultureInfo.InvariantCulture),
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
            File.WriteAllText(path, csvWriter);
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
                Constants.RedColourSurchargeText
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