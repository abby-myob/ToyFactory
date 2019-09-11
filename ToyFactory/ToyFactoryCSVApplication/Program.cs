using System;
using System.Collections.Generic;
using System.IO;
using CsvHelper;
using ToyFactoryLibrary.Interfaces;

namespace ToyFactoryCSVApplication
{
    internal static class Program
    {
        private static void Main()
        { 
                using (var reader = new StreamReader("/Users/abby.thompson/Development/ToyFactory/Input"))
                using (var csv = new CsvReader(reader))
                {
                    var records = csv.GetRecords<IOrder>();
                    foreach (var food in records)
                    {
                        Console.WriteLine(food);
                    }
                }
                
                using (var writer = new StreamWriter("/Users/abby.thompson/Development/ToyFactory/Output"))
                using (var csv2 = new CsvWriter(writer))
                {
                    var records = new List<IOrder>
                    {
//                        new Order("Abby", "20 June St", DateTime.Now, 10, new ConsoleResponseManager())
//                        {
//                            ToyBlocks = { new Circle(Colour.Red)}
//                        }
                    };
                    csv2.WriteRecords(records);
                    foreach (var food in records)
                    {
                        Console.WriteLine(food);
                    }
                } 
        }  
    } 
}