using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BuildingGame
{
    internal class Overlay
    {
        MouseCursor mouseCursor;
        StaticText HolzTxt;
        StaticText SteinTxt;

        Minimap minimap;


        GameView gameView;

        public Overlay(GameView gameView)
        {
            this.gameView = gameView;
            mouseCursor = new MouseCursor();
            HolzTxt = new StaticText(new Vector2(9, 5), Color.White);
            SteinTxt = new StaticText(new Vector2(51, 5), Color.White);
            minimap = new Minimap(gameView.Map);
        }

        internal void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Begin();
            Sprites.Bar.Draw(spriteBatch, new Vector2(0, 0));
            Sprites.Holz.Draw(spriteBatch, new Vector2(7, 3));
            Sprites.Stein.Draw(spriteBatch, new Vector2(49, 3));
            Sprites.Werkzeug.Draw(spriteBatch, new Vector2(91, 3));
            HolzTxt.Draw(spriteBatch);
            SteinTxt.Draw(spriteBatch);
            minimap.Draw(spriteBatch);

            mouseCursor.Draw(spriteBatch);

            spriteBatch.End();
        }




        internal void Update(GameTime gameTime)
        {
            
            HolzTxt.Text = gameView.Map.Inventory.GetItem(Item.ItemType.Holz).Amount.ToString();
            SteinTxt.Text = gameView.Map.Inventory.GetItem(Item.ItemType.Stein).Amount.ToString();

            mouseCursor.Update(gameTime);
        }
    }
}