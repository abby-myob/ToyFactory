using System;
using System.Collections.Generic;
using ToyFactoryLibrary.Interfaces;
using Xunit;

namespace ToyFactoryTests
{
    public class OrderTests
    {
        [Fact]
        public void testCreationofOrder()
        {
            // Arrange 
            var order = new Order("Abby Thompson", "4 Privet Dr", DateTime.Now, 0001, new List<IToyBlock>());
            
            // Act 
            var number = order.OrderNumber;

            // Assert
            Assert.Equal(0001, number);
        }
    }

    public class Order
    {
        public string Name { get; }
        public string Address { get; }
        public DateTime DueDate { get; }
        public int OrderNumber { get; }
        public List<IToyBlock> ToyBlocks { get; }

        public Order(string name, string address, in DateTime dueDate, int orderNumber, List<IToyBlock> toyBlocks)
        {
            Name = name;
            Address = address;
            DueDate = dueDate;
            OrderNumber = orderNumber;
            ToyBlocks = toyBlocks;
        }
    }
}