using ToyFactoryLibrary;
using ToyFactoryLibrary.Blocks;
using ToyFactoryLibrary.Enums;
using Xunit;

namespace ToyFactoryTests
{
    public class ToyBlocksListTests
    {
        [Fact]
        public void test_adding_to_the_toyBlocksList_in_object()
        {
            // Arrange
            var square = new Square(Colour.Blue);
            var toyBlocksList = new ToyBlocksList();

            // Act
            toyBlocksList.Add(square);

            // Assert
            Assert.Equal(square.Colour, toyBlocksList.ToyBlocks[0].Colour);
        }

        [Fact]
        public void check_all_variables_are_updated_in_toyBlocks()
        {
            // Arrange
            var toyBlocksList = new ToyBlocksList();

            // Act 
            toyBlocksList.Add(new Square(Colour.Red));
            toyBlocksList.Add(new Square(Colour.Yellow));
            toyBlocksList.Add(new Square(Colour.Yellow));
            toyBlocksList.Add(new Square(Colour.Yellow));
            toyBlocksList.Add(new Square(Colour.Yellow));
            toyBlocksList.Add(new Triangle(Colour.Red));
            toyBlocksList.Add(new Triangle(Colour.Red));
            toyBlocksList.Add(new Triangle(Colour.Blue));
            toyBlocksList.Add(new Circle(Colour.Red));
            toyBlocksList.Add(new Circle(Colour.Red));

            // Assert
            Assert.Equal(1, toyBlocksList.RedSquares);
            Assert.Equal(0, toyBlocksList.BlueSquares);
            Assert.Equal(4, toyBlocksList.YellowSquares);
            Assert.Equal(2, toyBlocksList.RedTriangles);
            Assert.Equal(1, toyBlocksList.BlueTriangles);
            Assert.Equal(0, toyBlocksList.YellowTriangles);
            Assert.Equal(2, toyBlocksList.RedCircles);
            Assert.Equal(0, toyBlocksList.BlueCircles);
            Assert.Equal(0, toyBlocksList.YellowCircles);

            Assert.Equal(5, toyBlocksList.TotalSquares);
            Assert.Equal(3, toyBlocksList.TotalTriangles);
            Assert.Equal(2, toyBlocksList.TotalCircles);
            Assert.Equal(5, toyBlocksList.TotalRedBlocks);
        }
    }
}