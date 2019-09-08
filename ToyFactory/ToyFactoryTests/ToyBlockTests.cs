using ToyFactoryLibrary;
using ToyFactoryLibrary.Enums;
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
}