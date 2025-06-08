namespace Sfär.Core;

public static class GlobalSettings
{
    public const int MaxEntities = 100000;
    public const int MaxComponents = 64;
    public const int UniverseSize = 100000000;
}

public static class PlanetSizes
{
    public const int GiantSizeMin = 100;
    public const int GiantSizeMax = 150;
    public const int MoonSizeMin = 1;
    public const int MoonSizeMax = 9;
    public const int ExoSizeMin = 10;
    public const int ExoSizeMax = 55;
    public const int MidSizeMin = 60;
    public const int MidSizeMax = 90;
    public const int GiantProbability = 10; //%
    public const int ExoProbability = 40; //%
    public const int MidProbability = 20; //%
    public const int MoonProbability = 35; //%
}