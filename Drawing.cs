using System;
using System.Collections.Generic;
using System.IO;
using SplashKitSDK;

namespace ShapeDrawer
{
    class Drawing
    {
        private List<Shape> _shapes;
        private Color _background;

        public Drawing(Color background)
        {
            _shapes = new List<Shape>();
            _background = background;
        }

        public Drawing() : this (Color.White) { }

        public List<Shape> SelectedShapes
        {
            get
            {
                List<Shape> SelectedShapes = new List<Shape>();
                foreach(Shape shape in _shapes)
                    if (shape.Selected)
                        SelectedShapes.Add(shape);
                return SelectedShapes;
            }
        }

        public int ShapeCount
        {
            get { return _shapes.Count; }
        }

        public Color Background
        {
            get { return _background; }
            set { _background = value; }
        }

        public void Draw()
        {
            SplashKit.ClearScreen(_background);
            foreach(Shape shape in _shapes) { shape.Draw(); }
        }

        public void SelectShapesAt(Point2D pt)
        {
            foreach(Shape shape in _shapes)
            {
                if (shape.IsAt(pt))
                    shape.Selected = true;
                else
                    shape.Selected = false;
            }
        }

        public void AddShape(Shape s)
        {
            _shapes.Add(s);
        }

        public void RemoveShape(Shape s)
        {
            _shapes.Remove(s);
        }

        public void Save(string filename)
        {
            StreamWriter writer = new StreamWriter(filename);

            writer.WriteColor(_background); // Write Background Color
            writer.WriteLine(_shapes.Count); // Write Shape Count

            // Save Shapes
            foreach (Shape s in _shapes)
            { s.SaveTo(writer); }

            writer.Close();
        }

        public void Load(string filename)
        {
            StreamReader reader = new StreamReader(filename);
            int count; string kind; Shape s;

            try {
                _shapes.Clear(); // Clear Canvas

                _background = reader.ReadColor(); // Read + Set Background Color
                count = reader.ReadInteger(); // Read Shape Count

                for (int i = 0; i < count; i++)
                {
                    kind = reader.ReadLine(); // Read Shape Type
                    switch (kind)
                    {
                        case "Rectangle": s = new Rectangle(); break;
                        case "Circle": s = new Circle(); break;
                        case "Line": s = new Line(); break;
                        default: throw new InvalidDataException("Unknown Shape Kind: " + kind);
                    }
                    s.LoadFrom(reader); // Read Shape Color + Coordinates + Dimensions
                    AddShape(s); // Draw Shape
                }
            }
            catch (Exception e) { Console.Error.WriteLine("Error in loading file: " + e.Message); }
            finally { reader.Close(); }
        }
    }
}
