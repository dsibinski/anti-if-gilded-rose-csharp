namespace csharp.Inventory
{
    public interface IGood
    {
        int Quality { get; }
        int SellIn { get; }
        void Update();
    }
}