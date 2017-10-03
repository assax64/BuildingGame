using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BuildingGame
{
    class BuildManager
    {
        Map map;
        CellSelection cs;
        BuildingType toBuild;

        public enum BuildingType
        {
            Strasse,
            Wohnhaus,
            Holzfäller
        };

        public BuildManager(Map map)
        {
            this.map = map;
        }



        internal void Update(GameTime gameTime)
        {
            if (cs != null)
            {
                if (Input.MouseClicked)
                {
                    if (toBuild == BuildingType.Holzfäller)
                    {
                        Holzfäller b = new Holzfäller();
                        b.PlaceOnMap(map, cs.GetCells());
                        cs = null;
                    }

                }
            }


            if (Keyboard.GetState().IsKeyDown(Keys.D1))
            {
                cs = new CellSelection(map, 2, 2);
                toBuild = BuildingType.Holzfäller;
            }
           

            if (cs != null)
                cs.Update(gameTime);


        }


        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            
            spriteBatch.Begin();
            if (cs != null)
                cs.Draw(spriteBatch, gameTime);
            spriteBatch.End();
        }
    }
}