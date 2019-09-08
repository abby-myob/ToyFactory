using ToyFactoryLibrary.Enums;
using ToyFactoryLibrary.Interfaces;

namespace ToyFactoryLibrary
{
    public class ToyBlock : IToyBlock
    {
        public Shape Shape { get; private set; }
        public Colour Colour { get; private set; }

        public void SetShape(Shape shape)
        {
            Shape = shape;
        }

        public void SetColour(Colour colour)
        {
            Colour = colour;
        }
    }
}