using System;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace BuildingGame
{
    class Sprite
    {
        public Texture2D Texture { get; set; }
        Vector2 origin;

        public Sprite(Vector2 Origin)
        {
            origin = Origin;
        }

        public virtual void LoadContent(ContentManager content, string name)
        {
            Texture = content.Load<Texture2D>(name);
        }

        public virtual void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            Draw(spriteBatch, position, Color.White);
        }

        internal void Draw(SpriteBatch spriteBatch, Vector2 position, Color color)
        {
            spriteBatch.Draw(Texture, position - origin, color);
        }

    }
}