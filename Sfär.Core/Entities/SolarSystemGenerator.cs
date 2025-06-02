using Sfär.Core.Components;
using Sfär.Core.Components.CelestialBodies;

namespace Sfär.Core.Entities;

public static class SolarSystemGenerator
{
    public static IEntity[] Create(int seed = 0)
    {
        List<IEntity> entities = new List<IEntity>();
        var random = new Random();
        
        //Create the sun
        var sunEntity = EntityCreator.Create();
        sunEntity.Label = "Sun"; // Perhaps a name generator?

        sunEntity.AddComponent(new StarData()
        {
            Age = 2,
            Luminosity = 1f,
            SpectralClass = "G",
            Mass = 1,
            Size = 1

        });
        entities.Add(sunEntity);
        
        
        int nrOfPlanets = random.Next(8, 12);
        
        //Create sizes and distances
        for (int i = 0; i < nrOfPlanets; i++)
        {
            var planetEntity = EntityCreator.Create();
            planetEntity.Label = "Planet " + i.ToString();
            
            planetEntity.AddComponent(new PlanetData()
            {
                Mass = 2, //Randomize within
                Size = 2, //Randomize within
            });
        }
        //Create orbits
        
        //Create moons and add to planets
        
        //Create asteroidfield
        
        //
        
        for (int i = 0; i < nrOfPlanets; i++)
            
        {
            var entity = EntityCreator.Create();

            entities.Add(entity);
            
        }
        return entities.ToArray();
    }
}