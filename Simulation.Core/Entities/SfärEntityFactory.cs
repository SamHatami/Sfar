using Simulation.Core.Enums.Station;
using Simulation.Core.Components.Generic;
using Simulation.Core.Components.Station;
using Simulation.Core.Interfaces;
using Simulation.Core.Managers;
using SfärModule = Simulation.Core.Components.Station.SfärModule;

namespace Simulation.Core.Entities;

public class SfärEntityFactory: IEntityFactory
{
    
    //Base Sfär that creates just enough energy to uphold its current size, however, with a small net negative.

    public Entity Create()
    {
        var sfärEntity = EntityManager.CreateEntity();
        sfärEntity.AddComponent(new Components.Station.Sfär(){innerBound = 20, outerBound = 40});
        sfärEntity.AddComponent(new PowerConsumption());
        sfärEntity.AddComponent(new PowerGeneration(){Value = 20});
        sfärEntity.AddComponent(new Age(){Value = 0});
        sfärEntity.AddComponent(new SfärState());
        sfärEntity.AddComponent(new SfärShield());

        CreateBaseModules(sfärEntity);

        return sfärEntity;
    }

    private void CreateBaseModules(Entity sfärEntity)
    {
        //Base Scaffolding modules
        
    }
}