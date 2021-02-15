namespace csharp.Inventory
{
    public class Generic: IGood
    {
        public int Quality => _quality.Amount;
        public int SellIn { get; private set; }
        private Quality _quality { get; set; }
        public Generic(int quality, int sellIn)
        {
            _quality = new Quality(quality);
            SellIn = sellIn;
        }

        public void Update()
        {
            _quality.Degrade();

            SellIn = SellIn - 1;
            if (SellIn < 0)
            {
                _quality.Degrade();
            }
        }
    }
}