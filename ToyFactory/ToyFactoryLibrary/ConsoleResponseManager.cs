using System;
using System.Linq;
using ToyFactoryLibrary.Blocks;
using ToyFactoryLibrary.Enums;
using ToyFactoryLibrary.Interfaces;

namespace ToyFactoryLibrary
{
    public class ConsoleResponseManager : IResponseManager
    {
        public string GetName()
        {
            Console.Write(Constants.InputName);
            return Console.ReadLine();
        }

        public string GetAddress()
        {
            Console.Write(Constants.InputAddress);
            return Console.ReadLine();
        }

        public DateTime GetDueDate()
        {
            Console.Write(Constants.InputDueDate); 
            return Convert.ToDateTime(Console.ReadLine());
        }

        public int GetRedSquares()
        {
            Console.Write(Constants.InputRedSquare);
            return Convert.ToInt32(Console.ReadLine());
        }

        public int GetBlueSquares()
        {
            Console.Write(Constants.InputBlueSquare);
            return Convert.ToInt32(Console.ReadLine());
        }

        public int GetYellowSquares()
        {
            Console.Write(Constants.InputYellowSquare);
            return Convert.ToInt32(Console.ReadLine());
        }

        public int GetRedTriangles()
        {
            Console.Write(Constants.InputRedTriangle);
            return Convert.ToInt32(Console.ReadLine());
        }

        public int GetBlueTriangles()
        {
            Console.Write(Constants.InputBlueTriangle);
            return Convert.ToInt32(Console.ReadLine());
        }

        public int GetYellowTriangles()
        {
            Console.Write(Constants.InputYellowTriangle);
            return Convert.ToInt32(Console.ReadLine());
        }

        public int GetRedCircles()
        {
            Console.Write(Constants.InputRedCircle);
            return Convert.ToInt32(Console.ReadLine());
        }

        public int GetBlueCircles()
        {
            Console.Write(Constants.InputBlueCircle);
            return Convert.ToInt32(Console.ReadLine());
        }

        public int GetYellowCircles()
        {
            Console.Write(Constants.InputYellowCircle);
            return Convert.ToInt32(Console.ReadLine());
        }

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

        public void GenerateInvoice(IOrder order)
        {
            Console.WriteLine("");
            Console.WriteLine(Constants.InvoiceHasBeenGenerated);
            Console.WriteLine("");
            PrintOrderHeader(order);
            PrintToyBlockTable(order);
            Console.WriteLine("");
            Console.WriteLine(
                $"{Constants.SquaresText}                    {order.ToyBlocksList.TotalSquares} @ ${Constants.SquarePrice} {Constants.PPIText} ${order.ToyBlocksList.TotalSquares * Constants.SquarePrice}");
            Console.WriteLine(
                $"{Constants.TrianglesText}                  {order.ToyBlocksList.TotalTriangles} @ ${Constants.TrianglePrice} {Constants.PPIText} ${order.ToyBlocksList.TotalTriangles * Constants.TrianglePrice}");
            Console.WriteLine(
                $"{Constants.CirclesText}                    {order.ToyBlocksList.TotalCircles} @ ${Constants.SquarePrice} {Constants.PPIText} ${order.ToyBlocksList.TotalCircles * Constants.CirclePrice}");
            Console.WriteLine(
                $"{Constants.RedColourSurchargeText}       {order.ToyBlocksList.TotalRedBlocks} @ ${Constants.RedColourSurcharge} {Constants.PPIText} ${order.ToyBlocksList.TotalRedBlocks * Constants.RedColourSurcharge}");
        }

        private void PrintOrderHeader(IOrder order)
        {
            Console.Write($"{Constants.NameText}{order.Name}  ");
            Console.Write($"{Constants.AddressText}{order.Address}  ");
            Console.Write($"{Constants.DueDateText}{order.DueDate}  ");
            Console.Write($"{Constants.OrderNumberText}{order.OrderNumber}  \n");
        }

        private void PrintToyBlockTable(IOrder order)
        {
            Console.WriteLine(Constants.RowWithColours);
            Console.WriteLine(Constants.RowWithColoursLine);
            Console.WriteLine(
                $"{Constants.Column}{Constants.SquaresText}   " +
                $"{Constants.Column} {order.ToyBlocksList.RedTriangles}   " +
                $"{Constants.Column} {order.ToyBlocksList.RedTriangles}    " +
                $"{Constants.Column} {order.ToyBlocksList.RedTriangles}      " +
                $"{Constants.Column}");
            Console.WriteLine(
                $"{Constants.Column}{Constants.TrianglesText} " +
                $"{Constants.Column} {order.ToyBlocksList.RedTriangles}   " +
                $"{Constants.Column} {order.ToyBlocksList.RedTriangles}    " +
                $"{Constants.Column} {order.ToyBlocksList.RedTriangles}      " +
                $"{Constants.Column}");
            Console.WriteLine(
                $"{Constants.Column}{Constants.CirclesText}   " +
                $"{Constants.Column} {order.ToyBlocksList.RedTriangles}   " +
                $"{Constants.Column} {order.ToyBlocksList.RedTriangles}    " +
                $"{Constants.Column} {order.ToyBlocksList.RedTriangles}      " +
                $"{Constants.Column}");
        }
    }
}