using System.Collections.Generic;
using System.Linq;
using ToyFactoryLibrary.Interfaces;

namespace ToyFactoryLibrary
{
    public class OrderManager
    {
        private IResponseManager ResponseManager { get; }
        public List<Order> Orders { get; }
        private int CurrentOrderNumber { get; set; }

        public OrderManager(IResponseManager responseManager)
        {
            CurrentOrderNumber = 1;
            ResponseManager = responseManager;
            Orders = new List<Order>();
        }

        public void CollectOrder()
        {
            var name = ResponseManager.GetName();
            var address = ResponseManager.GetAddress();
            var dueDate = ResponseManager.GetDueDate();

            var order = new Order(name, address, dueDate, CurrentOrderNumber, ResponseManager, new ToyBlocksList());
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

        public void GenerateCuttingListOverallReport()
        {
            ResponseManager.GenerateCuttingListOverallReport(Orders);
        }
        public void GeneratePaintingOverallReport()
        {

            
            ResponseManager.GeneratePaintingListOverallReport(Orders);
        }
    }
}