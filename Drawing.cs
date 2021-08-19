using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;

namespace ShapeDrawer
{
    class Drawing
    {
        private List<Shape> _shapes = new List<Shape>();
        private Color _background;

        public Drawing()
        { }

        public List<Shape> SelectedShapes
        { /* Add get handle here */ }

        public int ShapeCount
        { /* Add get handle here */ }

        public Color Background
        { /* Add get, set handles here */ }

        public void Draw()
        { }

        public void SelectShapesAt(Point2D pt)
        { }

        public void AddShape(Shape s)
        { }

        public void RemoveShape(Shape s)
        { }
    }
}
