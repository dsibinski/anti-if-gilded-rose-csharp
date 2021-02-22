namespace csharp.Inventory
{
    public class AgedBrie: IGood
    {
        public static IGood Build(int sellIn)
        {
            if (sellIn < 0)
            {
                return new Expired();
            }
            else
            {
                return new AgedBrie();
            }
        }
        
        class Expired : IGood
        {
            public void Update(Quality quality, int _)
            {
                quality.Increase();
                quality.Increase();
            }
        }

        public void Update(Quality quality, int _)
        {
            quality.Increase();
        }
    }
}