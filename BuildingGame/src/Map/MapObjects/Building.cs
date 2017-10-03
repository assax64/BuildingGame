using System;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace BuildingGame
{
    class Building : MapObject
    {
        AnimatedText infoText;
        Item cost;

        public Building()
        {
            
        }

        public override void PlaceOnMap(Map map, Cell[,] cells)
        {
            base.PlaceOnMap(map, cells);
            infoText = new AnimatedText(map.CalcWorldToScreen(Cells[0, 0].Position) - new Vector2(10, 100), 1.5f, Color.Red);
            infoText.Text = "-" + cost.Amount + " " + cost.GetName();
            infoText.Play();
        }

        public override void Update(float tick)
        {
            infoText.Update(tick);
        }

        public override void Draw(SpriteBatch spriteBatch, Map map)
        {
            base.Draw(spriteBatch, map);
            infoText.Draw(spriteBatch);
        }

        public Item Cost
        {
            get
            {
                return cost;
            }
            set
            {
                cost = value;
            }
        }

        

    }
}