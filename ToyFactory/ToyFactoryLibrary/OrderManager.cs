using System;
using System.Collections.Generic;
using System.Linq;
using ToyFactoryLibrary.Interfaces;

namespace ToyFactoryLibrary
{
    public class OrderManager
    {
        public IResponseManager ResponseManager { get; }
        public IReportGenerator ReportGenerator { get; }
        public List<IOrder> Orders { get; }
        private int CurrentOrderNumber { get; set; }

        public OrderManager(IResponseManager responseManager, IReportGenerator reportGenerator)
        {
            CurrentOrderNumber = 1;
            ResponseManager = responseManager;
            ReportGenerator = reportGenerator;
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
            ReportGenerator.GenerateInvoice(order);
            ReportGenerator.GenerateCuttingListReport(order);
            ReportGenerator.GeneratePaintingReport(order);
        }

        public void GenerateCuttingListOverallReport()
        {
            ReportGenerator.GenerateCuttingListOverallReport(Orders);
        }
        public void GeneratePaintingOverallReport()
        { 
            ReportGenerator.GeneratePaintingListOverallReport(Orders);
        }
        public void GenerateAllInvoices()
        { 
            ReportGenerator.GenerateAllInvoices(Orders);
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