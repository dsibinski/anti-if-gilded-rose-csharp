namespace csharp.Inventory
{
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
}