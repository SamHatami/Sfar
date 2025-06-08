using Sfär.Core.Components;
using Sfär.Core.Entities;
using Sfär.Core.Managers;
using Sfär.Core.Orbits;

namespace Sfär.Core;

public class Universe
{
    public void Start()
    {
        var entity = EntityManager.CreateEntity();
        
        entity.AddComponent(new Name("NewPlanet"));
        entity.AddComponent(new OrbitalPath()
        {
            MajorAxis = 5000,
            MinorAxis = 3000,
            CurrentAngle = 0
        });
        entity.AddComponent(new OrbitalVelocity
        {
            Value = 0.000716f //radialVelcoty/ingameHour = one TimeStep...
        });

        var startPosition = OrbitalTrajectory.GetPosition(1800, 2000, 0.2f);
        
        entity.AddComponent(new Position(){Value = startPosition});

        var hours = OrbitalTrajectory.GetPeriod(0.000716f);

        var days = hours / 24;
        var months = days / 30;
        var cycles = months / 12; //ingame hours?
        var realSeconds = hours* (Time.tick/1000f);
        entity.AddComponent(new Period(hours));


    }
}