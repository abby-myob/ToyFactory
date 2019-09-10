using ToyFactoryLibrary;
using ToyFactoryLibrary.Blocks;
using ToyFactoryLibrary.Enums;
using Xunit;

namespace ToyFactoryTests.ToyBlockTests
{
    public class TriangleTests
    {
        [Theory]
        [InlineData(Colour.Blue)]
        [InlineData(Colour.Red)]
        [InlineData(Colour.Yellow)]
        public void ToyBlock_test_set_Colour(Colour expected)
        {
            // Arrange
            var triangle = new Triangle(expected);

            // Act 

            // Assert
            Assert.Equal(expected, triangle.Colour);
        }
    }
}