using ToyFactoryLibrary.Enums;
using ToyFactoryLibrary.Interfaces;

namespace ToyFactoryLibrary
{
    public class ToyBlock : IToyBlock
    {
        public Shape Shape { get; }
        public Colour Colour { get; private set; }
        
        public ToyBlock(Shape shape)
        {
            Shape = shape;
        } 
        
        public void Paint(Colour colour)
        {
            Colour = colour;
        }
    }
}