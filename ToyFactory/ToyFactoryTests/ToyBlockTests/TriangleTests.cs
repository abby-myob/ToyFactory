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
            // Act
            var triangle = new Triangle(expected); 

            // Assert
            Assert.Equal(expected, triangle.Colour);
        }
    }
}