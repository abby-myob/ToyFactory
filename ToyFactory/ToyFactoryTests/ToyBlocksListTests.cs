using System.Collections.Generic;
using ToyFactoryLibrary;
using ToyFactoryLibrary.Enums;
using ToyFactoryLibrary.Interfaces;
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
        public void check_all_variables_are_updated_in_toyblocks()
        {
            // Arrange
            var toyBlocksList = new ToyBlocksList();

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
            
            

            // Act
            toyBlocksList.UpdateProperties();

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
            Assert.Equal(2, toyBlocksList.TotalRedBlocks);
        }
    }

    public class ToyBlocksList
    {
        public List<IToyBlock> ToyBlocks { get; private set; }
        public int RedSquares { get; }
        public int BlueSquares { get; }
        public int YellowSquares { get; }
        public int RedTriangles { get; }
        public int BlueTriangles { get; }
        public int YellowTriangles { get; }
        public int RedCircles { get; }
        public int BlueCircles { get; }
        public int YellowCircles { get; }
        public int TotalSquares { get; }
        public int TotalTriangles { get; }
        public int TotalCircles { get; }
        public int TotalRedBlocks { get; }

        public ToyBlocksList()
        {
            ToyBlocks = new List<IToyBlock>();
            RedSquares = 0;
            BlueSquares = 0;
            YellowSquares = 0;
            RedTriangles = 0;
            BlueTriangles = 0;
            YellowTriangles = 0;
            RedCircles = 0;
            BlueCircles = 0;
            YellowCircles = 0;

            TotalSquares = 0;
            TotalTriangles = 0;
            TotalCircles = 0;
            TotalRedBlocks = 0;
        }

        public void Add(IToyBlock block)
        {
            ToyBlocks.Add(block);
        }

        public void UpdateProperties()
        {
            throw new System.NotImplementedException();
        }
    }
}