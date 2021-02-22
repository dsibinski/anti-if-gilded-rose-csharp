namespace csharp.Inventory
{
    public interface IGood
    {
        int Quality { get; }
        void Update(int sellIn);
    }
}