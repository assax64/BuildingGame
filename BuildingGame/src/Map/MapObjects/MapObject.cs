using System;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace BuildingGame
{
    class MapObject
    {
        Map map;
        Cell[,] cells;
        Sprite sprite;

        public MapObject()
        {

        }

        public virtual void PlaceOnMap(Map map, Cell[,] cells)
        {
            this.map = map;
            this.cells = cells;
            map.AddObject(this);
        }

        public virtual void Update(float tick)
        {

        }


        public virtual void Draw(SpriteBatch spriteBatch, Map map)
        {
            Vector2 origin = cells[0, 0].Position; 
            if (map.Rotation == 0)
                origin = cells[0, 0].Position;
            else if (map.Rotation == 1)
                origin = cells[cells.GetLength(0) - 1, 0].Position;
            else if (map.Rotation == 2)
                origin = cells[cells.GetLength(0) - 1, cells.GetLength(1) - 1].Position;
            else if (map.Rotation == 3)
                origin = cells[0, cells.GetLength(1) - 1].Position;

            sprite.Draw(spriteBatch, map.CalcWorldToScreen(origin));
        }

        public Map Map
        {
            get
            {
                return map;
            }
            set
            {
                map = value;
            }
        }

        public Cell[,] Cells
        {
            get
            {
                return cells;
            }
            set
            {
                cells = value;
            }
        }

        public Sprite Sprite
        {
            get
            {
                return sprite;
            }
            set
            {
                sprite = value;
            }
        }
    }
}