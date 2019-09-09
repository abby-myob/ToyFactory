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
            // Arrange & Act // This is a low quality test I think 
            // TODO should the toyblock just be squares, circles and triangles implementing the IToyBlock interface.
            var toyBlock = new ToyBlock(expected); 

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
            var toyBlock = new ToyBlock(Shape.Circle);
            
            // Act
            toyBlock.Paint(expected);

            // Assert
            Assert.Equal(expected, toyBlock.Colour);
        }
    }
}