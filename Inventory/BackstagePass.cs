using DiffEngine;

namespace csharp.Inventory
{
    public class BackstagePass: IGood
    {
        public static IGood Build(int sellIn)
        {
            if (sellIn < 0)
            {
                return new Expired();
            }
            else
            {
                return new BackstagePass();
            }
        }
        class Expired : IGood
        {
            public void Update(Quality quality, int _)
            {
                quality.Reset();
            }
        }
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
        }
    }
}