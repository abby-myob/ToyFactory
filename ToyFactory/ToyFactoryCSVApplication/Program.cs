using System;
using System.IO;
using CsvHelper;

namespace ToyFactoryCSVApplication
{
    internal class Program
    {
        private static void Main()
        {
            void Main()
            {
                using (var reader = new StreamReader("/Users/abby.thompson/Development/ToyFactory/sampleInput"))
                using (var csv = new CsvReader(reader))
                {
                    Console.WriteLine(csv.GetRecords<Foo>());
                    
                }
            }
 
        }
        
        public class Foo
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

    } 
}