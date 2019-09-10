using System;
using ToyFactoryLibrary.Interfaces;

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
        void PrintInvoice(IOrder order);
        void PrintCuttingListReport(IOrder order);
        void PrintPaintingReport(IOrder order);
    }
}