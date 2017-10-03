using System;
using System.Collections.Generic;

namespace BuildingGame
{
    internal class Inventory
    {
        List<Item> items;
        public Inventory()
        {
            items = new List<Item>();

            AddItem(new Item(Item.ItemType.Holz, 15));
            AddItem(new Item(Item.ItemType.Stein, 50));
   
        }

        public void AddItem(Item item)
        {
            if (items.Exists(x => x.Type == item.Type))
            {
                items.Find(x => x.Type == item.Type).Amount += item.Amount;
            }
            else
            {
                items.Add(item);
            }
        }

        public void RemoveItem(Item item)
        {
            if (items.Exists(x => x.Type == item.Type))
            {
                items.Find(x => x.Type == item.Type).Amount -= item.Amount;
            }
            else
            {

            }
        }

        public Item GetItem(Item.ItemType Type)
        { 
                return items.Find(x => x.Type == Type);
        }

        public bool HasItem(Item cost)
        {
            return items.Find(x => x.Type == cost.Type).Amount >= cost.Amount;
        }
    }
}