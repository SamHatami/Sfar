using Sfär.Core.Components;
using Sfär.Core.Entities;
using Sfär.Core.Interfaces;
using Sfär.Core.Managers;
using Sfär.Core.Registers;

namespace Sfär.Core.Systems;

public class MiningSystem : ISystem
{
    public void Update(int timeStep)
    {
        for (int i = 0; i < GlobalSettings.MaxEntities; i++)
        {
            var entity = EntityManager.Entities[i];
            
            ComponentRegistry.GetId<MaterialComposition>();
            if(!entity.HasComponent<MaterialComposition>()) return;
        
            MaterialComposition? materials = entity.GetComponent<MaterialComposition>();
        }

    }
}