using System;
using System.Collections.Generic;
using Csv;

namespace ToyFactoryLibrary.Interfaces
{
    public interface IResponseManager
    {
        string GetName();
        string GetAddress();
        DateTime GetDueDate(); 
        int GetRedSquares();
        int GetBlueSquares();
        int GetYellowSquares();
        int GetRedTriangles();
        int GetBlueTriangles();
        int GetYellowTriangles();
        int GetRedCircles();
        int GetBlueCircles();
        int GetYellowCircles();
        ICsvLine Line { get; set; }
    }
}