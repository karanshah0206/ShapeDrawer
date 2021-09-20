using System;
using System.IO;
using SplashKitSDK;

namespace ShapeDrawer
{
    class Line : Shape
    {
        private int _length, _depth;

        public Line() : this(Color.Red, 100, 100)
        { }

        public Line(Color clr, int length, int depth) : base(clr)
        {
            _length = length;
            _depth = depth;
        }

        public override void Draw()
        {
            if (_selected) DrawOutline();
            SplashKit.DrawLine(_color, SplashKit.LineFrom(_x, _y, _x + _length, _y + _depth));
        }

        public override void DrawOutline()
        {
            Circle c1 = new Circle(_color, 7);
            Circle c2 = new Circle(_color, 7);

            c1.X = _x; c1.Y = _y;
            c2.X = _x + _length; c2.Y = _y + _length;

            c1.Draw();
            c2.Draw();
        }

        public override bool IsAt(Point2D pt)
        {
            float lineSlope = _depth/_length;
            float ptSlope = (float)((pt.Y - _y)/(pt.X - _x));
            return ((lineSlope == ptSlope) && (pt.X >= _x) && (pt.X <= _x + _length) && (pt.Y >= _y) && (pt.Y <= _y + _depth));
        }

        public override void SaveTo(StreamWriter writer)
        {
            writer.WriteLine("Line"); // Write Shape Type
            base.SaveTo(writer); // Write Color + Coordinates
            writer.WriteLine(_length); // Write Length
            writer.WriteLine(_depth); // Write Depth
        }

        public override void LoadFrom(StreamReader reader)
        {
            base.LoadFrom(reader); // Read Color + Coordinates
            _length = reader.ReadInteger(); // Read Length
            _depth = reader.ReadInteger(); // Read Depth
        }
    }
}
