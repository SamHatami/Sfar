using Sfär.Core.Components;
using Sfär.Core.Components.Celestial;
using Sfär.Core.Entities;
using Sfär.Core.Interfaces;
using Sfär.Core.Managers;

namespace Sfär.Core.Systems;

public class MiningSystem : ISystem
{
    public void Update(int timeStep)
    {
        for (int i = 0; i < GlobalSettings.MaxEntities; i++)
        {
            var entity = EntityManager.Entities[i];
            
            ComponentManager.GetId<MaterialComposition>();
            if(!entity.HasComponent<MaterialComposition>()) return;
        
            MaterialComposition? materials = entity.GetComponent<MaterialComposition>();
        }

    }
}