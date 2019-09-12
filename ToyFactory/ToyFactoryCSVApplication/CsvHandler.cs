using System.IO;
using ToyFactoryLibrary;

namespace ToyFactoryCSVApplication
{
    public class CsvReader
    {
        private OrderManager OrderManager { get; }

        public CsvReader(OrderManager orderManager)
        {
            OrderManager = orderManager;
        }

        public void ReadCsv(string path)
        {
            var csvReader = File.ReadAllText(path);

            foreach (var line in Csv.CsvReader.ReadFromText(csvReader))
            {
                OrderManager.ResponseManager.Line = line;
                OrderManager.CollectOrder();
            }
        }
    }
}