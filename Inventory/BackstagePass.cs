namespace csharp.Inventory
{
    public class BackstagePass: IGood
    {
        public int Quality => _quality.Amount;
        public int SellIn { get; private set; }
        private Quality _quality { get; set; }
            
        public BackstagePass(int quality, int sellIn)
        {
            _quality = new Quality(quality);
            SellIn = sellIn;
        }
            

        public void Update()
        {
            _quality.Increase();
            
            if (SellIn < 11)
            {
                _quality.Increase();
            }

            if (SellIn < 6)
            {
                _quality.Increase();
            }

                SellIn = SellIn - 1;
            if (SellIn < 0)
            {
                _quality.Reset();
            }
        }
    }
}