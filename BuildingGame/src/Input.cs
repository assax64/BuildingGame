using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace BuildingGame
{
    public static class Input
    {
        private static bool mouseDown;

        public static bool MouseClicked { get; private set; }

        public static bool SpacePressed { get; private set; }

        public static Point MousePosition { get; private set; }

        public static void Update(GameTime gameTime)
        {
            MousePosition = Mouse.GetState().Position;

            MouseClicked = false;
            if (Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                if (mouseDown == false)
                {
                    MouseClicked = true;
                    mouseDown = true;
                }
            }

            if (Mouse.GetState().LeftButton == ButtonState.Released)
            {
                mouseDown = false;
            }

            

        }
    }
}