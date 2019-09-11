using System;
using System.Collections.Generic;
using ToyFactoryLibrary.Interfaces;

namespace ToyFactoryLibrary
{
    public class CsvResponseManager : IResponseManager
    {
        public string GetName()
        {
            throw new NotImplementedException();
        }

        public string GetAddress()
        {
            throw new NotImplementedException();
        }

        public DateTime GetDueDate()
        {
            throw new NotImplementedException();
        }
        
        public int GetRedSquares()
        {
            throw new NotImplementedException();
        }

        public int GetBlueSquares()
        {
            throw new NotImplementedException();
        }

        public int GetYellowSquares()
        {
            throw new NotImplementedException();
        }

        public int GetRedTriangles()
        {
            throw new NotImplementedException();
        }

        public int GetBlueTriangles()
        {
            throw new NotImplementedException();
        }

        public int GetYellowTriangles()
        {
            throw new NotImplementedException();
        }

        public int GetRedCircles()
        {
            throw new NotImplementedException();
        }

        public int GetBlueCircles()
        {
            throw new NotImplementedException();
        }

        public int GetYellowCircles()
        {
            throw new NotImplementedException();
        }

        
        public void GenerateInvoice(IOrder order)
        {
            throw new NotImplementedException();
        }

        public void GenerateCuttingListReport(IOrder order)
        {
            throw new NotImplementedException();
        }

        public void GeneratePaintingReport(IOrder order)
        {
            throw new NotImplementedException();
        }

        public void GenerateCuttingListOverallReport(List<Order> orders)
        {
            throw new NotImplementedException();
        }

        public void GeneratePaintingListOverallReport(List<Order> orders)
        {
            throw new NotImplementedException();
        }
    }
}