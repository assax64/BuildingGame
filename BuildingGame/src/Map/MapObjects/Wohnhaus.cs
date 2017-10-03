using Microsoft.Xna.Framework;

namespace BuildingGame
{
    class Wohnhaus : Building
    {
        public Wohnhaus()
        {
            //Sprite = Sprites.Wohnhaus;
            Cost = new Item(Item.ItemType.Holz, 20);
        }
    }
}