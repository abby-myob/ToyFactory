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
        public static IEnumerable<object[]> Data =>
            new List<object[]>
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
                    new[] {1, 0, 0, 2, 0, 0, 1, 0, 0}
                },
            };

        [Theory]
        [MemberData(nameof(Data))]
        public void Collect_order_test_it_generates_the_right_order(List<IToyBlock> expected, int[] values)
        {
            // Arrange
            var fakeResponse = new Mock<IResponseManager>();
            
            fakeResponse.Setup(f => f.GetName()).Returns("Gerard");
            fakeResponse.Setup(f => f.GetAddress()).Returns("20 Jerry Road");
            fakeResponse.Setup(f => f.GetDueDate()).Returns(Convert.ToDateTime("20 Jan 2019"));
            
            fakeResponse.Setup(f => f.GetRedSquares()).Returns(values[0]);
            fakeResponse.Setup(f => f.GetBlueSquares()).Returns(values[1]);
            fakeResponse.Setup(f => f.GetYellowSquares()).Returns(values[2]);
            fakeResponse.Setup(f => f.GetRedTriangles()).Returns(values[3]);
            fakeResponse.Setup(f => f.GetBlueTriangles()).Returns(values[4]);
            fakeResponse.Setup(f => f.GetYellowTriangles()).Returns(values[5]);
            fakeResponse.Setup(f => f.GetRedCircles()).Returns(values[6]);
            fakeResponse.Setup(f => f.GetBlueCircles()).Returns(values[7]);
            fakeResponse.Setup(f => f.GetYellowCircles()).Returns(values[8]);
            var orderManager = new OrderManager(fakeResponse.Object);

            // Act
            orderManager.CollectOrder();

            // Assert
            Assert.Equal();
        }
    }
}