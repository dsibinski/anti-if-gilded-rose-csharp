namespace csharp.Inventory
{
    public interface IGood
    {
        void Update(Quality quality, int sellIn);
    }
}