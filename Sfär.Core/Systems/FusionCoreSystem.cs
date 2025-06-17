using Sfär.Core.Components.Celestial;
using Sfär.Core.Components.Station;
using Sfär.Core.Entities;
using Sfär.Core.Interfaces;
using Sfär.Core.Managers;

namespace Sfär.Core.Systems;

public class FusionCoreSystem:ISystem
{
    private Entity? sfär;
    public void Update(int timeStep)
    {
        sfär ??= EntityManager.Entities[0];

        if (sfär is null) return;
        
        var fusionCore = sfär.GetComponent<FusionCore>();
        
        
    }
}