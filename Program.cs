using System;
using SplashKitSDK;
namespace ShapeDrawer
{
    public class Program
    {
        private enum ShapeKind
        {
            Rectangle,
            Circle
        }

        public static void Main()
        {
            ShapeKind kindToAdd = ShapeKind.Circle;

            Drawing canvas = new Drawing();
            new Window("Shape Drawer", 800, 600);

            do
            {
                SplashKit.ProcessEvents();
                canvas.Draw();

                if (SplashKit.MouseClicked(MouseButton.LeftButton))
                {
                    Shape myShape;

                    if (kindToAdd == ShapeKind.Rectangle)
                    {
                        Rectangle myRect = new Rectangle();
                        myShape = myRect;
                    }
                    else
                    {
                        Circle myCircle = new Circle();
                        myShape = myCircle;
                    }

                    myShape.X = SplashKit.MouseX();
                    myShape.Y = SplashKit.MouseY();
                    canvas.AddShape(myShape);
                }

                if (SplashKit.MouseClicked(MouseButton.RightButton))
                {
                    canvas.SelectShapesAt(SplashKit.MousePosition());
                }

                if (SplashKit.KeyTyped(KeyCode.SpaceKey))
                {
                    canvas.Background = Color.RandomRGB(255);
                }
                else if (SplashKit.KeyTyped(KeyCode.RKey))
                {
                    kindToAdd = ShapeKind.Rectangle;
                }
                else if (SplashKit.KeyTyped(KeyCode.CKey))
                {
                    kindToAdd = ShapeKind.Circle;
                }
                else if (SplashKit.KeyTyped(KeyCode.DeleteKey) || SplashKit.KeyTyped(KeyCode.BackspaceKey))
                {
                    foreach(Shape shape in canvas.SelectedShapes)
                    {
                        canvas.RemoveShape(shape);
                    }
                }

                SplashKit.RefreshScreen();
            } while (!SplashKit.WindowCloseRequested("Shape Drawer"));
        }
    }
}