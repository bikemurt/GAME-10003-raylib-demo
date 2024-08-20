using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace raylib_demo
{
    internal class Lines
    {
        // what's a struct? well it's like a class, but is better for more primitive datatypes
        // don't worry about it too much
        struct Line
        {
            public Vector2 StartPos;
            public Vector2 EndPos;
            public Color Color;
            public void Draw()
            {
                Raylib.DrawLineV(StartPos, EndPos, Color);
            }
        }

        // a List is a very flexible container, like an array. get used to using them!!
        List<Line> lines = new List<Line>();
        Line tempLine = new Line();

        public void Setup()
        {
            tempLine.Color = Color.Red;
        }

        public void Update()
        {
            int mouseX = Raylib.GetMouseX();
            int mouseY = Raylib.GetMouseY();
            Vector2 mousePos = new Vector2(mouseX, mouseY);

            if (Raylib.IsMouseButtonPressed(MouseButton.Left))
            {
                tempLine.StartPos = mousePos;
            }

            if (Raylib.IsMouseButtonDown(MouseButton.Left))
            {
                tempLine.EndPos = mousePos;
                tempLine.Draw();
            }

            if (Raylib.IsMouseButtonReleased(MouseButton.Left))
            {
                lines.Add(tempLine);
            }

            foreach (Line l in lines)
            {
                l.Draw();
            }
        }
    }
}
