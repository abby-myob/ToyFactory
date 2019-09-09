using ToyFactoryLibrary.Enums;

namespace ToyFactoryLibrary
{
    public class Triangle
    {
        public Colour Colour { get; private set; }

        public void Paint(Colour colour)
        {
            Colour = colour;
        }
    }
}