namespace csharp.Inventory
{
    public class Generic: IGood
    {
        public static IGood Build(int sellIn)
        {
            if (sellIn < 0)
            {
                return new Expired();
            }
            else
            {
                return new Generic();
            }
        }
        class Expired : IGood
        {
            public void Update(Quality quality, int _)
            {
                quality.Degrade();
                quality.Degrade();
            }
        }
        public void Update(Quality quality, int _)
        {
            quality.Degrade();
        }
    }
}