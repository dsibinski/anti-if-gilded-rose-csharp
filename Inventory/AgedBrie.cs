namespace csharp.Inventory
{
    public class AgedBrie: IGood
    {
        public int Quality => _quality.Amount;

        private Quality _quality { get; set; }
            
        public AgedBrie(int quality)
        {
            _quality = new Quality(quality);
        }

        public void Update(int sellIn)
        {
            _quality.Increase();
            
            if (sellIn < 0)
            {
                _quality.Increase();
            }
        }
    }
}