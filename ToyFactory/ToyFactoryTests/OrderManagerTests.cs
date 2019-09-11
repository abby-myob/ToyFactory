using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using ToyFactoryLibrary;
using ToyFactoryLibrary.Blocks;
using ToyFactoryLibrary.Enums;
using ToyFactoryLibrary.Interfaces;
using Xunit;

namespace ToyFactoryTests
{
    public class OrderManagerTests
    {
        public Mock<IResponseManager> CreateResponseFake()
        {
            var values = new[] {1, 0, 0, 2, 0, 0, 1, 0, 0};

            var fakeResponse = new Mock<IResponseManager>();

            fakeResponse.Setup(f => f.GetName()).Returns("Gerard");
            fakeResponse.Setup(f => f.GetAddress()).Returns("20 Jerry Road");
            fakeResponse.Setup(f => f.GetDueDate()).Returns(Convert.ToDateTime("20 Jun 2019"));

            fakeResponse.Setup(f => f.GetRedSquares()).Returns(values[0]);
            fakeResponse.Setup(f => f.GetRedCircles()).Returns(values[6]);
            fakeResponse.Setup(f => f.GetBlueSquares()).Returns(values[1]);
            fakeResponse.Setup(f => f.GetBlueCircles()).Returns(values[7]);
            fakeResponse.Setup(f => f.GetRedTriangles()).Returns(values[3]);
            fakeResponse.Setup(f => f.GetBlueTriangles()).Returns(values[4]);
            fakeResponse.Setup(f => f.GetYellowCircles()).Returns(values[8]);
            fakeResponse.Setup(f => f.GetYellowSquares()).Returns(values[2]);
            fakeResponse.Setup(f => f.GetYellowTriangles()).Returns(values[5]);

            return fakeResponse;
        }

        [Fact]
        public void Collect_order_test_it_generates_the_right_order()
        {
            // Arrange 
            var orderManager = new OrderManager(CreateResponseFake().Object);
            var expected = new List<IToyBlock>
            {
                new Square(Colour.Red),
                new Triangle(Colour.Red),
                new Triangle(Colour.Red),
                new Circle(Colour.Red)
            };

            // Act
            orderManager.CollectOrder();

            // Assert
            Assert.Equal("Gerard", orderManager.Orders[0].Name);
            Assert.Equal("20 Jerry Road", orderManager.Orders[0].Address);
            Assert.Equal(Convert.ToDateTime("20 Jun 2019"), orderManager.Orders[0].DueDate);
            Assert.Equal(1, orderManager.Orders[0].OrderNumber);

            for (var i = 0; i < expected.Count; i++)
            {
                Assert.Equal(expected[i].Colour, orderManager.Orders[0].ToyBlocksList.ToyBlocks[i].Colour);
                Assert.Equal(expected[i].GetType(), orderManager.Orders[0].ToyBlocksList.ToyBlocks[i].GetType());
            }
        }

        [Theory]
        [InlineData(1)]
        [InlineData(3)]
        [InlineData(2)]
        [InlineData(10)]
        [InlineData(100)]
        public void Should_increase_the_order_number_per_order(int num)
        {
            // Arrange 
            var orderManager = new OrderManager(CreateResponseFake().Object);

            // Act
            for (var i = 0; i < num; i++)
            {
                orderManager.CollectOrder();
            }

            // Assert
            for (var i = 0; i < num; i++)
            {
                Assert.Equal(i + 1, orderManager.Orders[i].OrderNumber);
            }
        }

        [Fact]
        public void search_results_for_order_number()
        {
            // Arrange 
            var orderManager = new OrderManager(CreateResponseFake().Object);
            orderManager.CollectOrder();
            orderManager.CollectOrder();
            orderManager.CollectOrder();
            orderManager.CollectOrder();

            // Act
            var order = orderManager.SearchByOrderNumber(2);

            // Assert
            Assert.True(order.OrderNumber == 2);
        }
        
        [Theory]
        [InlineData("Gerard", 2)]
        [InlineData("Abby", 0)]
        public void search_results_for_person(string name, int expected)
        {
            // Arrange 
            var orderManager = new OrderManager(CreateResponseFake().Object);
            orderManager.CollectOrder();
            orderManager.CollectOrder();

            // Act
            var orders = orderManager.SearchOrderByPerson(name);

            // Assert 
            Assert.Equal(expected, orders.Count());
        }

        [Theory]
        [InlineData("20 Jun 2019", "20 Jun 2019", 2)]
        public void search_results_for_date(DateTime date, DateTime date2, int expected)
        {
            // Arrange 
            var orderManager = new OrderManager(CreateResponseFake().Object);
            orderManager.CollectOrder();
            orderManager.CollectOrder();

            // Act
            var orders = orderManager.SearchOrderByDueDate(Convert.ToDateTime(date), Convert.ToDateTime(date2));

            // Assert 
            Assert.Equal(expected, orders.Count());
        }
        
        [Fact] 
        public void delete_order_by_order_number()
        {
            // Arrange 
            var orderManager = new OrderManager(CreateResponseFake().Object);
            orderManager.CollectOrder();
            orderManager.CollectOrder();

            // Act
            orderManager.DeleteOrderByOrderNumber(2);

            // Assert 
            Assert.Equal(0, orderManager.Orders.Count(o => o.OrderNumber == 2));
        }
    }
}