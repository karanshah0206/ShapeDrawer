using System;
using SplashKitSDK;
namespace ShapeDrawer
{
    public class Program
    {
        private enum ShapeKind
        {
            Rectangle,
            Circle,
            Line
        }

        public static void Main()
        {
            Shape.RegisterShape("Rectangle", typeof(Rectangle));
            Shape.RegisterShape("Circle", typeof(Circle));
            Shape.RegisterShape("Line", typeof(Line));

            ShapeKind kindToAdd = ShapeKind.Circle;
            String savePath  = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/TestDrawing.txt";

            Drawing canvas = new Drawing();
            new Window("Shape Drawer", 800, 600);

            do
            {
                SplashKit.ProcessEvents();
                canvas.Draw();

                if (SplashKit.MouseClicked(MouseButton.LeftButton))
                {
                    Shape myShape;

                    switch(kindToAdd)
                    {
                        case ShapeKind.Rectangle:
                            Rectangle myRect = new Rectangle();
                            myShape = myRect;
                            break;
                        case ShapeKind.Circle:
                            Circle myCircle = new Circle();
                            myShape = myCircle;
                            break;
                        case ShapeKind.Line:
                            Line myLine = new Line();
                            myShape = myLine;
                            break;
                        default: goto case ShapeKind.Rectangle;
                    }

                    myShape.X = SplashKit.MouseX();
                    myShape.Y = SplashKit.MouseY();
                    canvas.AddShape(myShape);
                }

                if (SplashKit.MouseClicked(MouseButton.RightButton))
                    canvas.SelectShapesAt(SplashKit.MousePosition());

                if (SplashKit.KeyTyped(KeyCode.SpaceKey)) canvas.Background = Color.RandomRGB(255);
                else if (SplashKit.KeyTyped(KeyCode.RKey)) kindToAdd = ShapeKind.Rectangle;
                else if (SplashKit.KeyTyped(KeyCode.CKey)) kindToAdd = ShapeKind.Circle;
                else if (SplashKit.KeyTyped(KeyCode.LKey)) kindToAdd = ShapeKind.Line;
                else if (SplashKit.KeyTyped(KeyCode.SKey)) canvas.Save(savePath);
                else if (SplashKit.KeyTyped(KeyCode.OKey))
                    try { canvas.Load(savePath); }
                    catch (Exception e) { Console.Error.WriteLine("Error in loading file: {0}", e.Message); }
                else if (SplashKit.KeyTyped(KeyCode.DeleteKey) || SplashKit.KeyTyped(KeyCode.BackspaceKey))
                    foreach (Shape shape in canvas.SelectedShapes)
                        canvas.RemoveShape(shape);

                SplashKit.RefreshScreen();
            } while (!SplashKit.WindowCloseRequested("Shape Drawer"));
        }
    }
}