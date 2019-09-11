using ToyFactoryLibrary.Enums;
using ToyFactoryLibrary.Interfaces;

namespace ToyFactoryLibrary.Blocks
{
    public class Circle : IToyBlock
    {
        public Colour Colour { get; }

        public Circle(Colour colour)
        {
            Colour = colour;
        }
    }
}