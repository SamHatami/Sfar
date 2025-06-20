﻿using Simulation.Core.Enums.Station;
using Simulation.Core.Components.Generic;
using Simulation.Core.Components.Station;
using Simulation.Core.Managers;
using SfärModule = Simulation.Core.Components.Station.SfärModule;

namespace Simulation.Core.Entities;

public class SfärEntity
{
    
    //Base Sfär that creates just enough energy to uphold its current size, however, with a small net negative.

    public Entity Create()
    {
        var sfärEntity = EntityManager.CreateEntity();
        sfärEntity.AddComponent(new Components.Station.Sfär());
        sfärEntity.AddComponent(new SfärCore());
        sfärEntity.AddComponent(new SfärShield());
        sfärEntity.AddComponent(new Age(){Value = 0}); //real starting age is unknown.

        CreateBaseModules(sfärEntity);

        return sfärEntity;
    }

    private void CreateBaseModules(Entity sfärEntity)
    {
        //Base Scaffolding modules
        
    }
}