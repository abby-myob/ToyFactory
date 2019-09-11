using ToyFactoryLibrary.Blocks;
using ToyFactoryLibrary.Enums;
using Xunit;

namespace ToyFactoryTests.ToyBlockTests
{
    public class CircleTests
    {
        [Theory]
        [InlineData(Colour.Blue)]
        [InlineData(Colour.Red)]
        [InlineData(Colour.Yellow)]
        public void Circle_test_set_Colour(Colour expected)
        {
            // Act
            var circle = new Circle(expected);  

            // Assert
            Assert.Equal(expected, circle.Colour);
        }
    }
}