using System.Collections.Generic;

namespace ToyFactoryLibrary.Interfaces
{
    public interface IReportGenerator
    {
        void GenerateInvoice(IOrder order);
        void GenerateCuttingListReport(IOrder order);
        void GeneratePaintingReport(IOrder order);
        void GenerateCuttingListOverallReport(List<IOrder> orders);
        void GeneratePaintingListOverallReport(List<IOrder> orders);
        void GenerateAllInvoices(List<IOrder> allOrders);
    }
}