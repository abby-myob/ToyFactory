using System;
using System.Collections.Generic;
using Moq;
using ToyFactoryLibrary;
using ToyFactoryLibrary.Enums;
using ToyFactoryLibrary.Interfaces;
using Xunit;

namespace ToyFactoryTests
{
    public class OrderManagerTests
    {
        public static IEnumerable<object[]> Data => new List<object[]>
        {
            new object[]
            {
                new List<IToyBlock>()
                {
                    new Square(Colour.Red),
                    new Triangle(Colour.Red),
                    new Triangle(Colour.Red),
                    new Circle(Colour.Red)
                },
            },
        };

        public Mock<IResponseManager> CreateResponseFake()
        {
            var values = new[] {1, 0, 0, 2, 0, 0, 1, 0, 0};

            var fakeResponse = new Mock<IResponseManager>();

            fakeResponse.Setup(f => f.GetName()).Returns("Gerard");
            fakeResponse.Setup(f => f.GetAddress()).Returns("20 Jerry Road");
            fakeResponse.Setup(f => f.GetDueDate()).Returns(DateTime.Today);

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

        [Theory]
        [MemberData(nameof(Data))]
        public void Collect_order_test_it_generates_the_right_order(List<IToyBlock> expected)
        {
            // Arrange 
            var orderManager = new OrderManager(CreateResponseFake().Object);

            // Act
            orderManager.CollectOrder();

            // Assert
            Assert.Equal("Gerard", orderManager.Orders[0].Name);
            Assert.Equal("20 Jerry Road", orderManager.Orders[0].Address);
            Assert.Equal(DateTime.Today, orderManager.Orders[0].DueDate);
            Assert.Equal(1, orderManager.Orders[0].OrderNumber);

            for (var i = 0; i < expected.Count; i++)
            {
                Assert.Equal(expected[i].Colour, orderManager.Orders[0].ToyBlocks[i].Colour);
                Assert.Equal(expected[i].GetType(), orderManager.Orders[0].ToyBlocks[i].GetType());
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
    }
}