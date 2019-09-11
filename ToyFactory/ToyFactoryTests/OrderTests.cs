using System;
using System.Collections.Generic;
using Moq;
using ToyFactoryConsole;
using ToyFactoryLibrary;
using ToyFactoryLibrary.Blocks;
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
                    new List<IToyBlock>() { },
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
                    new[] {1, 1, 1, 1, 1, 1, 1, 1, 1}
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
                    new[] {2, 2, 3, 2, 2, 3, 2, 2, 3}
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

            // Arrange   
            var order = new Order("A", "4", DateTime.Now, 0001, fakeResponse.Object, new ToyBlocksList());

            // Act 
            order.CreateToyBlocks();

            // Assert
            for (var i = 0; i < order.ToyBlocksList.ToyBlocks.Count; i++)
            {
                Assert.Equal(expected[i].GetType(), order.ToyBlocksList.ToyBlocks[i].GetType());
                Assert.Equal(expected[i].Colour, order.ToyBlocksList.ToyBlocks[i].Colour);
            }
        }

        [Theory]
        [InlineData("Abby", "Thomas")]
        [InlineData("Abby", "Abby")]
        [InlineData("Thomas", "Gertrude")]
        [InlineData("Gertrude ", "Gertrude")]
        public void create_order_and_test_editing_of_Name(string name, string expected)
        {
            // Arrange
            var order = new Order(name, "4", DateTime.Now, 1, new ConsoleResponseManager(), new ToyBlocksList());

            // Act
            order.EditName(expected);

            // Assert
            Assert.Equal(expected, order.Name);
        }

        [Theory]
        [InlineData("20 Dairy Lane", "18 Dairy Lane")]
        [InlineData("20 Dairy Lane", "20 Lane Lane")]
        [InlineData("20 Dairy Lane", "18 Dairy Road")]
        public void create_order_and_test_editing_of_Address(string address, string expected)
        {
            // Arrange
            var order = new Order("jane", address, DateTime.Now, 1, new ConsoleResponseManager(), new ToyBlocksList());

            // Act
            order.EditAddress(expected);

            // Assert
            Assert.Equal(expected, order.Address);
        }

        [Fact]
        public void create_order_and_test_editing_of_DueDate()
        {
            // Arrange
            var order = new Order("jane", "20 Dairy Road", DateTime.Now, 1, new ConsoleResponseManager(),
                new ToyBlocksList());

            // Act
            order.EditDueDate(DateTime.Today);

            // Assert
            Assert.Equal(DateTime.Today, order.DueDate);
        }

        [Fact]
        public void create_order_and_test_adding_of_ToyBlocks_to_ToyBlocksList()
        {
            // Arrange
            var fakeToyBlocksList = new ToyBlocksList();

            var order = new Order("jane", "20 Dairy Road", DateTime.Now, 1, new ConsoleResponseManager(),
                fakeToyBlocksList);

            // Act
            order.AddBlocksToOrder(new List<IToyBlock> {new Circle(Colour.Red), new Circle(Colour.Red)});

            // Assert
            Assert.Equal(2,fakeToyBlocksList.RedCircles);
        } 
    }
}