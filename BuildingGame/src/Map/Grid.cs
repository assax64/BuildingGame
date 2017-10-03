using System;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace BuildingGame
{
    class Grid
    {
        Cell[,] cells;
        int width;
        int height;
        int cellWidth;
        int cellHeight;

        public Grid(int width, int height, int cellWidth, int cellHeight)
        {
            this.width = width;
            this.height = height;
            this.cellWidth = cellWidth;
            this.cellHeight = cellHeight;

            CreateGrid();     
        }

        private void CreateGrid()
        {
            cells = new Cell[width, height];

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    cells[x, y] = new Cell(x, y);
                }
            }
        }

        public Cell GetCell(int x, int y)
        {
            return cells[x, y];
        }

        public Cell[,] Cells
        {
            get
            {
                return cells;
            }
        }
    }
}