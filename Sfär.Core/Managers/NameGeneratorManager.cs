using Sfär.Core.Enums;
using Sfär.Core.Interfaces;

namespace Sfär.Core.Managers;

public static class NameGeneratorManager
{
    private static Dictionary<CelestialObjectType, INameGenerator> _nameGenerators = new();

    public static void Read()
    {
        
        //read generators
    }
}