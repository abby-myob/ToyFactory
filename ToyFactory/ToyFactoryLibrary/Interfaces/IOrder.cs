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
    }
}