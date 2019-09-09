using System.Collections.Generic;
using ToyFactoryLibrary;
using ToyFactoryLibrary.Enums;
using ToyFactoryLibrary.Interfaces;
using Xunit;

namespace ToyFactoryTests
{
    public class CuttingListGeneratorTests
    {
        [Fact]
        public void testCreationofOrder()
        {
            // Arrange  what th3 f*k
            var list = new List<IToyBlock>()
            {
                new Circle(Colour.Blue),
                new Square(Colour.Blue),
                new Circle(Colour.Blue),
                new Square(Colour.Blue)
            }; 
            
            var cuttingListGenerator = new CuttingListGenerator( );
            
            // Act 
            var number = cuttingListGenerator.GenerateReport(list);

            // Assert
            Assert.Equal(0001, number);
        }
    }

    public class CuttingListGenerator
    {
        public int GenerateReport(List<IToyBlock> list)
        {
            throw new System.NotImplementedException();
        }
    }
}