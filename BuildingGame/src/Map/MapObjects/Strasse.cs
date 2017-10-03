using Microsoft.Xna.Framework;

namespace BuildingGame
{
    class Strasse : Building
    {
        public Strasse()
        {
            //Sprite = Sprites.Street;
            Cost = new Item(Item.ItemType.Stein, 1);
        }
    }
}