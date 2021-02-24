namespace csharp.Inventory
{
    public class Conjured: IGood
    {
        public static IGood Build(int sellIn)
        {
            if (sellIn < 0)
            {
                return new Expired();
            }
            else
            {
                return new Conjured();
            }
        }
        class Expired : IGood
        {
            public void Update(Quality quality)
            {
                quality.Degrade();
                quality.Degrade();
                quality.Degrade();
                quality.Degrade();
            }
        }
        public void Update(Quality quality)
        {
            quality.Degrade();
            quality.Degrade();
        }
    }
}