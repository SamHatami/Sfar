using Simulation.Core.Components;
using Simulation.Core.Entities;
using Simulation.Core.Interfaces;
using Simulation.Core.Managers;

namespace Simulation.Core.Systems;

public class MiningSystem : ISystem
{
    public void Update(int timeStep)
    {
        for (int i = 0; i < GlobalSettings.MaxEntities; i++)
        {
            var entity = EntityManager.GetEntity(i);
            
            ComponentManager.GetId<MaterialComposition>();
            MaterialComposition materials;
            if(!entity.TryGetComponent<MaterialComposition>(out materials)) return;
        
        }

    }
}