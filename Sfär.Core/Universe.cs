using Sfär.Core.Components;
using Sfär.Core.Entities;
using Sfär.Core.Managers;
using Sfär.Core.Utility.Math;
using Sfär.Core.Utility.Orbits;

namespace Sfär.Core;

public class Universe
{
    public void Start()
    {
        // Create the central Sun - stationary at origin
        var sun = EntityManager.CreateEntity();
        sun.AddComponent(new Position() { Value = new Vector3(GlobalSettings.UniverseSize/2, GlobalSettings.UniverseSize/2, 0) });
        sun.AddComponent(new Mass() { Value = 1000000 }); // Massive central star
        sun.AddComponent(new Size() { Value = 200 }); // Large sun
        sun.AddComponent(new Luminosity() { Value = 1.0f });
        sun.AddComponent(new Name() { Value = "Sol" });
        
        // Planet 1 - Close, fast Mercury-like
        var planet1 = EntityManager.CreateEntity();
        planet1.AddComponent(new OrbitalPath()
        {
            MajorAxis = 800,
            MinorAxis = 750,
            CurrentAngle = 0,
            TiltX = 2,
            TiltY = 1,
            TiltZ = 0,
            InPlanarRotation = 0.1f
        });
        planet1.AddComponent(new OrbitalVelocity { Value = 0.002f, IsClockWise = false });
        planet1.AddComponent(new Position() { Value = OrbitalTrajectory.GetPosition(750, 800, 0.0f) });
        planet1.AddComponent(new Period(OrbitalTrajectory.GetPeriod(0.002f)));
        planet1.AddComponent(new Size() { Value = 12 }); // Exo size
        planet1.AddComponent(new Name() { Value = "Mercurius" });

        // Planet 2 - Venus-like with retrograde rotation
        var planet2 = EntityManager.CreateEntity();
        planet2.AddComponent(new OrbitalPath()
        {
            MajorAxis = 1200,
            MinorAxis = 1180,
            CurrentAngle = 1.2f,
            TiltX = 177,
            TiltY = 3,
            TiltZ = 0,
            InPlanarRotation = 0.3f
        });
        planet2.AddComponent(new OrbitalVelocity { Value = 0.0015f, IsClockWise = true }); // Retrograde
        planet2.AddComponent(new Position() { Value = OrbitalTrajectory.GetPosition(1180, 1200, 1.2f) });
        planet2.AddComponent(new Period(OrbitalTrajectory.GetPeriod(0.0015f)));
        planet2.AddComponent(new Size() { Value = 35 }); // Exo size
        planet2.AddComponent(new Name() { Value = "Venusia" });

        // Your existing Planet 3 - Earth-like (keeping your original)
        var planet3 = EntityManager.CreateEntity();
        planet3.AddComponent(new OrbitalPath()
        {
            MajorAxis = 2000,
            MinorAxis = 1800,
            CurrentAngle = 0,
            TiltX = 23,
            TiltY = 0,
            TiltZ = 0,
            InPlanarRotation = 0.2f
        });
        planet3.AddComponent(new OrbitalVelocity { Value = 0.000716f, IsClockWise = false });
        planet3.AddComponent(new Position() { Value = OrbitalTrajectory.GetPosition(1800, 2000, 0.2f) });
        planet3.AddComponent(new Period(OrbitalTrajectory.GetPeriod(0.000716f)));
        planet3.AddComponent(new Size() { Value = 42 }); // Exo size
        planet3.AddComponent(new Name() { Value = "Terra" });

        // Planet 4 - Mars-like with high eccentricity
        var planet4 = EntityManager.CreateEntity();
        planet4.AddComponent(new OrbitalPath()
        {
            MajorAxis = 2800,
            MinorAxis = 2200,
            CurrentAngle = 3.8f,
            TiltX = 25,
            TiltY = 2,
            TiltZ = 1,
            InPlanarRotation = 0.7f
        });
        planet4.AddComponent(new OrbitalVelocity { Value = 0.00052f, IsClockWise = false });
        planet4.AddComponent(new Position() { Value = OrbitalTrajectory.GetPosition(2200, 2800, 3.8f) });
        planet4.AddComponent(new Period(OrbitalTrajectory.GetPeriod(0.00052f)));
        planet4.AddComponent(new Size() { Value = 28 }); // Exo size
        planet4.AddComponent(new Name() { Value = "Martius" });

        // Planet 5 - Gas Giant with complex tilt
        var planet5 = EntityManager.CreateEntity();
        planet5.AddComponent(new OrbitalPath()
        {
            MajorAxis = 4500,
            MinorAxis = 4200,
            CurrentAngle = 2.1f,
            TiltX = 3,
            TiltY = 12,
            TiltZ = 5,
            InPlanarRotation = 1.2f
        });
        planet5.AddComponent(new OrbitalVelocity { Value = 0.0003f, IsClockWise = false });
        planet5.AddComponent(new Position() { Value = OrbitalTrajectory.GetPosition(4200, 4500, 2.1f) });
        planet5.AddComponent(new Period(OrbitalTrajectory.GetPeriod(0.0003f)));
        planet5.AddComponent(new Size() { Value = 125 }); // Giant size
        planet5.AddComponent(new Name() { Value = "Jovius" });
        planet5.AddComponent(new MoonCount() { Value = 8 });

        // Planet 6 - Ringed gas giant
        var planet6 = EntityManager.CreateEntity();
        planet6.AddComponent(new OrbitalPath()
        {
            MajorAxis = 6800,
            MinorAxis = 6400,
            CurrentAngle = 4.7f,
            TiltX = 27,
            TiltY = 8,
            TiltZ = 2,
            InPlanarRotation = 0.9f
        });
        planet6.AddComponent(new OrbitalVelocity { Value = 0.00018f, IsClockWise = false });
        planet6.AddComponent(new Position() { Value = OrbitalTrajectory.GetPosition(6400, 6800, 4.7f) });
        planet6.AddComponent(new Period(OrbitalTrajectory.GetPeriod(0.00018f)));
        planet6.AddComponent(new Size() { Value = 110 }); // Giant size
        planet6.AddComponent(new Name() { Value = "Saturnus" });
        planet6.AddComponent(new MoonCount() { Value = 12 });

        // Planet 7 - Tilted ice giant
        var planet7 = EntityManager.CreateEntity();
        planet7.AddComponent(new OrbitalPath()
        {
            MajorAxis = 9200,
            MinorAxis = 8800,
            CurrentAngle = 1.9f,
            TiltX = 98, // Extreme tilt like Uranus
            TiltY = 15,
            TiltZ = 3,
            InPlanarRotation = 2.1f
        });
        planet7.AddComponent(new OrbitalVelocity { Value = 0.00012f, IsClockWise = true }); // Retrograde due to tilt
        planet7.AddComponent(new Position() { Value = OrbitalTrajectory.GetPosition(8800, 9200, 1.9f) });
        planet7.AddComponent(new Period(OrbitalTrajectory.GetPeriod(0.00012f)));
        planet7.AddComponent(new Size() { Value = 88 }); // Mid size
        planet7.AddComponent(new Name() { Value = "Urania" });
        planet7.AddComponent(new MoonCount() { Value = 5 });

        // Planet 8 - Distant ice giant
        var planet8 = EntityManager.CreateEntity();
        planet8.AddComponent(new OrbitalPath()
        {
            MajorAxis = 12000,
            MinorAxis = 11200,
            CurrentAngle = 5.5f,
            TiltX = 28,
            TiltY = 6,
            TiltZ = 1,
            InPlanarRotation = 0.6f
        });
        planet8.AddComponent(new OrbitalVelocity { Value = 0.00008f, IsClockWise = false });
        planet8.AddComponent(new Position() { Value = OrbitalTrajectory.GetPosition(11200, 12000, 5.5f) });
        planet8.AddComponent(new Period(OrbitalTrajectory.GetPeriod(0.00008f)));
        planet8.AddComponent(new Size() { Value = 82 }); // Mid size
        planet8.AddComponent(new Name() { Value = "Neptunus" });
        planet8.AddComponent(new MoonCount() { Value = 3 });

        // Planet 9 - Distant dwarf planet with highly eccentric orbit
        var planet9 = EntityManager.CreateEntity();
        planet9.AddComponent(new OrbitalPath()
        {
            MajorAxis = 18000,
            MinorAxis = 8000, // Very eccentric orbit
            CurrentAngle = 0.8f,
            TiltX = 17,
            TiltY = 45, // High inclination
            TiltZ = 12,
            InPlanarRotation = 3.2f
        });
        planet9.AddComponent(new OrbitalVelocity { Value = 0.00004f, IsClockWise = false });
        planet9.AddComponent(new Position() { Value = OrbitalTrajectory.GetPosition(8000, 18000, 0.8f) });
        planet9.AddComponent(new Period(OrbitalTrajectory.GetPeriod(0.00004f)));
        planet9.AddComponent(new Size() { Value = 6 }); // Moon size - dwarf planet
        planet9.AddComponent(new Name() { Value = "Plutonius" });

        // Planet 10 - Rogue-like object in outer system
        var planet10 = EntityManager.CreateEntity();
        planet10.AddComponent(new OrbitalPath()
        {
            MajorAxis = 25000,
            MinorAxis = 15000, // Highly eccentric
            CurrentAngle = 3.2f,
            TiltX = 65,
            TiltY = 32,
            TiltZ = 18,
            InPlanarRotation = 4.1f
        });
        planet10.AddComponent(new OrbitalVelocity { Value = 0.00002f, IsClockWise = true });
        planet10.AddComponent(new Position() { Value = OrbitalTrajectory.GetPosition(15000, 25000, 3.2f) });
        planet10.AddComponent(new Period(OrbitalTrajectory.GetPeriod(0.00002f)));
        planet10.AddComponent(new Size() { Value = 15 }); // Exo size
        planet10.AddComponent(new Name() { Value = "Eris" });
    }
}