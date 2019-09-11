using System;

namespace ToyFactoryLibrary.Interfaces
{
    public interface IOrder
    {
        string Name { get; }
        string Address { get; }
        DateTime DueDate { get; }
        int OrderNumber { get; }
        IToyBlocksList ToyBlocksList { get; }
        decimal SquaresPrice { get; }
        decimal TrianglesPrice { get; }
        decimal CirclesPrice { get; }
        decimal RedSurchargePrice { get; }
        decimal TotalPrice { get; }
        
        IResponseManager ResponseManager { get; }
        void CreateToyBlocks();
        void EditName(string name);
        void EditAddress(string address);
        void EditDueDate(in DateTime dueDate);
    }
}