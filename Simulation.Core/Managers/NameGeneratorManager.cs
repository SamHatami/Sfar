using Simulation.Core.Enums;
using Simulation.Core.Interfaces;

namespace Simulation.Core.Managers;

public static class NameGeneratorManager
{
    private static Dictionary<CelestialObjectType, INameGenerator> _nameGenerators = new();

    public static void Read()
    {
        
        //read generators
    }
}