using Simulation.Core.Components;
using Simulation.Core.Entities;
using Simulation.Core.Enums.Station;
using Simulation.Core.Interfaces;
using Simulation.Core.Managers;

namespace Simulation.Core.Systems;

public class SfärGrowthSystem : ISystem
{
    private int _initialOuterBound = -1;
    private const int MaxTemperature = 121;
    private const int MaxPressure = 16;
    private const int GrowthAmount = 40;
    private const int RestCycles = 50;
    
    public void Update(int timeStep)
    {
        var sfärEntity = EntityManager.GetEntity(0); // Sfär is always ID 0
        
        var sfär = sfärEntity.GetComponent<Sfär>();
        var state = sfärEntity.GetComponent<SfärState>();
        var growth = sfärEntity.GetComponent<SfärGrowth>();
        
        if (_initialOuterBound < 0)
            _initialOuterBound = sfär.outerBound;
        
        var newOuterBound = sfär.outerBound;
        var newGrowth = growth;
        
        switch (growth.GrowthState)
        {
            case GrowthState.Resting:
                if (newGrowth.RestCyclesRemaining > 0)
                {
                    newGrowth.RestCyclesRemaining -= timeStep;
                }
                else if (state.InternalTemperature > MaxTemperature && state.InternalPressure > MaxPressure)
                {
                    newGrowth.GrowthState = GrowthState.Growing;
                }
                break;
                
            case GrowthState.Growing:
                newGrowth.GrowthProgress += timeStep * 0.5f; // Adjust this rate as needed
                if (newGrowth.GrowthProgress >= 1.0f) 
                {
                    newOuterBound += 1;
                    newGrowth.GrowthProgress = 0;
                }
                if (newOuterBound >= _initialOuterBound + GrowthAmount)
                    newGrowth.GrowthState = GrowthState.Shrinking;
                break;
    
            case GrowthState.Shrinking:
                newGrowth.GrowthProgress += timeStep * 0.2f; // Same rate or different
                if (newGrowth.GrowthProgress >= 1.0f) 
                {
                    newOuterBound -= 1;
                    newGrowth.GrowthProgress = 0;
                }
                if (newOuterBound <= _initialOuterBound)
                {
                    newOuterBound = _initialOuterBound;
                    newGrowth.GrowthState = GrowthState.Resting;
                    newGrowth.RestCyclesRemaining = RestCycles;
                    newGrowth.GrowthProgress = 0; // Reset for next cycle
                }
                break;
        }
        
        sfärEntity.SetComponent(new Sfär { innerBound = sfär.innerBound, outerBound = newOuterBound });
        sfärEntity.SetComponent(newGrowth);
    }
}
