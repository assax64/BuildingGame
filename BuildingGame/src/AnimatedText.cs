using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BuildingGame
{
    class AnimatedText : StaticText
    {
        float time;
        float elapsedTime;
        Vector2 position;
        bool playing;

        public AnimatedText(Vector2 origin, float animationTime, Color color) : base(origin, color)
        {
                this.time = animationTime;
        }

        public void Play()
        {
            elapsedTime = 0;
            position = Origin;
            playing = true;
        }

        public void Update(float tick)
        {
            if (playing)
            {
                if (elapsedTime < time)
                {
                    position -= new Vector2(0, tick * 20);
                    elapsedTime += tick;
                }
                else
                {
                    playing = false;
                }
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (playing & elapsedTime < time)
            {
                spriteBatch.DrawString(Fonts.Standard, Text, position, Color * ((time - elapsedTime) / time / 0.5f));
            }
        }
    }
}