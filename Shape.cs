using System.IO;
using SplashKitSDK;

namespace ShapeDrawer
{
    abstract class Shape
    {
        protected float _x, _y;
        protected Color _color;
        protected bool _selected;

        public Shape() : this(Color.Yellow)
        { }

        public Shape(Color clr)
        {
            _color = clr;
            _x = 0;
            _y = 0;
            _selected = false;
        }

        public Color Color
        {
            get { return _color; }
            set { _color = value; }
        }

        public float X
        {
            get { return _x; }
            set { _x = value; }
        }

        public float Y
        {
            get { return _y; }
            set { _y = value; }
        }

        public bool Selected
        {
            get { return _selected; }
            set { _selected = value; }
        }

        public virtual void SaveTo(StreamWriter writer)
        {
            writer.WriteColor(_color); // Write Color
            writer.WriteLine(_x); // Write X Coordinate
            writer.WriteLine(_y); // Write Y Coordinate
        }

        public virtual void LoadFrom(StreamReader reader)
        {
            _color = reader.ReadColor(); // Read Color
            _x = reader.ReadInteger(); // Read X Coordinate
            _y = reader.ReadInteger(); // Read Y Coordinate
        }

        public abstract void Draw();
        public abstract void DrawOutline();
        public abstract bool IsAt(Point2D pt);
    }
}
