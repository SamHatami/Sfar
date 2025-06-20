using Sfär.Core.Components.Generic;
using Sfär.Core.Components.Station;
using Sfär.Core.Enums.Station;
using Sfär.Core.Managers;
using SfärModule = Sfär.Core.Components.Station.SfärModule;

namespace Sfär.Core.Entities;

public class SfärEntity
{
    
    //Base Sfär that creates just enough energy to uphold its current size, however, with a small net negative.

    public Entity Create()
    {
        var sfärEntity = EntityManager.CreateEntity();
        sfärEntity.AddComponent(new Components.Station.Sfär());
        sfärEntity.AddComponent(new FusionCore());
        sfärEntity.AddComponent(new Shield());
        sfärEntity.AddComponent(new Age(){Value = 0}); //real starting age is unknown.

        CreateBaseModules(sfärEntity);

        return sfärEntity;
    }

    private void CreateBaseModules(Entity sfärEntity)
    {
        //Base Scaffolding modules
        
    }
}