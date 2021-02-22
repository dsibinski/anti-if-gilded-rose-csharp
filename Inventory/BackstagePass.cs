using System;
using DiffEngine;

namespace csharp.Inventory
{
    public class BackstagePass: IGood
    {
        public static IGood Build(int sellIn)
        {

            switch (sellIn)
            {
                case var _ when sellIn < 0:
                    return new Expired();
                case var _ when sellIn < 5:
                    return new LessThan5Days();
                case var _ when sellIn < 10:
                    return new LessThan10Days();
                default:
                    return new BackstagePass();
            }
        }
        class Expired : IGood
        {
            public void Update(Quality quality)
            {
                quality.Reset();
            }
        }
        
        class LessThan5Days : IGood
        {
            public void Update(Quality quality)
            {
                quality.Increase();
                quality.Increase();
                quality.Increase();
            }
        }
        
        class LessThan10Days : IGood
        {
            public void Update(Quality quality)
            {
                quality.Increase();
                quality.Increase();
            }
        }
        public void Update(Quality quality)
        {
            quality.Increase();
        }
    }
}