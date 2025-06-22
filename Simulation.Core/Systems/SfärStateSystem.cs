using Simulation.Core.Components;
using Simulation.Core.Interfaces;
using Simulation.Core.Managers;

namespace Simulation.Core.Systems;

public class SfärStateSystem: ISystem
{
    private const float specificHeat = 1000f;
    private const float gasDensity = 1.225f;
    public void Update(int timeStep)
    {
        var sfärId = ComponentManager.GetEntityIdsFor<Sfär>();
        var sfärEntity = EntityManager.GetEntity(sfärId[0]);

        var sfär = sfärEntity.GetComponent<Sfär>();
        var sfärMass = sfärEntity.GetComponent<Mass>();
        var sfärInternalState = sfärEntity.GetComponent<SfärState>();
        var powerGeneration = sfärEntity.GetComponent<PowerGeneration>();
        var powerConsumption = sfärEntity.GetComponent<PowerConsumption>();
        
        var surplus = powerGeneration.Value - powerConsumption.Value;
        
        //GasVolume should be the empty void where modules do not exists ,
        //but for now its just the void between inner outter bound
        var Ri = sfär.innerBound;
        var Ro = sfär.outerBound;
        var gasVolume = (4f/3f)*Math.PI*(Math.Pow(Ri, 3) - Math.Pow(Ro, 3));
        var thermalMass = gasVolume * gasDensity * specificHeat;
        var dT = (surplus * timeStep) / thermalMass;
        var t1 = sfärInternalState.InternalTemperature;
        var t2 = t1 + dT;
        
        sfärInternalState.InternalTemperature += (float)dT;
        sfärInternalState.InternalPressure *= (float)t2/t1 ;

    }
}