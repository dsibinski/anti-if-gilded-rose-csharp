namespace csharp.Inventory
{
    public class Generic: IGood
    {
        public int Quality { get; private set; }
        public int SellIn { get; private set; }
        public Generic(int quality, int sellIn)
        {
            Quality = quality;
            SellIn = sellIn;
        }

        public void Update()
        {
            if (Quality > 0)
            {
                Quality = Quality - 1;
            }

            SellIn = SellIn - 1;
            if (SellIn < 0)
            {
                if (Quality > 0)
                {
                    Quality = Quality - 1;
                }
            }
        }
    }
}