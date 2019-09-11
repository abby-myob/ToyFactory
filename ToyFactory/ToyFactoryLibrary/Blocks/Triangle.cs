using ToyFactoryLibrary.Enums;
using ToyFactoryLibrary.Interfaces;

namespace ToyFactoryLibrary.Blocks
{
    public class Triangle : IToyBlock
    {
        public Colour Colour { get; }

        public Triangle(Colour colour)
        {
            Colour = colour;
        }
    }
}