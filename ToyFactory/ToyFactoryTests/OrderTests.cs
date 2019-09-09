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
                new object[]
                {
                    new List<IToyBlock>()
                    {
                        new Square(Colour.Red),
                        new Triangle(Colour.Red),
                        new Triangle(Colour.Red),
                    },
                    new[] {1, 0, 0, 2, 0, 0, 0, 0, 0}
                },
                new object[]
                {
                    new List<IToyBlock>() {},
                    new[] {0, 0, 0, 0, 0, 0, 0, 0, 0}
                },
                new object[]
                {
                    new List<IToyBlock>()
                    {
                        new Square(Colour.Red),
                        new Square(Colour.Blue),
                        new Square(Colour.Yellow),
                        new Triangle(Colour.Red),
                        new Triangle(Colour.Blue),
                        new Triangle(Colour.Yellow),
                        new Circle(Colour.Red),
                        new Circle(Colour.Blue),
                        new Circle(Colour.Yellow),
                    },
                    new[] {1,1,1,1,1,1,1,1,1}
                },
                new object[]
                {
                    new List<IToyBlock>()
                    {
                        new Square(Colour.Red),
                        new Square(Colour.Red),
                        new Square(Colour.Blue),
                        new Square(Colour.Blue),
                        new Square(Colour.Yellow),
                        new Square(Colour.Yellow),
                        new Square(Colour.Yellow),
                        new Triangle(Colour.Red),
                        new Triangle(Colour.Red),
                        new Triangle(Colour.Blue),
                        new Triangle(Colour.Blue),
                        new Triangle(Colour.Yellow),
                        new Triangle(Colour.Yellow),
                        new Triangle(Colour.Yellow),
                        new Circle(Colour.Red),
                        new Circle(Colour.Red),
                        new Circle(Colour.Blue),
                        new Circle(Colour.Blue),
                        new Circle(Colour.Yellow),
                        new Circle(Colour.Yellow),
                        new Circle(Colour.Yellow),
                    },
                    new[] {2,2,3,2,2,3,2,2,3}
                }
            };

        [Theory]
        [MemberData(nameof(Data))]
        public void TestCreationOfOrder(List<IToyBlock> expected, int[] values)
        {
            var fakeResponse = new Mock<IResponseManager>();
            fakeResponse.Setup(f => f.GetRedSquares()).Returns(values[0]);
            fakeResponse.Setup(f => f.GetBlueSquares()).Returns(values[1]);
            fakeResponse.Setup(f => f.GetYellowSquares()).Returns(values[2]);
            fakeResponse.Setup(f => f.GetRedTriangles()).Returns(values[3]);
            fakeResponse.Setup(f => f.GetBlueTriangles()).Returns(values[4]);
            fakeResponse.Setup(f => f.GetYellowTriangles()).Returns(values[5]);
            fakeResponse.Setup(f => f.GetRedCircles()).Returns(values[6]);
            fakeResponse.Setup(f => f.GetBlueCircles()).Returns(values[7]);
            fakeResponse.Setup(f => f.GetYellowCircles()).Returns(values[8]);

            // Arrange  what th4 f*k
            var order = new Order("A", "4", DateTime.Now, 0001, fakeResponse.Object);

            // Act 
            order.CreateToyBlocksOrder();

            // Assert
            for (var i = 0; i < order.ToyBlocks.Count; i++)
            {
                Assert.Equal(expected[i].GetType(), order.ToyBlocks[i].GetType());
                Assert.Equal(expected[i].Colour, order.ToyBlocks[i].Colour);
            }
        }
    }
}