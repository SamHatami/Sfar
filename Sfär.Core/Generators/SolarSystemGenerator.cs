using Sfär.Core.Entities;
using Sfär.Core.Managers;

namespace Sfär.Core.Generators;

public static class SolarSystemGenerator
{
    public static Entity[] Create(int seed = 0)
    {
        List<Entity> entities = new();
        var random = new Random();

        //Create the sun
        var sunEntity = EntityManager.CreateEntity();
        // sunEntity.Label = "Sun"; // Perhaps a name generator?

        // Add Components
        entities.Add(sunEntity);

        var nrOfPlanets = random.Next(8, 12);

        //Create sizes and distances
        for (var i = 0; i < nrOfPlanets; i++)
        {
            var planetEntity = EntityManager.CreateEntity();


        }
        //Create orbits

        //Create moons and add to planets

        //Create asteroidfield

        //

        for (var i = 0; i < nrOfPlanets; i++)

        {
            var entity = EntityManager.CreateEntity();

            entities.Add(entity);
        }

        return entities.ToArray();
    }
}