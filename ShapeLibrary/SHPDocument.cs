//using DXFLibrary;
//using GcodeLibrary;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ShapeLibrary
{
    public class SHPDocument : IEnumerable<IShape>
    {
        #region Fields
        
        private List<IShape> _shapes;
        private List<SHPPoint> _points;
        
        #endregion
        #region Constructors

        public SHPDocument()
        {
            _shapes = new List<IShape>();
            _points = new List<SHPPoint>();
        }

        #endregion
        #region Properties
        #endregion
        #region Methods

        /// <summary>
        /// Add a point directly
        /// </summary>
        /// <param name="point"></param>
        public void AddPoint(SHPPoint point)
        {
            _points.Add(point);
        }

        /// <summary>
        /// Add line directly
        /// </summary>
        /// <param name="line"></param>
        public void AddLine(SHPLine line)
        {
            // Need to link the edge to a point
            // i dont want to necessarily add this
            // to the point structure perhaps another
            // linking structure

            line.From.AddShape(line);
            line.To.AddShape(line);
            _shapes.Add(line);

            // Assume that the points have already been added
            // so we can avoid adding twice
        }

        /// <summary>
        /// Add rectangle directly
        /// </summary>
        /// <param name="rectangle"></param>
        public void AddRectangle(SHPRectangle rectangle)
        {
            // Assume that the point have already been added
            // so we can avoid adding twice

            SHPPoint p1 = rectangle.TopLeft;

            // Generate the remaining points

            SHPPoint p2 = GetPoint(p1.X + rectangle.Width, p1.Y,p1.Z);
            SHPPoint p3 = GetPoint(p1.X + rectangle.Width, p1.Y-rectangle.Y, p1.Z);
            SHPPoint p4 = GetPoint(p1.X, p1.Y - rectangle.Y, p1.Z);

            // Convert the rectangle into lines

            SHPLine l1 = new SHPLine(p1, p2);
            p1.AddShape(l1);
            p2.AddShape(l1);
            _shapes.Add(l1);

            SHPLine l2 = new SHPLine(p2, p3);
            p2.AddShape(l2);
            p3.AddShape(l2);
            _shapes.Add(l2);

            SHPLine l3 = new SHPLine(p3, p4);
            p3.AddShape(l3);
            p4.AddShape(l3);
            _shapes.Add(l3);

            SHPLine l4 = new SHPLine(p4, p1);
            p4.AddShape(l4);
            p1.AddShape(l4);
            _shapes.Add(l4);

        }


        /// <summary>
        /// Add shape
        /// </summary>
        /// <param name="shape"></param>
        public void AddShape(IShape shape)
        {
            if (shape.GetType() == typeof(SHPLine))
            {
                AddLine((SHPLine)shape);
            }
            else if (shape.GetType() == typeof(SHPPoint))
            {
                AddPoint((SHPPoint)shape);
            }
            else if (shape.GetType() == typeof(SHPRectangle))
            {
                AddRectangle((SHPRectangle)shape);
            }
            else
            {
                throw new NotImplementedException("Shape not supported");
                //_shapes.Add(shape);
            }
        }

        /// <summary>
        /// Create or get an existing point if the
        /// cordinates match exectly 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <returns></returns>
        public SHPPoint GetPoint(double x, double y, double z)
        {
            SHPPoint point = new SHPPoint(x, y, z);
            int pos = _points.BinarySearch(point);
            if (pos < 0)
            {
                _points.Add(point);
            }
            else
            {
                point = _points[pos];
            }
            return (point);
        }



        /// <summary>
        /// Convert unordered line, args to polygons and polylines
        /// </summary>
        public void Simplify()
        {
            // Carry out a depthfirst search on line segments
            // the problem here is that we need to build the connected
            // list of points by constructing a graph or we take
            // the same approach which is to build it as we go.

            Console.WriteLine("Reset");
            foreach(SHPPoint point in _points)
            {
                point.Status = SHPShape.SearchStatus.None;
            }

            // Now check through the points

            Console.WriteLine("Check which points are connected");
            foreach (SHPPoint point in _points)
            {
                if (point.Status == SHPShape.SearchStatus.Linked)
                {
                    Console.WriteLine("Try to link");

                }
                else if (point.Status == SHPShape.SearchStatus.None)
                {
                    Console.WriteLine("Try to simplify");

                    // Find all the points that are connected

                    List<SHPPoint> connected = new List<SHPPoint>();
                    DepthFirstSearch(connected, point);

                    // Sort the list by degree

                    Console.WriteLine("Sort points by degree");
                    connected.Sort(
                        delegate (SHPPoint p1, SHPPoint p2)
                        {
                            return p1.Degree.CompareTo(p2.Degree);
                        }
                    );

                    foreach (SHPPoint newPoint in connected)
                    {
                        if ((newPoint.Status & SHPShape.SearchStatus.Linked) == 0)
                        {
                            Console.WriteLine("Link shapes");
                            List<IShape> chain = new List<IShape>();
                            LinkSearch(chain, newPoint);

                            Console.WriteLine("List chain");
                            foreach (IShape shape in chain)
                            {
                                Console.WriteLine("shape=" + shape);
                            }
                        }
                    }
                }
            }
        }

        IEnumerator<IShape> IEnumerable<IShape>.GetEnumerator()
        {
            return (_shapes.GetEnumerator());
        }

        //public DXFDocument ToDXF()
        //{
        //    DXFDocument dXFDocument = new DXFDocument();
        //    return (dXFDocument);
        //}

        //public GcodeDocument ToGCode()
        //{
        //    GcodeDocument gcodeDocument = new GcodeDocument();
        //    return (gcodeDocument);
        //}

        public void Save(string path, string filename)
        {
            string filenamePath = System.IO.Path.Combine(path, filename);
            BinaryWriter binaryWriter = new BinaryWriter(new FileStream(filenamePath + ".shp", FileMode.OpenOrCreate));
            binaryWriter.Seek(0, SeekOrigin.Begin); // Move to start of the file

            foreach (SHPShape shape in _shapes)
            {
                SHPShape.ShapeType shapeType = shape.Type;  // 1 byte
                if (shapeType == SHPShape.ShapeType.Line)
                {
                    SHPLine line = (SHPLine)shape;
                    binaryWriter.Write((byte)shapeType);
                    SHPPoint from = line.From;
                    SHPPoint to = line.To;
                    binaryWriter.Write((double)from.X);     // 8 bytes
                    binaryWriter.Write((double)from.Y);     // 8 bytes
                    binaryWriter.Write((double)to.X);       // 8 bytes
                    binaryWriter.Write((double)to.Y);       // 8 bytes
                }
            }
            binaryWriter.Flush();
            binaryWriter.Close();
            binaryWriter.Dispose();
        }

        public bool Load(string path, string filename)
        {
            bool loaded = false;

            string filenamePath = System.IO.Path.Combine(path, filename);
            BinaryReader binaryReader = new BinaryReader(new FileStream(filenamePath + ".shp", FileMode.OpenOrCreate));
            binaryReader.BaseStream.Seek(0, SeekOrigin.Begin); // Move to start of the file

            if (binaryReader.BaseStream.Length > 0)
            {
                _shapes.Clear();
                try
                {
                    do
                    {
                        byte type = binaryReader.ReadByte();
                        if (type == (byte)SHPShape.ShapeType.Line)
                        {
                            double X = binaryReader.ReadDouble();
                            double Y = binaryReader.ReadDouble();
                            SHPPoint from = new SHPPoint(X, Y, 0);
                            X = binaryReader.ReadDouble();
                            Y = binaryReader.ReadDouble();
                            SHPPoint to = new SHPPoint(X, Y, 0);
                            SHPLine line = new SHPLine(from, to);
                            _shapes.Add(line);
                        }
                    } while (binaryReader.BaseStream.Position != binaryReader.BaseStream.Length);
                }
                catch
                {
                    throw new IOException();
                }
            }
            binaryReader.Close();
            binaryReader.Dispose();
            return (loaded);
        }


        #endregion
        #region Private

        private void LinkSearch(List<IShape> chain, SHPPoint newPoint)
        {
            // This search aims to link the points together into long chains
            // only want to choose points from the connected list
            // Need to return a chain of shapes. The starting point should be any
            // line endings

            bool searching = true;
            newPoint.Status |= SHPShape.SearchStatus.Start;
            SHPPoint point;
            do
            {
                point = newPoint;
                // Get one of the shapes
                if (point.Shapes.Count > 0)
                {
                    foreach (IShape shape in point.Shapes)
                    {
                        if (shape.GetType() == typeof(SHPPoint))
                        {
                            // check if we enter here
                            searching = false;
                            break;
                        }
                        else if (shape.GetType() == typeof(SHPLine))
                        {
                            SHPLine line = (SHPLine)shape;

                            if (line.Status == SHPShape.SearchStatus.None)
                            {
                                line.Status |= SHPShape.SearchStatus.Visited;
                                if (point == line.To)
                                {
                                    // Swap ends
                                    SHPPoint temp = line.To;
                                    line.To = line.From;
                                    line.From = temp;
                                }
                                Console.WriteLine("Add=" + line);
                                chain.Add(line);

                                newPoint = line.To;
                                newPoint.Status |= SHPShape.SearchStatus.Linked;

                                if (newPoint.Degree == 1)
                                {
                                    newPoint.Status |= SHPShape.SearchStatus.End;
                                    searching = false;
                                }
                                else if ((newPoint.Status & SHPShape.SearchStatus.Start) == SHPShape.SearchStatus.Start)
                                {
                                    searching = false;
                                }
                                break;
                            }
                            else
                            {
                                // Nothing to search for
                            }
                        }
                    }
                }
                else
                {
                    searching = false;
                }
                
                // should have a new point

            }
            while (searching == true);

        }

        private void DepthFirstSearch(List<SHPPoint> connected, SHPPoint point)
        {
            Console.WriteLine("point=" + point);
            point.Status = SHPShape.SearchStatus.Visited;
            if (point.Degree > 0)
            {
                // Trap the case where points are isolated
                connected.Add(point);

                foreach (IShape shape in point.Shapes)
                {

                    if (shape.GetType() == typeof(SHPLine))
                    {
                        SHPLine line = (SHPLine)shape;

                        // May have ends reversed but would
                        // be good to assume that there is
                        // a directon when the shapes are added

                        if (point == line.From)
                        {
                            if (line.To.Status == SHPShape.SearchStatus.None)
                            {
                                Console.WriteLine("line=" + line);
                                DepthFirstSearch(connected, line.To);
                            }
                        }
                        else
                        {
                            if (line.From.Status == SHPShape.SearchStatus.None)
                            {
                                Console.WriteLine("line=" + line);
                                DepthFirstSearch(connected, line.From);
                            }
                        }
                    }
                }
            }
        }

        #endregion

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
