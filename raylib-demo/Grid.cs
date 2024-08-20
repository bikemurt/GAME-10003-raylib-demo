using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace raylib_demo
{
    internal class Grid
    {
        public int ScreenWidth;
        public int ScreenHeight;
        public int NumberOfRows;
        public int NumberOfCols;

        // why private? because these things are not needed outside of thec lass
        private float rowHeight;
        private float colWidth;

        // if we don't specify, it is private by default
        Texture2D rockTexture;

        // this is a "constructor" - it may seem kind of useless at first glance
        // but it ensures that the "Grid" object is created with a minimum of these things
        // if we dont have screen size, or the row/column count, the class doesn't work
        public Grid(int screenWidth, int screenHeight, int numberOfRows, int numberOfCols)
        {
            ScreenWidth = screenWidth;
            ScreenHeight = screenHeight;
            NumberOfRows = numberOfRows;
            NumberOfCols = numberOfCols;

            // this part is important because it prevents division by zero
            if (NumberOfRows <= 0) {
                NumberOfRows = 1;
            }
            if (NumberOfCols <= 0)
            {
                NumberOfCols = 1;
            }

            rowHeight = ScreenHeight / NumberOfRows;
            colWidth = ScreenWidth / NumberOfCols;
        }

        public Texture2D LoadTexture(string fileName)
        {
            Texture2D texture = Raylib.LoadTexture(fileName);

            // stretch the texture to fit th ecell
            texture.Width = (int)colWidth;
            texture.Height = (int)rowHeight;

            return texture;
        }

        public void Setup()
        {
            // texture loading has to be done in Setup() ! good reasons for this...

            // take a look in the assets folder - you'll find a "tile map", where I've extracted a single tile
            // also take a look at the "single_tile.png" Properties in VisualStudio
            // notice 'Copy to Output Directory' is set to 'Copy Always'
            // this ensures the texture gets packed with our executable

            rockTexture = LoadTexture("assets/Atlas/single_tile.png");
        }

        public void DrawGrid()
        {
            // draw the lines
            // TEST YOUR UNDERSTANDING: why NumberOfRows - 1?
            for (int i = 0; i < NumberOfRows - 1; i++)
            {
                // the int in brackets (int) converts a float to an int, which is what the DrawLine() function wants
                // TEST YOUR UNDERSTANDING: why (i + 1)?
                int rowYPosition = (int)((i + 1) * rowHeight);

                Raylib.DrawLine(0, rowYPosition, ScreenWidth, rowYPosition, Color.Black);
            }
            for (int i = 0; i < NumberOfCols - 1; i++)
            {
                int colXPosition = (int)((i + 1) * colWidth);
                Raylib.DrawLine(colXPosition, 0, colXPosition, ScreenHeight, Color.Black);
            }
        }

        public Vector2 GetCellPosition(int row, int col)
        {
            return new Vector2(col * colWidth, row * rowHeight);
        }

        public Vector2 GetCellSize()
        {
            return new Vector2(colWidth, rowHeight);
        }

        public void FillCell(int row, int col, Color c)
        {
            Raylib.DrawRectangleV(GetCellPosition(row, col), GetCellSize(), c);
        }

        public void DrawTile(int row, int col, Texture2D texture)
        {

            Raylib.DrawTextureV(texture, GetCellPosition(row, col), Color.White);
        }

        public void Update()
        {
            DrawGrid();

            FillCell(0, 0, Color.Red);

            for (int col = 1; col <= 3; col++)
            {
                DrawTile(2, col, rockTexture);
            }

        }
    }
}
