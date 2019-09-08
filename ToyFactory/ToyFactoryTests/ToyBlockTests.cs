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
            var toyblock = new ToyBlock();
            
            // Act
            toyblock.SetShape(expected);

            // Assert
            Assert.Equal(expected, toyblock.Shape);
        }
        
        [Fact]
        public void ToyBlockSetShape()
        {
            // Arrange
            var toyblock = new ToyBlock();
            
            // Act
            toyblock.SetColour(Colour.Red);

            // Assert
            Assert.Equal(Colour.Red, toyblock.Colour);
        }
    }

    public enum Colour
    {
        Red
    }

    public enum Shape
    {
        Square, 
        Circle,
        Triangle
    }

    public class ToyBlock
    {
        public Shape Shape { get; private set; }
        public Colour Colour { get; set; }

        public void SetShape(Shape shape)
        {
            Shape = shape;
        }

        public void SetColour(object red)
        {
            throw new NotImplementedException();
        }
    }
}