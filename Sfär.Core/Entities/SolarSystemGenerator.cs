using Sfär.Core.Entities;

namespace Sfär.Core.Cluster;

public static class SolarSystemGenerator
{
    public static Entity[] Create(int seed = 0)
    {
        List<Entity> entities = new List<Entity>();
        var random = new Random();

        int nrOfPlanets = random.Next(8, 12);
        
        return entities.ToArray();
    }
}