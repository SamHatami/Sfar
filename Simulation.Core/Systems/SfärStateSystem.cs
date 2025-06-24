using System.Reflection.Metadata.Ecma335;
using Simulation.Core.Components;
using Simulation.Core.Enums.Station;
using Simulation.Core.Interfaces;
using Simulation.Core.Managers;

namespace Simulation.Core.Systems;

public class SfärStateSystem: ISystem
{
    private const float specificHeat = 0.025f;
    private const float gasDensity = 0.05f;
    private const double C1 = 4d/3d*Math.PI;  
    public void Update(int timeStep)
    {
        var sfärId = ComponentManager.GetEntityIdsFor<Sfär>();
        var sfärEntity = EntityManager.GetEntity(sfärId[0]);

        if(!sfärEntity.TryGetComponent<Sfär>(out var sfär)) return;
        if(!sfärEntity.TryGetComponent<SfärState>(out var sfärInternalState)) return;
        if(!sfärEntity.TryGetComponent<PowerGeneration>(out var powerGeneration)) return;
        if(!sfärEntity.TryGetComponent<PowerConsumption>(out var powerConsumption)) return;
        if(!sfärEntity.TryGetComponent<SfärGrowth>(out var sfärGrowth)) return;
        
        
        var surplus = powerGeneration.Value - powerConsumption.Value;
        
        //GasVolume should be the empty void where modules do not exists ,
        //but for now its just the void between inner outter bound
        var Ri = sfär.innerBound;
        var Ro = sfär.outerBound;
        var gasVolume = C1*(Math.Pow(Ro, 3) - Math.Pow(Ri, 3));
        var thermalMass = gasVolume * gasDensity * specificHeat;
        var dT = (float)(surplus * timeStep / thermalMass);
        var t1 = sfärInternalState.InternalTemperature;
        
        //cool off when resting
        if(sfärGrowth.GrowthState == GrowthState.Resting && sfärGrowth.RestCyclesRemaining > 0)
             dT = -dT;
        
        var t2 = t1 + dT;

        float newTemp = sfärInternalState.InternalTemperature + dT;
        float newPressure = sfärInternalState.InternalPressure * (float)Math.Pow(t2 / t1, 2);
        
        sfärEntity.SetComponent(new SfärState(){InternalTemperature = newTemp, InternalPressure = (float)newPressure});
        Console.WriteLine(sfärInternalState.InternalTemperature);
        Console.WriteLine(sfärInternalState.InternalPressure);
        
        

    }
}