using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BuildingGame
{
    class Holzfäller : Building
    {
        ProductionHandler production;
        AnimatedText infoText;

        public Holzfäller()
        {
            Sprite = Sprites.Holzfäller;
            Cost = new Item(Item.ItemType.Holz, 5);
        }

        public override void PlaceOnMap(Map map, Cell[,] cells)
        {
            base.PlaceOnMap(map, cells);
            production = new ProductionHandler(Item.ItemType.Holz, 5f, 1f);
            production.ItemProduced += new ProductionHandler.Product(ItemProduced);
            production.Start();
            
            infoText = new AnimatedText(map.CalcWorldToScreen(Cells[0, 0].Position) - new Vector2(10, 100), 1.5f, Color.Yellow);
        }

        private void ItemProduced(Item item)
        {
            Map.Inventory.AddItem(item);
            infoText.Text = "+" + item.Amount + " " + item.GetName();
            infoText.Play();
        }

        

        public override void Update(float tick)
        {
            base.Update(tick);
            infoText.Update(tick);
            production.Update(tick);
        }

        public override void Draw(SpriteBatch spriteBatch, Map map)
        {
            base.Draw(spriteBatch, map);
            infoText.Draw(spriteBatch);
        }

    }
}