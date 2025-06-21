namespace Simulation.Core.Utility.MathExtension;

public static class RandomUtils
{
    public static bool Probability(int percentage)
    {
        var rand = new Random();
        return rand.NextInt64(0, 100) > percentage;
    }
}