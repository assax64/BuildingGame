using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BuildingGame
{
    class StaticText
    {
        string text;
        Color color;
        Vector2 origin;


        public StaticText(Vector2 origin, Color color)
        {
            this.origin = origin;
            this.color = color;
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
           spriteBatch.DrawString(Fonts.Standard, text, origin, color);
        }

        public string Text
        {
            get
            {
                return text;
            }
            set
            {
                text = value;
            }
        }

        public Color Color
        {
            get
            {
                return color;
            }
            set
            {
                color = value;
            }
        }

        public Vector2 Origin
        {
            get
            {
                return origin;
            }
            set
            {
                origin = value;
            }
        }

    }
}