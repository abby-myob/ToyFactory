using System;
using Csv;
using ToyFactoryLibrary;
using ToyFactoryLibrary.Interfaces;

namespace ToyFactoryCSVApplication
{
    public class CsvResponseManager : IResponseManager
    {
        public ICsvLine Line { get; set; }

        public string GetName()
        {
            return Line[Constants.ColumnName];
        }

        public string GetAddress()
        {
            return Line[Constants.ColumnAddress];
        }

        public DateTime GetDueDate()
        {
            return Convert.ToDateTime(Line[Constants.ColumnDueDate]);
        }

        private int ReadString(string toy)
        {
            var line = Line[toy];
            return line == "" ? 0 : Convert.ToInt32(line);
        }

        public int GetRedSquares()
        {
            return ReadString(Constants.ColumnRedSquares);
        }

        public int GetBlueSquares()
        {
            return ReadString(Constants.ColumnBlueSquares);
        }

        public int GetYellowSquares()
        {
            return ReadString(Constants.ColumnYellowSquares);
        }

        public int GetRedTriangles()
        {
            return ReadString("red triangles");
        }

        public int GetBlueTriangles()
        {
            return ReadString("blue triangles");
        }

        public int GetYellowTriangles()
        {
            return ReadString("yellow triangles");
        }

        public int GetRedCircles()
        {
            return ReadString("red circles");
        }

        public int GetBlueCircles()
        {
            return ReadString("blue circles");
        }

        public int GetYellowCircles()
        {
            return ReadString("yellow circles");
        }
    }
}