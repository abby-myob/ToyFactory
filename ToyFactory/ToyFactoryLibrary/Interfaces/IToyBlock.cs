using ToyFactoryLibrary.Enums;

namespace ToyFactoryLibrary.Interfaces
{
    public interface IToyBlock
    {
        Shape Shape { get; }
        Colour Colour { get; }
        void SetShape(Shape shape);
        void SetColour(Colour colour);
    }
}