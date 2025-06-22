using Simulation.Core.Components.Celestial;
using Simulation.Core.Components.Generic;
using Simulation.Core.Components.Station;
using Simulation.Core.Entities;
using Simulation.Core.Interfaces;
using Simulation.Core.Managers;

namespace Simulation.Core.Systems;

public class SfärPowerConsumptionSystem:ISystem
{
    private Entity? sfär;
    public void Update(int timeStep)
    {
        sfär ??= EntityManager.GetEntity(0);
        if (sfär is null) return;
        
        int currentPowerConsumption = 0;
        
        var shield = sfär.GetComponent<SfärShield>();
        currentPowerConsumption += shield.PowerConsumption;
        
        var sfärModulesIds = ComponentManager.GetEntityIdsFor<SfärModule>();
        for(int i=0; sfärModulesIds.Length > i; i++)
        {
            var sfärModule = EntityManager.GetEntity(sfärModulesIds[i]);
            if(sfärModule is null) continue;
            currentPowerConsumption += sfärModule.GetComponent<PowerConsumption>().Value;
        }
        
        var sfärPowerConsumption = sfär.GetComponent<PowerConsumption>();
        
        if(sfärPowerConsumption.Value == currentPowerConsumption)
            return;

        sfär.SetComponent(new PowerConsumption() { Value = currentPowerConsumption });

    }
}