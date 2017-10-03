using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BuildingGame
{
    class MouseCursor
    {
        Sprite sprite;
        Point position;
        public MouseCursor()
        {
            sprite = Sprites.MouseCursor;
            position = new Point(0, 0);
        }

        internal void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, position.ToVector2());
        }

        internal void Update(GameTime gameTime)
        {
            position = Mouse.GetState().Position;
        }
    }
}