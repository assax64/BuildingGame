namespace BuildingGame
{
    class Item
    {
        ItemType type;
        int amount;

        public enum ItemType
        {
            Holz,
            Stein,
            Werkzeug
        };

        public Item(ItemType type, int amount)
        {
            this.type = type;
            this.amount = amount;
        }

        public string GetName()
        {
            if (Type == ItemType.Holz)
                return "Holz";
            if (Type == ItemType.Stein)
                return "Stein";
            return "NaN";
        }

        public ItemType Type
        {
            get
            {
                return type;
            }
            set
            {
                type = value;
            }
        }
        public int Amount
        {
            get
            {
                return amount;
            }
            set
            {
                amount = value;
            }
        }
    }
}