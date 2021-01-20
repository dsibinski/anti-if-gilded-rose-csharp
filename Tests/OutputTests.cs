using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace csharp
{
    [TestFixture]
    public class OutputTests
    {
        [Test]
        public void ShouldProduceExpectedOutputFor2Days()
        {
            IList<Item> Items = new List<Item>{
                new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
                new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80},
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 15,
                    Quality = 20
                },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 10,
                    Quality = 49
                },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 5,
                    Quality = 49
                },
                // this conjured item does not work properly yet
                new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
            };

            var app = new GildedRose(Items);

            var outputSb = new StringBuilder();
            var days = 2;

            for (var i = 0; i < days; i++)
            {
                outputSb.AppendLine("-------- day " + i + " --------");
                outputSb.AppendLine("name, sellIn, quality");
                for (var j = 0; j < Items.Count; j++)
                {
                    outputSb.AppendLine(Items[j].ToString());
                }
                outputSb.AppendLine("");
                app.UpdateQuality();
            }

            var reportLines = outputSb.ToString();

            Assert.AreEqual(
                "-------- day 0 --------\r\nname, sellIn, quality\r\n+5 Dexterity Vest, 10, 20\r\nAged Brie, 2, 0\r\nElixir of the Mongoose, 5, 7\r\nSulfuras, Hand of Ragnaros, 0, 80\r\nSulfuras, Hand of Ragnaros, -1, 80\r\nBackstage passes to a TAFKAL80ETC concert, 15, 20\r\nBackstage passes to a TAFKAL80ETC concert, 10, 49\r\nBackstage passes to a TAFKAL80ETC concert, 5, 49\r\nConjured Mana Cake, 3, 6\r\n\r\n-------- day 1 --------\r\nname, sellIn, quality\r\n+5 Dexterity Vest, 9, 19\r\nAged Brie, 1, 1\r\nElixir of the Mongoose, 4, 6\r\nSulfuras, Hand of Ragnaros, 0, 80\r\nSulfuras, Hand of Ragnaros, -1, 80\r\nBackstage passes to a TAFKAL80ETC concert, 14, 21\r\nBackstage passes to a TAFKAL80ETC concert, 9, 50\r\nBackstage passes to a TAFKAL80ETC concert, 4, 50\r\nConjured Mana Cake, 2, 5\r\n\r\n", reportLines);
        }
    }
}