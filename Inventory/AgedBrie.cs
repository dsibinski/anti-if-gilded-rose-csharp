namespace csharp.Inventory
{
    public class AgedBrie: IGood
    {
        public static IGood Build(int quality, int sellIn)
        {
            if (sellIn < 0)
            {
                return new Expired(quality);
            }
            else
            {
                return new AgedBrie(quality);
            }
        }
        
        class Expired : IGood
        {
            public int Quality => _quality.Amount;
            private Quality _quality { get; set; }
            public Expired(int quality)
            {
                _quality = new Quality(quality);
            }
            public void Update(int _)
            {
                _quality.Increase();
                _quality.Increase();
            }
        }
        
        public int Quality => _quality.Amount;

        private Quality _quality { get; set; }
            
        public AgedBrie(int quality)
        {
            _quality = new Quality(quality);
        }

        public void Update(int _)
        {
            _quality.Increase();
        }
    }
}