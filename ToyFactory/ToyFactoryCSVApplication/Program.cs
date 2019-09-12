using ToyFactoryLibrary;

namespace ToyFactoryCSVApplication
{
    internal static class Program
    {
        private static void Main()
        {
            var orderManager = new OrderManager(new CsvResponseManager(), new CsvReportGenerator());
            var csvHandler = new CsvHandler(orderManager);

            csvHandler.ReadCsv("/Users/abby.thompson/Development/ToyFactory/Input");
            csvHandler.WriteInvoice("/Users/abby.thompson/Development/ToyFactory/Invoice");
            orderManager.GenerateCuttingListOverallReport();
            orderManager.GeneratePaintingOverallReport();
        }
    }
}