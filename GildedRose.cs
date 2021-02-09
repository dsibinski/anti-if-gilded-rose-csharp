using System.Collections.Generic;

namespace csharp
{
    public class GildedRose
    {
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
                    
                }
                else if (IsGeneric(item))
                {
                    if (item.Quality > 0)
                    {
                        item.Quality = item.Quality - 1;
                    }

                    item.SellIn = item.SellIn - 1;
                    if (item.SellIn < 0)
                    {
                        if (item.Quality > 0)
                        {
                            item.Quality = item.Quality - 1;
                        }
                    }
                }
                else if(IsAgedBrie(item))
                {
                    if (item.Quality < 50)
                    {
                        item.Quality = item.Quality + 1;
                    }

                    item.SellIn = item.SellIn - 1;
                    if (item.SellIn < 0)
                    {
                        if (item.Quality < 50)
                        {
                            item.Quality = item.Quality + 1;
                        }
                    }
                }
                else if(IsBackstagePass(item))
                {
                    if (item.Quality < 50)
                    {
                        item.Quality = item.Quality + 1;

                        if (item.SellIn < 11)
                        {
                            if (item.Quality < 50)
                            {
                                item.Quality = item.Quality + 1;
                            }
                        }

                        if (item.SellIn < 6)
                        {
                            if (item.Quality < 50)
                            {
                                item.Quality = item.Quality + 1;
                            }
                        }
                    }

                    item.SellIn = item.SellIn - 1;
                    if (item.SellIn < 0)
                    {
                        item.Quality = item.Quality - item.Quality;
                    }
                }
            }
        }

        private bool IsGeneric(Item item)
        {
            return !(IsSulfuras(item) || IsBackstagePass(item) || IsAgedBrie(item));
        }

        private bool IsSulfuras(Item item)
        {
            return item.Name == "Sulfuras, Hand of Ragnaros";
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
}
