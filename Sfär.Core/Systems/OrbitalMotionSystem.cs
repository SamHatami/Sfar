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
    private const float TWO_PI = MathF.PI * 2;
    public void Update(int timeStep)
    {
        var orbitalEntitiesIds = ComponentManager.GetEntityIdsFor<OrbitalPath>();
        var parentIds = ComponentManager.GetEntityIdsFor<Parent>();
        
        foreach(var id in orbitalEntitiesIds) 
        {
            var entity = EntityManager.GetEntity(id);
            
            if(!entity.TryGetComponent<OrbitalVelocity>(out var orbitalVelocityData)) 
                continue;
            
            if(!entity.TryGetComponent<OrbitalPath>(out var orbitData))
                continue;
            
            var orbitalVelocity = orbitalVelocityData.Value;
            if(orbitalVelocity == 0f) 
                continue; //nothing to update
            
            var direction = orbitalVelocityData.IsClockWise ? -1 : 1;
            orbitData.CurrentAngle = (orbitData.CurrentAngle + timeStep * orbitalVelocity*direction) % TWO_PI;
            
            var centroid = new Vector3();
            if (parentIds.Contains(id))
            {
                var parentId = entity.GetComponent<Parent>().ParentId;
                centroid = EntityManager.GetEntity(parentId).GetComponent<Position>().Value;
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
            entity.SetComponent(orbitData);
            entity.SetComponent(positionData);

#if  DEBUG
            Console.WriteLine($"Angle: {orbitData.CurrentAngle:F4} | Pos: {newPosition.X}|{newPosition.Y}|{newPosition.Z}");
#endif
            
        }
        

    }
}