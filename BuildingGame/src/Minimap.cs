using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace BuildingGame
{
    internal class Minimap
    {
        private Map map;

        public Minimap(Map map)
        {
            this.map = map;
        }

        internal void Draw(SpriteBatch spriteBatch)
        {
            foreach (Cell c in map.Grid.Cells)
            {
                if (c.Building != null)
                    Sprites.Pixel.Draw(spriteBatch, miniWorldToScreen(c.Position) + new Vector2(100, 100), Color.Yellow);
                else
                    Sprites.Pixel.Draw(spriteBatch, miniWorldToScreen(c.Position) + new Vector2(100, 100), Color.ForestGreen);
            }
        }

        public Vector2 miniWorldToScreen(Vector2 worldPosition)
        {

            float x_ = -(worldPosition.X - worldPosition.Y) * (2);
            float y_ = -(worldPosition.X + worldPosition.Y) * (1);
            return (new Vector2(x_, y_));
        }

    }
}