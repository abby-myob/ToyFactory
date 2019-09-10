using System.Collections.Generic;

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
            var order = new Order(
                ResponseManager.GetName(),
                ResponseManager.GetAddress(),
                ResponseManager.GetDueDate(),
                CurrentOrderNumber,
                ResponseManager
            );
            
            order.CreateToyBlocksOrder();
            Orders.Add(order);
            CurrentOrderNumber++;
        }

        public void GenerateInvoice()
        {
            ResponseManager.PrintInvoice(Orders[0]);
        }

        public void GenerateCuttingListReport()
        {
            ResponseManager.PrintCuttingListReport(Orders[0]);
        }

        public void GeneratePaintingReport()
        {
            ResponseManager.PrintPaintingReport(Orders[0]);
        }
    }
}