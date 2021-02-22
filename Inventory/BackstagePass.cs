namespace csharp.Inventory
{
    public class BackstagePass: IGood
    {
        public int Quality => _quality.Amount;
        private Quality _quality { get; set; }
            
        public BackstagePass(int quality)
        {
            _quality = new Quality(quality);
        }
            

        public void Update(int sellIn)
        {
            _quality.Increase();
            
            if (sellIn < 10)
            {
                _quality.Increase();
            }

            if (sellIn < 5)
            {
                _quality.Increase();
            }
            
            if (sellIn < 0)
            {
                _quality.Reset();
            }
        }
    }
}