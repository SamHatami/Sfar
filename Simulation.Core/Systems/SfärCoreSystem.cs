using Simulation.Core.Components.Celestial;
using Simulation.Core.Components.Station;
using Simulation.Core.Entities;
using Simulation.Core.Interfaces;
using Simulation.Core.Managers;

namespace Simulation.Core.Systems;

public class SfärCoreSystem:ISystem
{
    private Entity? sfär;
    public void Update(int timeStep)
    {
        sfär ??= EntityManager.GetEntity(0);

        if (sfär is null) return;
        
        var fusionCore = sfär.GetComponent<SfärCore>();
        //get all modules
        var shield = sfär.GetComponent<SfärShield>();

        fusionCore.PowerConsumption = shield.PowerConsumption;


    }
}