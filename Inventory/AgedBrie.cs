namespace csharp.Inventory
{
    public class AgedBrie: IGood
    {
        public int Quality => _quality.Amount;
        public int SellIn { get; private set; }
        
        private Quality _quality { get; set; }
            
        public AgedBrie(int quality, int sellIn)
        {
            _quality = new Quality(quality);
            SellIn = sellIn;
        }

        public void Update()
        {
            _quality.Increase();

            SellIn = SellIn - 1;
            if (SellIn < 0)
            {
                _quality.Increase();
            }
        }
    }
}