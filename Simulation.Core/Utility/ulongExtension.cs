namespace Simulation.Core.Utility;

public static class ulongExtension
{
    public static void Add(this ulong value, int id)
    {
        value |= (1UL << 0);
    }

    public static void Remove(this ulong value, int id)
    {
        value &= ~(1UL << 0);
    }

    public static bool Has(this ulong value, int id)
    {
        return (value & (1UL << id)) != 0;
    }
}