using System.Collections.Generic;
using System.Net;

namespace ToyFactoryLibrary
{
    public class OrderManager
    {
        public IResponseManager ResponseManager { get; }
        public List<Order> orders = new List<Order>();
        public int currentOrderNumber = 0001;

        public OrderManager(IResponseManager responseManager)
        {
            ResponseManager = responseManager;
        }

        public void collectOrder()
        {
            var order = new Order(ResponseManager.GetName(), ResponseManager.GetAddress(), ResponseManager.GetDueDate(), currentOrderNumber, ResponseManager);
            order.CreateToyBlocksOrder();
            currentOrderNumber++;
            
            ResponseManager.PrintCuttingListReport(order);
            ResponseManager.PrintPaintingReport(order);
        } 
        
        // Go through orders and 
        
        // Generate Invoice 
    }
}