using System;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace BuildingGame
{
    static class Sprites
    {
        public static StaticSprite Gras { get; }

        public static StaticSprite Holzfäller { get; }

        public static StaticSprite MouseCursor { get; }
        public static StaticSprite FreeSpace { get; }
        public static StaticSprite BlockedSpace { get; }
        public static StaticSprite Bar { get; }
        public static StaticSprite Holz { get; }
        public static StaticSprite Stein { get; }
        public static StaticSprite Werkzeug { get; }
        public static StaticSprite Pixel { get; }



        static Sprites()
        {
            Gras = new StaticSprite(new Vector2(32, 31));

            Holzfäller = new StaticSprite(new Vector2(64, 64));

            MouseCursor = new StaticSprite(new Vector2(0, 0));
            FreeSpace = new StaticSprite(new Vector2(32,32));
            BlockedSpace = new StaticSprite(new Vector2(32,32));
            Bar = new StaticSprite(new Vector2(0, 0));
            Holz = new StaticSprite(new Vector2(0, 0));
            Stein = new StaticSprite(new Vector2(0, 0));
            Werkzeug = new StaticSprite(new Vector2(0, 0));
            Pixel = new StaticSprite(new Vector2(1, 1));


        }

        public static void LoadContent(ContentManager content)
        {
            Gras.LoadContent(content, @"terrain\0");

            Holzfäller.LoadContent(content, @"buildings\holzfäller");

            MouseCursor.LoadContent(content, @"gui\cursor");
            FreeSpace.LoadContent(content, @"gui\freespace");
            BlockedSpace.LoadContent(content, @"gui\blockedspace");
            Bar.LoadContent(content, @"gui\bar");
            Holz.LoadContent(content, @"gui\holz");
            Stein.LoadContent(content, @"gui\stein");
            Werkzeug.LoadContent(content, @"gui\werkzeug");
            Pixel.LoadContent(content, @"gui\pixel");

        }
    }
}