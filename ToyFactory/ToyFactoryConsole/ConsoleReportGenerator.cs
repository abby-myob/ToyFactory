using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using ToyFactoryLibrary;
using ToyFactoryLibrary.Interfaces;

namespace ToyFactoryConsole
{
    public class ConsoleReportGenerator : IReportGenerator
    {
        public void GenerateCuttingListReport(IOrder order)
        {
            Console.WriteLine("");
            Console.WriteLine(Constants.CuttingListHasBeenGenerated);
            Console.WriteLine("");
            PrintOrderHeader(order);
            Console.WriteLine(Constants.RowWithQty);
            Console.WriteLine(Constants.RowWithQtyLine);
            Console.WriteLine(
                $"{Constants.Column}{Constants.SquaresText}   {Constants.Column} {order.ToyBlocksList.TotalSquares}  {Constants.Column}");
            Console.WriteLine(
                $"{Constants.Column}{Constants.TrianglesText} {Constants.Column} {order.ToyBlocksList.TotalTriangles}  {Constants.Column}");
            Console.WriteLine(
                $"{Constants.Column}{Constants.CirclesText}   {Constants.Column} {order.ToyBlocksList.TotalCircles}  {Constants.Column}");
        }

        public void GeneratePaintingReport(IOrder order)
        {
            Console.WriteLine("");
            Console.WriteLine(Constants.PaintingReportHasBeenGenerated);
            Console.WriteLine("");
            PrintOrderHeader(order);
            PrintToyBlockTable(order);
        }

        public void GenerateCuttingListOverallReport(List<IOrder> orders)
        {
            Console.WriteLine("");
            Console.WriteLine($"{Constants.OverallCuttingListHasBeenGenerated} : {DateTime.Today}");
            Console.WriteLine("");
            Console.WriteLine(Constants.RowWithQty);
            Console.WriteLine(Constants.RowWithQtyLine);
            Console.WriteLine(
                $"{Constants.Column}{Constants.SquaresText}   {Constants.Column} {orders.Sum(c => c.ToyBlocksList.TotalSquares)}  {Constants.Column}");
            Console.WriteLine(
                $"{Constants.Column}{Constants.TrianglesText} {Constants.Column} {orders.Sum(c => c.ToyBlocksList.TotalTriangles)}  {Constants.Column}");
            Console.WriteLine(
                $"{Constants.Column}{Constants.CirclesText}   {Constants.Column} {orders.Sum(c => c.ToyBlocksList.TotalCircles)}  {Constants.Column}");
        }

        public void GeneratePaintingListOverallReport(List<IOrder> orders)
        {
            Console.WriteLine("");
            Console.WriteLine($"{Constants.OverallPaintingReportHasBeenGenerated} : {DateTime.Today}");
            Console.WriteLine("");
            Console.WriteLine(Constants.RowWithColours);
            Console.WriteLine(Constants.RowWithColoursLine);
            Console.WriteLine(
                $"{Constants.Column}{Constants.SquaresText}   " +
                $"{Constants.Column} {orders.Sum(c => c.ToyBlocksList.RedSquares)}   " +
                $"{Constants.Column} {orders.Sum(c => c.ToyBlocksList.BlueSquares)}    " +
                $"{Constants.Column} {orders.Sum(c => c.ToyBlocksList.YellowSquares)}      " +
                $"{Constants.Column}");
            Console.WriteLine(
                $"{Constants.Column}{Constants.TrianglesText} " +
                $"{Constants.Column} {orders.Sum(c => c.ToyBlocksList.RedTriangles)}   " +
                $"{Constants.Column} {orders.Sum(c => c.ToyBlocksList.BlueTriangles)}    " +
                $"{Constants.Column} {orders.Sum(c => c.ToyBlocksList.YellowTriangles)}      " +
                $"{Constants.Column}");
            Console.WriteLine(
                $"{Constants.Column}{Constants.CirclesText}   " +
                $"{Constants.Column} {orders.Sum(c => c.ToyBlocksList.RedCircles)}   " +
                $"{Constants.Column} {orders.Sum(c => c.ToyBlocksList.BlueCircles)}    " +
                $"{Constants.Column} {orders.Sum(c => c.ToyBlocksList.YellowCircles)}      " +
                $"{Constants.Column}");
        }

        public void GenerateInvoice(IOrder order)
        {
            Console.WriteLine("");
            Console.WriteLine(Constants.InvoiceHasBeenGenerated);
            Console.WriteLine("");
            PrintOrderHeader(order);
            PrintToyBlockTable(order);
            Console.WriteLine("");
            Console.WriteLine(
                $"{Constants.SquaresText}                    {order.ToyBlocksList.TotalSquares} @ ${Constants.SquarePrice} {Constants.PPIText} ${order.SquaresPrice}");
            Console.WriteLine(
                $"{Constants.TrianglesText}                  {order.ToyBlocksList.TotalTriangles} @ ${Constants.TrianglePrice} {Constants.PPIText} ${order.TrianglesPrice}");
            Console.WriteLine(
                $"{Constants.CirclesText}                    {order.ToyBlocksList.TotalCircles} @ ${Constants.CirclePrice} {Constants.PPIText} ${order.CirclesPrice}");
            Console.WriteLine(
                $"{Constants.RedColourSurchargeText}       {order.ToyBlocksList.TotalRedBlocks} @ ${Constants.RedColourSurcharge} {Constants.PPIText} ${order.RedSurchargePrice}");
            Console.WriteLine(
                $"{Constants.TotalPriceText}                    ${order.TotalPrice}");
        }

        private void PrintOrderHeader(IOrder order)
        {
            Console.Write($"{Constants.ColumnName}: {order.Name}  ");
            Console.Write($"{Constants.ColumnAddress}: {order.Address}  ");
            Console.Write($"{Constants.ColumnDueDate}: {order.DueDate.ToString("dd-MMM-yy", CultureInfo.InvariantCulture)}");
            Console.Write($"{Constants.ColumnOrderNumber}: {order.OrderNumber}  \n");
        }

        private void PrintToyBlockTable(IOrder order)
        {
            Console.WriteLine(Constants.RowWithColours);
            Console.WriteLine(Constants.RowWithColoursLine);
            Console.WriteLine(
                $"{Constants.Column}{Constants.SquaresText}   " +
                $"{Constants.Column} {order.ToyBlocksList.RedSquares}   " +
                $"{Constants.Column} {order.ToyBlocksList.BlueSquares}    " +
                $"{Constants.Column} {order.ToyBlocksList.YellowSquares}      " +
                $"{Constants.Column}");
            Console.WriteLine(
                $"{Constants.Column}{Constants.TrianglesText} " +
                $"{Constants.Column} {order.ToyBlocksList.RedTriangles}   " +
                $"{Constants.Column} {order.ToyBlocksList.BlueTriangles}    " +
                $"{Constants.Column} {order.ToyBlocksList.YellowTriangles}      " +
                $"{Constants.Column}");
            Console.WriteLine(
                $"{Constants.Column}{Constants.CirclesText}   " +
                $"{Constants.Column} {order.ToyBlocksList.RedCircles}   " +
                $"{Constants.Column} {order.ToyBlocksList.BlueCircles}    " +
                $"{Constants.Column} {order.ToyBlocksList.YellowCircles}      " +
                $"{Constants.Column}");
        }
    }
}