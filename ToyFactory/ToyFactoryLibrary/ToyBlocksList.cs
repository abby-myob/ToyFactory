using System.Collections.Generic;
using System.Linq;
using ToyFactoryLibrary.Blocks;
using ToyFactoryLibrary.Enums;
using ToyFactoryLibrary.Interfaces;

namespace ToyFactoryLibrary
{
    public class ToyBlocksList : IToyBlocksList
    {
        public List<IToyBlock> ToyBlocks { get; private set; }
        public int RedSquares { get; private set; }
        public int BlueSquares { get; private set; }
        public int YellowSquares { get; private set; }
        public int RedTriangles { get; private set; }
        public int BlueTriangles { get; private set; }
        public int YellowTriangles { get; private set; }
        public int RedCircles { get; private set; }
        public int BlueCircles { get; private set; }
        public int YellowCircles { get; private set; }
        public int TotalSquares { get; private set; }
        public int TotalTriangles { get; private set; }
        public int TotalCircles { get; private set; }
        public int TotalRedBlocks { get; private set; }

        public ToyBlocksList()
        {
            ToyBlocks = new List<IToyBlock>();
            RedSquares = 0;
            BlueSquares = 0;
            YellowSquares = 0;
            RedTriangles = 0;
            BlueTriangles = 0;
            YellowTriangles = 0;
            RedCircles = 0;
            BlueCircles = 0;
            YellowCircles = 0;

            TotalSquares = 0;
            TotalTriangles = 0;
            TotalCircles = 0;
            TotalRedBlocks = 0;
        }

        public void Add(IToyBlock block)
        {
            ToyBlocks.Add(block);
        }

        public void UpdateProperties()
        {
            RedSquares = ToyBlocks.Where(x => x is Square).Count(x => x.Colour == Colour.Red);
            BlueSquares = ToyBlocks.Where(x => x is Square).Count(x => x.Colour == Colour.Blue);
            YellowSquares = ToyBlocks.Where(x => x is Square).Count(x => x.Colour == Colour.Yellow);
            RedTriangles = ToyBlocks.Where(x => x is Triangle).Count(x => x.Colour == Colour.Red);
            BlueTriangles = ToyBlocks.Where(x => x is Triangle).Count(x => x.Colour == Colour.Blue);
            YellowTriangles = ToyBlocks.Where(x => x is Triangle).Count(x => x.Colour == Colour.Yellow);
            RedCircles = ToyBlocks.Where(x => x is Circle).Count(x => x.Colour == Colour.Red);
            BlueCircles = ToyBlocks.Where(x => x is Circle).Count(x => x.Colour == Colour.Blue);
            YellowCircles = ToyBlocks.Where(x => x is Circle).Count(x => x.Colour == Colour.Yellow);
            
            TotalSquares = ToyBlocks.Count(x => x is Square);
            TotalTriangles = ToyBlocks.Count(x => x is Triangle);
            TotalCircles = ToyBlocks.Count(x => x is Circle);
            TotalRedBlocks = ToyBlocks.Count(x => x.Colour == Colour.Red);
        }
    }
}