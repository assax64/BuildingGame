using System;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace BuildingGame
{
    static class Fonts
    {
        public static SpriteFont Standard { get; set; }

        static Fonts()
        {
            
        }

        public static void LoadContent(ContentManager content)
        {
            Standard = content.Load<SpriteFont>(@"gui\font");

        }
    }
}