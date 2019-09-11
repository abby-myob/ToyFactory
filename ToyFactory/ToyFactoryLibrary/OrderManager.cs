using System;
using System.Collections.Generic;
using System.Linq;
using ToyFactoryLibrary.Interfaces;

namespace ToyFactoryLibrary
{
    public class OrderManager
    {
        private IResponseManager ResponseManager { get; }
        public List<IOrder> Orders { get; }
        private int CurrentOrderNumber { get; set; }

        public OrderManager(IResponseManager responseManager)
        {
            CurrentOrderNumber = 1;
            ResponseManager = responseManager;
            Orders = new List<IOrder>();
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
            var order = SearchByOrderNumber(orderNumber);
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

        public IOrder SearchByOrderNumber(int orderNumber)
        {
            return Orders.Find(o => o.OrderNumber == orderNumber);
        }

        public IEnumerable<IOrder> SearchOrderByPerson(string name)
        { 
            return Orders.Where(o => o.Name == name); 
        }

        public IEnumerable<IOrder> SearchOrderByDueDate(DateTime startDate, DateTime endDate)
        {
            return Orders.Where(o => o.DueDate.CompareTo(endDate) <= 0 ).Where(o => o.DueDate.CompareTo(startDate) >= 0);
        }

        public void DeleteOrderByOrderNumber(int orderNumber)
        { 
            Orders.Remove(SearchByOrderNumber(orderNumber));
        }
    }
}