using System;
using System.Collections.Generic;
using ToyFactoryLibrary.Enums;
using ToyFactoryLibrary.Interfaces;

namespace ToyFactoryLibrary
{
    public class Order
    {
        public string Name { get; }
        public string Address { get; }
        public DateTime DueDate { get; }
        public int OrderNumber { get; }
        public IResponseManager ResponseManager { get; }
        
        public List<IToyBlock> ToyBlocks = new List<IToyBlock>(); 

        public Order(string name, string address, in DateTime dueDate, int orderNumber, IResponseManager responseManager)
        {
            Name = name;
            Address = address;
            DueDate = dueDate;
            OrderNumber = orderNumber;
            ResponseManager = responseManager;
        }

        public void CreateToyBlocksOrder()
        {
            for (var i = 0; i < ResponseManager.GetRedSquares(); i++)
            {
                ToyBlocks.Add(new Square(Colour.Red));
            }
            for (var i = 0; i < ResponseManager.GetBlueSquares(); i++)
            {
                ToyBlocks.Add(new Square(Colour.Blue));
            }
            for (var i = 0; i < ResponseManager.GetYellowSquares(); i++)
            {
                ToyBlocks.Add(new Square(Colour.Yellow));
            }
            for (var i = 0; i < ResponseManager.GetRedTriangles(); i++)
            {
                ToyBlocks.Add(new Triangle(Colour.Red));
            }
            for (var i = 0; i < ResponseManager.GetBlueTriangles(); i++)
            {
                ToyBlocks.Add(new Triangle(Colour.Blue));
            }
            for (var i = 0; i < ResponseManager.GetYellowTriangles(); i++)
            {
                ToyBlocks.Add(new Triangle(Colour.Yellow));
            }
            for (var i = 0; i < ResponseManager.GetRedCircles(); i++)
            {
                ToyBlocks.Add(new Circle(Colour.Red));
            }
            for (var i = 0; i < ResponseManager.GetBlueCircles(); i++)
            {
                ToyBlocks.Add(new Circle(Colour.Blue));
            }
            for (var i = 0; i < ResponseManager.GetYellowCircles(); i++)
            {
                ToyBlocks.Add(new Circle(Colour.Yellow));
            }
        }
    }
}