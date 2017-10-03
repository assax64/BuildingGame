using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace BuildingGame
{
    class CellSelection
    {
        Sprite freeSpace;
        Sprite blockedSpace;
        Map map;
 
        Cell[,] cells;

        int width;
        int height;
        
        public CellSelection(Map map, int width, int height)
        {
            this.map = map;
            cells = new Cell[width, height];
            this.width = width;
            this.height = height;

            freeSpace = Sprites.FreeSpace;
            blockedSpace = Sprites.BlockedSpace;
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            
            foreach (Cell c in cells)
            {
                if (c.Building == null)
                freeSpace.Draw(spriteBatch, Vector2.Transform(map.CalcWorldToScreen(c.Position), map.Camera.GetMatrix()));
                else
                    blockedSpace.Draw(spriteBatch, Vector2.Transform(map.CalcWorldToScreen(c.Position), map.Camera.GetMatrix()));
            }

        }

        public Cell[,] GetCells()
        {
            return cells;
        }

        public void SetSize(int width,int height)
        {
            this.width = width;
            this.height = height;
        }


        public void Update(GameTime gameTime)
        {
            Vector2 trans = Vector2.Transform(Input.MousePosition.ToVector2(), Matrix.Invert(map.Camera.GetMatrix()));
            Vector2 position = map.CalcScreenToWorld(trans);

            position -= new Vector2(width / 2, height / 2);

            Point p = Vector2.Clamp(position.ToPoint().ToVector2(), new Vector2(0, 0), new Vector2(map.Width - 1, map.Height - 1)).ToPoint();



            

            //Point p = _map.Selector.GetCellWorldPosition(); // - new Point(building.Size.X / 2, building.Size.Y / 2)
            if (p.X + width >= map.Width)
                p.X = map.Width - width;
            if (p.Y + height >= map.Height)
                p.Y = map.Height - height;

            //if (p.X - building.Size.X <= 0)
            //    p.X = building.Size.X;
            //if (p.Y - building.Size.Y <= 0)
            //    p.Y = building.Size.Y;
            
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    cells[x,y] = map.Grid.Cells[p.X + x, p.Y + y];
                }
            }
        }

        //public bool canBuild()
        //{
        //    foreach (Cell c in _cells)
        //    {
        //        if (c.Building != null)
        //            return false;
        //    }
        //    return true;
        //}

        

    }

}