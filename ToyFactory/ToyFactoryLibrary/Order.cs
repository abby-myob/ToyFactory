using System;
using System.Collections.Generic;
using ToyFactoryLibrary.Enums;
using ToyFactoryLibrary.Interfaces;

namespace ToyFactoryLibrary
{
    public class Order : IOrder
    {
        public string Name { get; }
        public string Address { get; }
        public DateTime DueDate { get; }
        public int OrderNumber { get; }
        public List<IToyBlock> ToyBlocks { get; }
        public IResponseManager ResponseManager { get; } 

        public Order(string name, string address, in DateTime dueDate, int orderNumber, IResponseManager responseManager)
        {
            Name = name;
            Address = address;
            DueDate = dueDate;
            OrderNumber = orderNumber;
            ResponseManager = responseManager;
            ToyBlocks = new List<IToyBlock>();
        }

        public void CreateToyBlocks()
        {
            var max = ResponseManager.GetRedSquares();
            for (var i = 0; i < max; i++) ToyBlocks.Add(new Square(Colour.Red));
            
            
            max = ResponseManager.GetBlueSquares();
            for (var i = 0; i < max; i++) ToyBlocks.Add(new Square(Colour.Blue));
            
            
            max = ResponseManager.GetYellowSquares(); 
            for (var i = 0; i < max; i++) ToyBlocks.Add(new Square(Colour.Yellow));
            
            
            max = ResponseManager.GetRedTriangles(); 
            for (var i = 0; i < max; i++) ToyBlocks.Add(new Triangle(Colour.Red));
            
            
            max = ResponseManager.GetBlueTriangles(); 
            for (var i = 0; i < max; i++) ToyBlocks.Add(new Triangle(Colour.Blue));
            
            
            max =  ResponseManager.GetYellowTriangles(); 
            for (var i = 0; i < max; i++) ToyBlocks.Add(new Triangle(Colour.Yellow));
            
            
            max = ResponseManager.GetRedCircles();
            for (var i = 0; i < max; i++) ToyBlocks.Add(new Circle(Colour.Red));
            
            
            max = ResponseManager.GetBlueCircles();
            for (var i = 0; i < max; i++) ToyBlocks.Add(new Circle(Colour.Blue));
            
            
            max = ResponseManager.GetYellowCircles();
            for (var i = 0; i < max; i++) ToyBlocks.Add(new Circle(Colour.Yellow));
            
        }
    }
}