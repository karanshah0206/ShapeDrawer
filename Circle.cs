using SplashKitSDK;

namespace ShapeDrawer
{
    class Circle : Shape
    {
        private int _radius;

        public Circle()
        {
            _radius = 50;
        }

        public int Radius
        {
            get { return _radius; }
            set { _radius = value; }
        }

        public override void Draw()
        {
            if (_selected) DrawOutline();
            SplashKit.FillCircle(_color, _x, _y, _radius);
        }

        public override void DrawOutline()
        {
            SplashKit.FillCircle(Color.Black, _x, _y, _radius+2);
        }
    }
}
