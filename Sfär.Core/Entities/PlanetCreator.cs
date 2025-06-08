using Sfär.Core.Components.CelestialBodies;
using Sfär.Core.Utility;

namespace Sfär.Core.Entities;

public class PlanetCreator
{
    private int giants;
    private int nrOfPlanets;


    //distribution of planet types simialar to solar, exception of made up types
    public PlanetCreator(int nrOfPlanets)
    {
        this.nrOfPlanets = nrOfPlanets;
    }

    public static PlanetData[] CreatePlanets()
    {
        var random = new Random();
        var planet = new PlanetData();

        //Create giant within probablity
        if (RandomUtils.Probability(PlanetSizes.GiantProbability))
            planet.Size = random.Next(PlanetSizes.GiantSizeMin, PlanetSizes.GiantSizeMax); //Randomize within
        
        return null;
    }
}