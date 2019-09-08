using System;
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
        public void SetShape(Shape shape)
        {
            Shape = Shape.Circle;
        }
    }
}