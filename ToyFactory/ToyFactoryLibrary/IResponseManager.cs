using System;

namespace ToyFactoryLibrary
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
    }
}