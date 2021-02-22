namespace csharp.Inventory
{
    public class Generic: IGood
    {
        public int Quality => _quality.Amount;
        private Quality _quality { get; set; }
        public Generic(int quality)
        {
            _quality = new Quality(quality);
        }

        public void Update(int sellIn)
        {
            _quality.Degrade();
            
            if (sellIn < 0)
            {
                _quality.Degrade();
            }
        }
    }
}