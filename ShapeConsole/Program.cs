using ShapeLibrary;
using System;
using System.Collections.Generic;

namespace ShapeConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            SHPDocument shpDocument = new SHPDocument();
            SHPLine line = new SHPLine(new SHPPoint(5,5,0), new SHPPoint(10,10,0));
            shpDocument.AddLine(line);
            shpDocument.Save("", "test");

            // Test Loading

            shpDocument = new SHPDocument();
            shpDocument.Load("", "test");
            foreach(IShape shape in shpDocument)
            {
                Console.WriteLine(shape.ToString());
            }



        }
    }
}
