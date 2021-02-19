using System;
using System.Collections.Generic;
using System.Security.Principal;
using csharp.Inventory;

namespace csharp
{
    public class GildedRose
    {
        public class GoodCategory
        {
            public IGood BuildFor(Item item)
            {
                switch (item.Name)
                {
                    case "Backstage passes to a TAFKAL80ETC concert":
                        return new BackstagePass(item.Quality, item.SellIn);
                    case "Aged Brie":
                        return new AgedBrie(item.Quality, item.SellIn);
                    default:
                        return new Generic(item.Quality, item.SellIn);
                }
            }
        }
        
        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                if (IsSulfuras(item))
                {
                    continue;
                }
                
                var good = new GoodCategory().BuildFor(item);
                good.Update();
                item.Quality = good.Quality;
                item.SellIn = good.SellIn;
            }
        }
        
        private bool IsSulfuras(Item item)
        {
            return item.Name == "Sulfuras, Hand of Ragnaros";
        }
    }
}
