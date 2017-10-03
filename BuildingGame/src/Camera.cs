using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace BuildingGame
{
    internal class Camera
    {
        Vector2 position;  

        public Camera()
        {
            position = new Vector2(500, 500);
        }

        internal Matrix GetMatrix()
        {
            return Matrix.CreateTranslation(new Vector3(position, 0));
        }

        internal void Update(float tick)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.A))
                position += new Vector2(tick * 300, 0);

            if (Keyboard.GetState().IsKeyDown(Keys.D))
                position += new Vector2(-tick * 300, 0);

            if (Keyboard.GetState().IsKeyDown(Keys.W))
                position += new Vector2(0, tick * 300);

            if (Keyboard.GetState().IsKeyDown(Keys.S))
                position += new Vector2(0, -tick * 300);

            
        }
    }
}