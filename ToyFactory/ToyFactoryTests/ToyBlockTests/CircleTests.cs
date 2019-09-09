using ToyFactoryLibrary;
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
            // Arrange
            var circle = new Circle(expected);

            // Act 

            // Assert
            Assert.Equal(expected, circle.Colour);
        }
    }
}