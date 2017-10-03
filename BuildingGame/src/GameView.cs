using System;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BuildingGame
{
    class GameView
    {
        Map map;
        Camera camera;
        BuildManager bm;
        Overlay overlay;


        public GameView()
        {
            map = new Map(30,30);
            camera = new Camera();
            bm = new BuildManager(map);
            map.Camera = camera;

            

            overlay = new Overlay(this);

        }

        public void LoadContent(ContentManager Content)
        {
            Sprites.LoadContent(Content);
            Fonts.LoadContent(Content);
        }

        public void Update(GameTime gameTime)
        {
            Input.Update(gameTime);
            bm.Update(gameTime);

            map.Update(gameTime);
            overlay.Update(gameTime);


        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            map.Draw(spriteBatch, gameTime);
            bm.Draw(spriteBatch, gameTime);
            overlay.Draw(spriteBatch, gameTime);

        }

        public Map Map { get { return map; }}


    }
}