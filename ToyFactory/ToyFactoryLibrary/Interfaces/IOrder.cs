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
        IResponseManager ResponseManager { get; }
        void CreateToyBlocks();
        void EditName(string name);
        void EditAddress(string address);
        void EditDueDate(in DateTime dueDate);
    }
}