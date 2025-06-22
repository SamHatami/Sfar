using Simulation.Core.Components;
using Simulation.Core.Interfaces;
using Simulation.Core.Managers;
using Simulation.Core.Utility.MathExtension;

namespace Simulation.Core.Systems;

public class SfärShieldSystem :ISystem
{
    private const int sfärId = 0;
    public void Update(int timeStep)
    {
        //Sfär intialstate component?
        //in the future
        //var sfärEntities = ComponentManager.GetEntityIdsFor<Sfär>();

        var sfärEntity = EntityManager.GetEntity(0);
        var sfär = sfärEntity.GetComponent<Sfär>();
        var shield = sfärEntity.GetComponent<SfärShield>();

        

        if (shield.ShieldSize == 0)
        {
            shield.Nodes = FibbonaciSpiral.GetNodes(200, sfär.outerBound);
        }
        
        //skip update if size havent changed
        shield.ShieldSize = (int)(4 * Math.PI * sfär.outerBound);
        shield.PowerConsumption = sfär.outerBound * sfär.outerBound / 100; //*Math.Sin()
        
        sfärEntity.SetComponent(shield);
        //Get shield componen
        //get Sfär outerbounds
        //get SfärCore current load
        //if the shield nodes array is empty, create nodes instantly --> only during first start

        //regenerate shield nodes if requierments for expansions are met, 
        //if the shield size has changed, regenerate nodes over several cycles
    }
}