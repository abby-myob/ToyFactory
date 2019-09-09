using ToyFactoryLibrary;
using ToyFactoryLibrary.Interfaces;
using Xunit;

namespace ToyFactoryTests
{
    public class CuttingListGeneratorTests
    {
        [Fact]
        public void testCreationOfCuttingListGeneration()
        {
//            // Arrange 
//            var cuttingListGenerator = new CuttingListGenerator(new ConsoleResponseManager());
//            var order = new Order();
//            
//            // Act 
//            cuttingListGenerator.GenerateReport(order);
//
//            // Assert
//            Assert.Equal(0001, number);
        }
    }

    public class CuttingListGenerator
    {
        public IResponseManager ResponseManager { get; }

        public CuttingListGenerator(IResponseManager responseManager)
        {
            ResponseManager = responseManager;
        }

        public void GenerateReport(IOrder order)
        {
            ResponseManager.PrintCuttingListReport(order);
        }
    }
}