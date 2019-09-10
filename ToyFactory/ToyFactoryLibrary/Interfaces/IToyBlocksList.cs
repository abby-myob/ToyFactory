using System.Collections.Generic;

namespace ToyFactoryLibrary.Interfaces
{
    public interface IToyBlocksList
    {
        List<IToyBlock> ToyBlocks { get; }
        int RedSquares { get; }
        int BlueSquares { get; }
        int YellowSquares { get; }
        int RedTriangles { get; }
        int BlueTriangles { get; }
        int YellowTriangles { get; }
        int RedCircles { get; }
        int BlueCircles { get; }
        int YellowCircles { get; }
        int TotalSquares { get; }
        int TotalTriangles { get; }
        int TotalCircles { get; }
        int TotalRedBlocks { get; }
        void Add(IToyBlock block);
        void UpdateProperties();
    }
}