using System.Collections.Generic;
using ToyFactoryLibrary.Interfaces;

namespace ToyFactoryLibrary
{
    public class OrderManager
    {
        public IResponseManager ResponseManager { get; }
        public List<Order> Orders { get; private set; }
        public int CurrentOrderNumber = 1;

        public OrderManager(IResponseManager responseManager)
        {
            ResponseManager = responseManager;
            Orders = new List<Order>();
        }

        public void CollectOrder()
        {
            var name = ResponseManager.GetName();
            var address = ResponseManager.GetAddress();
            var dueDate = ResponseManager.GetDueDate();

            var order = new Order(name, address, dueDate, CurrentOrderNumber, ResponseManager);
            order.CreateToyBlocks();
            
            Orders.Add(order);
            CurrentOrderNumber++;
        }

        public void GenerateReports(int orderNumber)
        {
            var order = Orders.Find(o => o.OrderNumber == orderNumber);
            ResponseManager.GenerateInvoice(order);
            ResponseManager.GenerateCuttingListReport(order);
            ResponseManager.GeneratePaintingReport(order);
        }
    }
}