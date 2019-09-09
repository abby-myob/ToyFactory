using System;
using System.Collections.Generic;
using Moq;
using ToyFactoryLibrary;
using ToyFactoryLibrary.Enums;
using ToyFactoryLibrary.Interfaces;
using Xunit;

namespace ToyFactoryTests
{
    public class OrderTests
    {
        [Fact]
        public void TestCreationofOrder()
        {
            var list = new List<IToyBlock>()
            {
                new Square(Colour.Red),
                new Triangle(Colour.Red),
                new Triangle(Colour.Red),
                new Circle(Colour.Red)
            };
            
            var fakeResponse = new Mock<IResponseManager>();
            fakeResponse.Setup(f => f.GetRedSquares()).Returns(1);
            fakeResponse.Setup(f => f.GetBlueSquares()).Returns(0);
            fakeResponse.Setup(f => f.GetYellowSquares()).Returns(0);
            fakeResponse.Setup(f => f.GetRedTriangles()).Returns(2);
            fakeResponse.Setup(f => f.GetBlueTriangles()).Returns(0);
            fakeResponse.Setup(f => f.GetYellowTriangles()).Returns(0);
            fakeResponse.Setup(f => f.GetRedCircles()).Returns(1);
            fakeResponse.Setup(f => f.GetBlueCircles()).Returns(0);
            fakeResponse.Setup(f => f.GetYellowCircles()).Returns(0);

            // Arrange  what th4 f*k
            var order = new Order("A", "4", DateTime.Now, 0001, fakeResponse.Object);

            // Act 
            order.CreateToyBlocksOrder();

            // Assert
            for (var i = 0; i < order.ToyBlocks.Count; i++)
            {
                Assert.Equal(list[i].GetType(), order.ToyBlocks[i].GetType());
                Assert.Equal(list[i].Colour, order.ToyBlocks[i].Colour);
            }
        }
    }
}