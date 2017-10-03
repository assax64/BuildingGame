using System;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace BuildingGame
{
    class Cell
    {
        int x;
        int y;
        Sprite sprite;
        Building building;
        Tree tree;

        public Cell(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public void Draw(SpriteBatch spriteBatch, Map map)
        {
            sprite.Draw(spriteBatch, map.CalcWorldToScreen(new Vector2(x,y)));

            if (tree != null)
                tree.Draw(spriteBatch, map);

            if (building != null)
                building.Draw(spriteBatch, map);


            //spriteBatch.DrawString(Fonts.Standard, X + "," + Y, map.CalcWorldToScreen(new Vector2(x,y)) - new Vector2(10,20), Color.White); // Debug
        }

        public Vector2 Position
        {
            get
            {
                return new Vector2(x, y);
            }
        }

        public Sprite Sprite {
            get
            {
                return sprite;
            }
            set
            {
                sprite = value;
            }
        }

        public Building Building
        {
            get
            {
                return building;
            }
            set
            {
                building = value;
            }
        }

        public Tree Tree
        {
            get
            {
                return tree;
            }
            set
            {
                tree = value;
            }
        }

        public int X
        {
            get
            {
                return x;
            }
        }

        public int Y
        {
            get
            {
                return y;
            }
        }



    }
}