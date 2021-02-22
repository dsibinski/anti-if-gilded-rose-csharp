namespace csharp.Inventory
{
    public class Generic: IGood
    {
        public void Update(Quality quality, int sellIn)
        {
            quality.Degrade();
            
            if (sellIn < 0)
            {
                quality.Degrade();
            }
        }
    }
}