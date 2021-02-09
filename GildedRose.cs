using System.Collections.Generic;
using System.Security.Principal;

namespace csharp
{
    public class GildedRose
    {
        public interface IGood
        { 
            void Update();
        }
        public class Generic: IGood
        {
            public int Quality { get; private set; }
            public int SellIn { get; private set; }
            public Generic(int quality, int sellIn)
            {
                Quality = quality;
                SellIn = sellIn;
            }

            public void Update()
            {
                if (Quality > 0)
                {
                    Quality = Quality - 1;
                }

                SellIn = SellIn - 1;
                if (SellIn < 0)
                {
                    if (Quality > 0)
                    {
                        Quality = Quality - 1;
                    }
                }
            }
        }
        
        public class AgedBrie: IGood
        {
            public int Quality { get; private set; }
            public int SellIn { get; private set; }
            
            public AgedBrie(int quality, int sellIn)
            {
                Quality = quality;
                SellIn = sellIn;
            }

            public void Update()
            {
                if (Quality < 50)
                {
                    Quality = Quality + 1;
                }

                SellIn = SellIn - 1;
                if (SellIn < 0)
                {
                    if (Quality < 50)
                    {
                        Quality = Quality + 1;
                    }
                }
            }
        }
        
        public class BackstagePass: IGood
        {
            public int Quality { get; private set; }
            public int SellIn { get; private set; }
            
            public BackstagePass(int quality, int sellIn)
            {
                Quality = quality;
                SellIn = sellIn;
            }
            

            public void Update()
            {
                if (Quality < 50)
                {
                    Quality = Quality + 1;

                    if (SellIn < 11)
                    {
                        if (Quality < 50)
                        {
                            Quality = Quality + 1;
                        }
                    }

                    if (SellIn < 6)
                    {
                        if (Quality < 50)
                        {
                            Quality = Quality + 1;
                        }
                    }
                }

                SellIn = SellIn - 1;
                if (SellIn < 0)
                {
                    Quality = Quality - Quality;
                }
            }
        }

        public class Sulfuras : IGood
        {
            public int Quality { get; set; }
            public int SellIn { get; set; }
            public Sulfuras(int quality, int sellIn)
            {
                Quality = quality;
                SellIn = sellIn;
            }
            public void Update()
            {
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
                    var sulfuras = new Sulfuras(item.Quality, item.SellIn);
                    sulfuras.Update();
                    item.Quality = sulfuras.Quality;
                    item.SellIn = sulfuras.SellIn;
                }
                else if (IsGeneric(item))
                {
                    var generic = new Generic(item.Quality, item.SellIn);
                    generic.Update();
                    item.Quality = generic.Quality;
                    item.SellIn = generic.SellIn;
                }
                else if(IsAgedBrie(item))
                {
                    var agedBrie = new AgedBrie(item.Quality, item.SellIn);
                    agedBrie.Update();
                    item.Quality = agedBrie.Quality;
                    item.SellIn = agedBrie.SellIn;
                }
                else if(IsBackstagePass(item))
                {
                    var backstagePass = new BackstagePass(item.Quality, item.SellIn);
                    backstagePass.Update();
                    item.Quality = backstagePass.Quality;
                    item.SellIn = backstagePass.SellIn;
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
