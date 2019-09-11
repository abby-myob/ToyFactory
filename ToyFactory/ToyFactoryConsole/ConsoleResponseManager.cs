using System;
using Csv;
using ToyFactoryLibrary;
using ToyFactoryLibrary.Interfaces;

namespace ToyFactoryConsole
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

        public ICsvLine Line { get; set; }
    }
}