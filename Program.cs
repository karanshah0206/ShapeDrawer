using System;
using SplashKitSDK;
namespace ShapeDrawer
{
    public class Program
    {
        public static void Main()
        {
            Drawing canvas = new Drawing();
            new Window("Shape Drawer", 800, 600);

            do
            {
                SplashKit.ProcessEvents();
                canvas.Draw();

                if (SplashKit.MouseClicked(MouseButton.LeftButton))
                {
                    Shape myShape = new Shape();
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

                if (SplashKit.KeyTyped(KeyCode.DeleteKey) || SplashKit.KeyTyped(KeyCode.BackspaceKey))
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