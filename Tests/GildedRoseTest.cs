﻿using NUnit.Framework;
using System.Collections.Generic;

namespace csharp
{
    [TestFixture]
    public class GildedRoseTest
    {
        [Test]
        public void foo()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual("foo", Items[0].Name);
        }

        [Test]
        public void TestBackstagePass()
        {
            AssertBackstagePassQuality(22, 8, 20);
            AssertBackstagePassQuality(23, 4, 20);
            AssertBackstagePassQuality(0, 0, 0);
            AssertBackstagePassQuality(3, 1, 0);
            AssertBackstagePassQuality(1, 11, 0);
            AssertBackstagePassQuality(2, 6, 0);
        }

        [Test]
        public void TestAgedBrie()
        {
            AssertAgedBrieQuality(22, 0, 20);
            AssertAgedBrieQuality(21, 1, 20);
        }

        [Test]
        public void TestCustomProduct()
        {
            AssertCustomProductQuality(1, -1, 3);
            AssertCustomProductQuality(1, 0, 3);
            AssertCustomProductQuality(2, 1, 3);
            AssertCustomProductQuality(0, 1, 0);
            AssertCustomProductQuality(0, 1, 1);
        }
        
        [Test]
        public void TestConjuredProduct()
        {
            AssertConjuredProductQuality(4, 3, 6);
            AssertConjuredProductQuality(2, 0, 6);
            AssertConjuredProductQuality(4, 1, 6);
        }

        private void AssertBackstagePassQuality(int expected, int sellIn, int quality)
        {
            IList<Item> Items = new List<Item> { new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert", 
                SellIn = sellIn, 
                Quality = quality
            } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(expected, Items[0].Quality);
        }
        
        private void AssertAgedBrieQuality(int expected, int sellIn, int quality)
        {
            IList<Item> Items = new List<Item> { new Item
            {
                Name = "Aged Brie", 
                SellIn = sellIn, 
                Quality = quality
            } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(expected, Items[0].Quality);
        }
        
        private void AssertCustomProductQuality(int expected, int sellIn, int quality)
        {
            IList<Item> Items = new List<Item> { new Item
            {
                Name = "Custom Product", 
                SellIn = sellIn, 
                Quality = quality
            } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(expected, Items[0].Quality);
        }
        
        private void AssertConjuredProductQuality(int expected, int sellIn, int quality)
        {
            IList<Item> Items = new List<Item> { new Item
            {
                Name = "Conjured Mana Cake", 
                SellIn = sellIn, 
                Quality = quality
            } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(expected, Items[0].Quality);
        }
    }
}
