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
            for (var i = 0; i < Items.Count; i++)
            { 
                if (IsGeneric(Items[i]))
                {
                    if (Items[i].Quality > 0)
                    {
                        if (!IsSulfuras(Items[i]))
                        {
                            DecreaseQuality(Items[i]);
                        }
                    }
                }
                else
                {
                    if (IsQualityLessThan50(Items[i]))
                    {
                        IncreaseQuality(Items[i]);

                        if (IsBackstagePass(Items[i]))
                        {
                            if (Items[i].SellIn < 11)
                            {
                                if (IsQualityLessThan50(Items[i]))
                                {
                                    IncreaseQuality(Items[i]);
                                }
                            }

                            if (Items[i].SellIn < 6)
                            {
                                if (IsQualityLessThan50(Items[i]))
                                {
                                    IncreaseQuality(Items[i]);
                                }
                            }
                        }
                    }
                }

                if (!IsSulfuras(Items[i]))
                {
                    Items[i].SellIn = Items[i].SellIn - 1;
                }

                if (Items[i].SellIn < 0)
                {
                    if (!IsAgedBrie(Items[i]))
                    {
                        if (!IsBackstagePass(Items[i]))
                        {
                            if (Items[i].Quality > 0)
                            {
                                if (!IsSulfuras(Items[i]))
                                {
                                    DecreaseQuality(Items[i]);
                                }
                            }
                        }
                        else
                        {
                            Items[i].Quality = Items[i].Quality - Items[i].Quality;
                        }
                    }
                    else
                    {
                        if (IsQualityLessThan50(Items[i]))
                        {
                            IncreaseQuality(Items[i]);
                        }
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

        private bool IsQualityLessThan50(Item item)
        {
            return item.Quality < 50;
        }

        private void IncreaseQuality(Item item)
        {
            item.Quality = item.Quality + 1;
        }

        private void DecreaseQuality(Item item)
        {
            item.Quality = item.Quality - 1;
        }
    }
}
