using ToyFactoryLibrary.Enums;
using ToyFactoryLibrary.Interfaces;

namespace ToyFactoryLibrary.Blocks
{
    public class Square : IToyBlock
    {
        public Colour Colour { get; }

        public Square(Colour colour)
        {
            Colour = colour;
        }
    }
}