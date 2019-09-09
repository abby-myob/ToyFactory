using System;
using ToyFactoryLibrary;

namespace ToyFactoryConsole
{
    internal static class Program
    {
        private static void Main()
        {
            Console.WriteLine(Constants.Welcome);
            
            var orderManager = new OrderManager(new ConsoleResponseManager());
            
            orderManager.collectOrder();
        }
    }
}