using ScottPlot;
using Simulation.Core.Components;
using Simulation.Core.Entities;
using Simulation.Core.Utility;
using Simulation.Core.Interfaces;
using Simulation.Core.Managers;
using Simulation.Core.Utility.MathExtension;
using Simulation.Core.Utility.Orbits;

namespace Simulation.Core.Systems;

public class OrbitalMotionSystem:ISystem
{
    private const float TWO_PI = MathF.PI * 2;
    public void Update(int timeStep)
    {
        var orbitalEntitiesIds = ComponentManager.GetEntityIdsFor<OrbitalPath>();
        var parentIds = ComponentManager.GetEntityIdsFor<Parent>();

        for (var i = 0; i < orbitalEntitiesIds.Length; i++)
        {
            var id = orbitalEntitiesIds[i];
            var entity = EntityManager.GetEntity(id);

            if (!entity.TryGetComponent<OrbitalVelocity>(out var orbitalVelocityData))
                continue;

            if (!entity.TryGetComponent<OrbitalPath>(out var orbitData))
                continue;

            var orbitalVelocity = orbitalVelocityData.Value;
            if (orbitalVelocity == 0f)
                continue; //nothing to update

            var direction = orbitalVelocityData.IsClockWise ? -1 : 1;
            orbitData.CurrentAngle = (orbitData.CurrentAngle + timeStep * orbitalVelocity * direction) % TWO_PI;

            var centroid = new Vector3();
            if (parentIds.Contains(id) && entity.TryGetComponent<Parent>(out var parent))
            {
                var parentId = parent.ParentId;
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

// #if DEBUG
//             Console.WriteLine(
//                 $"Angle: {orbitData.CurrentAngle:F4} | Pos: {newPosition.X}|{newPosition.Y}|{newPosition.Z}");
// #endif
        }
    }
}