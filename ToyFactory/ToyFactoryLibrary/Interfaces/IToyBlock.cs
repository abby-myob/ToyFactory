using ToyFactoryLibrary.Enums;

namespace ToyFactoryLibrary.Interfaces
{
    public interface IToyBlock
    {
        Colour Colour { get; } 
        void Paint(Colour colour);
    }
}