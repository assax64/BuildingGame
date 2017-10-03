using System;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace BuildingGame
{
    class AnimatedSprite : Sprite
    {
        float frameTime;
        float elapsedTime;
        int currentFrame;
        int totalFrames;
        bool play;

        public AnimatedSprite(int Frames, float FrameTime) : base (new Vector2(0,0))
        {
            totalFrames = Frames;
            currentFrame = 0;
            elapsedTime = 0f;
            frameTime = FrameTime;

        }

        public void Play()
        {
            play = true;
        }

        public void Stop()
        {
            play = false;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            int width = Texture.Width / totalFrames;
            int height = Texture.Height;

            Rectangle destRect = new Rectangle((int)position.X - width/2, (int)position.Y - height, width, height);
            Rectangle sourceRect = new Rectangle(currentFrame * width, 0, width, height);

            spriteBatch.Draw(Texture, destRect, sourceRect, Color.White);

        }

        public void Update(float tick)
        {
            if (play)
            {
                if (elapsedTime * 1000 > frameTime)
                {
                    elapsedTime = 0;
                    currentFrame++;
                    if (currentFrame >= totalFrames)
                        currentFrame = 0;
                }
                elapsedTime += tick;
            } 
        }
    }
}