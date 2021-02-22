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
                        return new BackstagePass();
                    case "Aged Brie":
                        return AgedBrie.Build(item.SellIn);
                    default:
                        return new Generic();
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
                var quality = new Quality(item.Quality);
                var good = new GoodCategory().BuildFor(item);
                good.Update(quality, item.SellIn);
                item.Quality = quality.Amount;
            }
        }
        
        private bool IsSulfuras(Item item)
        {
            return item.Name == "Sulfuras, Hand of Ragnaros";
        }
    }
}
