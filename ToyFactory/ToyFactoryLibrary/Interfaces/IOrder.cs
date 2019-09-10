using System;
using System.Collections.Generic;

namespace ToyFactoryLibrary.Interfaces
{
    public interface IOrder
    {
        string Name { get; }
        string Address { get; }
        DateTime DueDate { get; }
        int OrderNumber { get; }
        List<IToyBlock> ToyBlocks { get; }
        IResponseManager ResponseManager { get; }
        void CreateToyBlocks();
    }
}