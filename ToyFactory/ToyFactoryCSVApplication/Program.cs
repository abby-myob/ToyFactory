using ToyFactoryLibrary;

namespace ToyFactoryCSVApplication
{
    internal static class Program
    {
        private static void Main()
        {
            var orderManager = new OrderManager(new CsvResponseManager(), new CsvReportGenerator());
            
            var csvHandler = new CsvReader(orderManager);
            csvHandler.ReadCsv("/Users/abby.thompson/Development/ToyFactory/Input");
            
            orderManager.GenerateAllInvoices();
            orderManager.GenerateCuttingListOverallReport();
            orderManager.GeneratePaintingOverallReport();
        }
    }
}