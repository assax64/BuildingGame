using Microsoft.Xna.Framework;
using System;
using Microsoft.Xna.Framework.Graphics;

namespace BuildingGame
{

    class ProductionHandler
    {
        public event Product ItemProduced;
        public delegate void Product(Item item);

        float productionTime;
        float productionTimeElapsed = 0f;
        float productivity;
        Item.ItemType itemtype;
        bool enabled;

        public ProductionHandler(Item.ItemType itemType, float productionTime, float productivity)
        {
            this.itemtype = itemType;
            this.productionTime = productionTime;
            this.productivity = productivity;
            // TODO Implement productivity.


        }

        public void Start()
        {
            enabled = true;
        }

        public void Stop()
        {
            enabled = false;
        }

        internal void Update(float tick)
        {
            if (enabled)
            {
                productionTimeElapsed += tick;
                if (productionTimeElapsed >= productionTime)
                {
                    ItemProduced(new Item(Item.ItemType.Holz, 1));
                    productionTimeElapsed = 0f;
                }
            }
        }

    }
}