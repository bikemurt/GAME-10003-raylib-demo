using Raylib_cs;

namespace raylib_demo
{
    internal class Program
    {
        static string title = "Game Title";
        static int screenWidth = 800;
        static int screenHeight = 600;
        static int targetFps = 60;

        static void Main()
        {
            // this is a simple way to test out different demos in RayLib
            // the "t" variable is a different class each time, but as long as we program them
            // all with Setup() and Update() methods, we're good

            // comment out the ones you don't want to run

            //Lines t = new Lines();
            Grid t = new Grid(screenWidth, screenHeight, 5, 5);

            Raylib.InitWindow(screenWidth, screenHeight, title);
            Raylib.SetTargetFPS(targetFps);
            t.Setup();
            while (!Raylib.WindowShouldClose())
            {
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.RayWhite);
                t.Update();
                Raylib.EndDrawing();
            }
            Raylib.CloseWindow();
        }
    }
}
