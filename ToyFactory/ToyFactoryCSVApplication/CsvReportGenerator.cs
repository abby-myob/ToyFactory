using System.Collections.Generic;
using ToyFactoryLibrary.Interfaces;

namespace ToyFactoryCSVApplication
{
    public class CsvReportGenerator : IReportGenerator
    {
        public void GenerateInvoice(IOrder order)
        {
            throw new System.NotImplementedException();
        }

        public void GenerateCuttingListReport(IOrder order)
        {
            throw new System.NotImplementedException();
        }

        public void GeneratePaintingReport(IOrder order)
        {
            throw new System.NotImplementedException();
        }

        public void GenerateCuttingListOverallReport(List<IOrder> orders)
        {
            throw new System.NotImplementedException();
        }

        public void GeneratePaintingListOverallReport(List<IOrder> orders)
        {
            throw new System.NotImplementedException();
        }
    }
}