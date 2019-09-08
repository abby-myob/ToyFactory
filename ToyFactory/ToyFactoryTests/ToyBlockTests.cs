using System;
using System.Collections.Generic;
using Xunit;

namespace ToyFactoryTests
{
    public class ToyBlockTests
    {
        [Theory]
        [InlineData(Shape.Square)]
        [InlineData(Shape.Circle)]
        [InlineData(Shape.Triangle)]
        public void ToyBlockSetShape(Shape expected)
        {
            // Arrange
            var toyBlock = new ToyBlock();
            
            // Act
            toyBlock.SetShape(expected);

            // Assert
            Assert.Equal(expected, toyBlock.Shape);
        }
        
        [Theory]
        [InlineData(Colour.Blue)]
        [InlineData(Colour.Red)]
        [InlineData(Colour.Yellow)]
        public void ToyBlock_test_set_Colour(Colour expected)
        {
            // Arrange
            var toyBlock = new ToyBlock();
            
            // Act
            toyBlock.SetColour(expected);

            // Assert
            Assert.Equal(expected, toyBlock.Colour);
        }
    }

    public enum Colour
    {
        Red,
        Blue,
        Yellow
    }

    public enum Shape
    {
        Square, 
        Triangle,
        Circle
    }

    public class ToyBlock
    {
        public Shape Shape { get; private set; }
        public Colour Colour { get; set; }

        public void SetShape(Shape shape)
        {
            Shape = shape;
        }

        public void SetColour(Colour colour)
        {
            Colour = colour;
        }
    }
}