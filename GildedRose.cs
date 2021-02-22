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
                        return new BackstagePass(item.Quality);
                    case "Aged Brie":
                        return AgedBrie.Build(item.Quality, item.SellIn);
                    default:
                        return new Generic(item.Quality);
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
                
                item.SellIn -= 1;
                var good = new GoodCategory().BuildFor(item);
                good.Update(item.SellIn);
                item.Quality = good.Quality;
            }
        }
        
        private bool IsSulfuras(Item item)
        {
            return item.Name == "Sulfuras, Hand of Ragnaros";
        }
    }
}
