using System;

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
        void GenerateInvoice(IOrder order);
        void GenerateCuttingListReport(IOrder order);
        void GeneratePaintingReport(IOrder order);
    }
}