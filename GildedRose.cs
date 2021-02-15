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
                if (IsGeneric(item))
                {
                    return new Generic(item.Quality, item.SellIn);
                }
                else if(IsAgedBrie(item))
                {
                    return new AgedBrie(item.Quality, item.SellIn);
                }
                else if(IsBackstagePass(item))
                {
                    return new BackstagePass(item.Quality, item.SellIn);
                }

                throw new ArgumentException("Type not supported");
            }
            
            private bool IsGeneric(Item item)
            {
                return !(IsBackstagePass(item) || IsAgedBrie(item));
            }

            private bool IsBackstagePass(Item item)
            {
                return item.Name == "Backstage passes to a TAFKAL80ETC concert";
            }

            private bool IsAgedBrie(Item item)
            {
                return item.Name == "Aged Brie";
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
