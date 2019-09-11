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
            return ReadString(Constants.ColumnRedTriangles);
        }

        public int GetBlueTriangles()
        {
            return ReadString(Constants.ColumnBlueTriangles);
        }

        public int GetYellowTriangles()
        {
            return ReadString(Constants.ColumnYellowTriangles);
        }

        public int GetRedCircles()
        {
            return ReadString(Constants.ColumnRedCircles);
        }

        public int GetBlueCircles()
        {
            return ReadString(Constants.ColumnBlueCircles);
        }

        public int GetYellowCircles()
        {
            return ReadString(Constants.ColumnYellowCircles);
        }
    }
}