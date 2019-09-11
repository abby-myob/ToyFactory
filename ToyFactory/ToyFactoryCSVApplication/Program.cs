using ToyFactoryLibrary;

namespace ToyFactoryCSVApplication
{
    internal static class Program
    {
        private static void Main()
        {
            var orderManager = new OrderManager(new CsvResponseManager(), new ConsoleReportGenerator());
            var csvHandler = new CsvHandler(orderManager);

            csvHandler.ReadCsv("/Users/abby.thompson/Development/ToyFactory/Input");
            csvHandler.WriteInvoice("/Users/abby.thompson/Development/ToyFactory/Invoice");
            csvHandler.WriteCuttingList("/Users/abby.thompson/Development/ToyFactory/CuttingList");
            csvHandler.WritePaintingReport("/Users/abby.thompson/Development/ToyFactory/PaintingList");
        }
    }
}