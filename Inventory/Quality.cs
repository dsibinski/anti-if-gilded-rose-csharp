namespace csharp.Inventory
{
    public class Quality
    {
        public int Amount { get; private set; }
        public Quality(int amount)
        {
            Amount = amount;
        }

        public void Degrade()
        {
            if (Amount > 0)
            {
                Amount--;
            }
        }

        public void Increase()
        {
            if (Amount < 50)
            {
                Amount++;
            }
        }

        public void Reset()
        {
            Amount = 0;
        }

        public bool IsLessThan50()
        {
            return Amount < 50;
        }
    }
}