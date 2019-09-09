using System.Collections.Generic;

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
        }
        // Collect Orders
        
        // Go through orders and 
        
        // Generate Invoice
        // Generate Cutting List
        // Generate Painting Report
    }
}