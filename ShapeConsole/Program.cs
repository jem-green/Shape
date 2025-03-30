using ShapeLibrary;
using System;
using System.Collections.Generic;

namespace ShapeConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Document shpDocument = new Document();
            Line line = new Line(new Point(5,5,0), new Point(10,10,0));
            shpDocument.AddLine(line);
            shpDocument.Save("", "test");

            // Test Loading

            shpDocument = new Document();
            shpDocument.Load("", "test");
            foreach(IShape shape in shpDocument)
            {
                Console.WriteLine(shape.ToString());
            }



        }
    }
}
