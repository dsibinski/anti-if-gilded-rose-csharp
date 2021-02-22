namespace csharp.Inventory
{
    public class BackstagePass: IGood
    {
        public void Update(Quality quality, int sellIn)
        {
            quality.Increase();
            
            if (sellIn < 10)
            {
                quality.Increase();
            }

            if (sellIn < 5)
            {
                quality.Increase();
            }
            
            if (sellIn < 0)
            {
                quality.Reset();
            }
        }
    }
}