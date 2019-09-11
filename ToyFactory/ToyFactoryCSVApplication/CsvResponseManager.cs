using System;
using Csv;
using ToyFactoryLibrary.Interfaces;

namespace ToyFactoryCSVApplication
{
    public class CsvResponseManager : IResponseManager
    {
        public ICsvLine Line { get; set; }

        public string GetName()
        {
            return Line["Name"];
        }

        public string GetAddress()
        {
            return Line["Address"];
        }

        public DateTime GetDueDate()
        {
            return Convert.ToDateTime(Line["DueDate"]);
        }

        private int ReadString(string toy)
        {
            var line = Line[toy];
            return line == "" ? 0 : Convert.ToInt32(line);
        }

        public int GetRedSquares()
        {
            return ReadString("red squares");
        }

        public int GetBlueSquares()
        {
            return ReadString("blue squares");
        }

        public int GetYellowSquares()
        {
            return ReadString("yellow squares");
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