using ToyFactoryLibrary.Enums;
using ToyFactoryLibrary.Interfaces;

namespace ToyFactoryLibrary
{
    public class Circle : IToyBlock
    {
        public Colour Colour { get; private set; }
        public void Paint(Colour colour)
        {
            Colour = colour;
        }
    }
}