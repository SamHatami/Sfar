namespace Sfär.Core.Utility.Math;

public static class RandomUtils
{
    public static bool Probability(int percentage)
    {
        var rand = new Random();
        return rand.NextInt64(0, 100) > percentage;
    }
}