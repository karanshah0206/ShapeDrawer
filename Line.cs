using System;
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
            SplashKit.DrawLine(_color, SplashKit.LineFrom(_x, _y, _x + _length, _y + _depth));
        }

        public override void DrawOutline()
        {
        }

        public override bool IsAt(Point2D pt)
        {
            return false;
        }
    }
}
