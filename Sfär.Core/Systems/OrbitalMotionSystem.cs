using ScottPlot;
using Sfär.Core.Components;
using Sfär.Core.Components.Celestial;
using Sfär.Core.Components.Generic;
using Sfär.Core.Entities;
using Sfär.Core.Interfaces;
using Sfär.Core.Managers;
using Sfär.Core.Utility;
using Sfär.Core.Utility.MathExtension;
using Sfär.Core.Utility.Orbits;

namespace Sfär.Core.Systems;

public class OrbitalMotionSystem:ISystem
{
    public void Update(int timeStep) 
    {
        var orbitalEntitiesIds =ComponentManager.GetEntityIdsFor<OrbitalPath>();
        var positionEntities = ComponentManager.GetEntityIdsFor<Position>();
        var velocityEntities = ComponentManager.GetEntityIdsFor<OrbitalVelocity>();
        var parentIds = ComponentManager.GetEntityIdsFor<Parent>();
        
        foreach(var id in orbitalEntitiesIds) 
        {
            if(!positionEntities.Contains(id)) continue; //no initial position data.
            if(!velocityEntities.Contains(id)) continue; //no movement 

            var entity = EntityManager.Entities[id];
            var orbitalVelocityData = entity.GetComponent<OrbitalVelocity>();
            var orbitalVelocity = orbitalVelocityData.Value;
            var direction = orbitalVelocityData.IsClockWise ? -1 : 1;
            if(orbitalVelocity == 0f) continue; //nothing to update
            
            var orbitData = entity.GetComponent<OrbitalPath>();
            orbitData.CurrentAngle = (orbitData.CurrentAngle + timeStep * orbitalVelocity*direction) % (2 * MathF.PI);
            entity.SetComponent(orbitData);
            
            var centroid = new Vector3();
            if (parentIds.Contains(id))
            {
                var parentId = entity.GetComponent<Parent>().ParentId;
                centroid = EntityManager.Entities[parentId].GetComponent<Position>().Value;
            }
            
            var newPosition = OrbitalTrajectory.GetPosition(
                orbitData.MinorAxis, 
                orbitData.MajorAxis, 
                orbitData.CurrentAngle,
                orbitData.TiltX, orbitData.TiltY, orbitData.TiltZ, 
                orbitData.InPlanarRotation,
                centroid);
            
            var positionData = entity.GetComponent<Position>();
            positionData.Value = newPosition;
            entity.SetComponent(positionData);

#if  DEBUG
            Console.WriteLine($"Angle: {orbitData.CurrentAngle:F4} | Pos: {newPosition.X}|{newPosition.Y}|{newPosition.Z}");
#endif
            
        }
        

    }
}