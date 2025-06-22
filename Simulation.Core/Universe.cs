using Simulation.Core.Components;
using Simulation.Core.Entities;
using Simulation.Core.Enums.Station;
using Simulation.Core.Utility;
using Simulation.Core.Managers;
using Simulation.Core.Systems;
using Simulation.Core.Utility.MathExtension;
using Simulation.Core.Utility.Orbits;

namespace Simulation.Core;

public class Universe
{
    public void Start()
    {
        //Sfär is always has id 0

        
        CreateSfär();
    
        #region Planets,Moons,Stars
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
        planet1.AddComponent(new Position() { Value = OrbitalTrajectory.GetPosition(750, 800, 0.0f, 2, 1, 0, 0.1f) });
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
        planet2.AddComponent(new Position() { Value = OrbitalTrajectory.GetPosition(1180, 1200, 1.2f, 177, 3, 0, 0.3f) });
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
        planet3.AddComponent(new Position() { Value = OrbitalTrajectory.GetPosition(1800, 2000, 0.0f, 23, 0, 0, 0.2f) });
        planet3.AddComponent(new Period(OrbitalTrajectory.GetPeriod(0.000716f)));
        planet3.AddComponent(new Size() { Value = 42 }); // Exo size
        planet3.AddComponent(new Name() { Value = "Terra" });

                
        // Moon 1 on planet 3 (Terra)
        var moon1 = EntityManager.CreateEntity();
        moon1.AddComponent(new Parent(){ParentId = planet3.Id});
        moon1.AddComponent(new OrbitalPath()
        {
            MajorAxis = 150,
            MinorAxis = 145,
            CurrentAngle = 0,
        });
        moon1.AddComponent(new OrbitalVelocity { Value = 0.001f, IsClockWise = true });
        moon1.AddComponent(new Position() { Value = OrbitalTrajectory.GetPosition(145, 150, 0.0f, 0, 0, 0, 0.0f) });
        moon1.AddComponent(new Period(OrbitalTrajectory.GetPeriod(0.001f)));
        moon1.AddComponent(new Size() { Value = 2 }); // Moon size
        moon1.AddComponent(new Name() { Value = "Luna" });
        
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
        planet4.AddComponent(new Position() { Value = OrbitalTrajectory.GetPosition(2200, 2800, 3.8f, 25, 2, 1, 0.7f) });
        planet4.AddComponent(new Period(OrbitalTrajectory.GetPeriod(0.00052f)));
        planet4.AddComponent(new Size() { Value = 28 }); // Exo size
        planet4.AddComponent(new Name() { Value = "Martius" });

        // Mars moons - Phobos and Deimos
        var phobos = EntityManager.CreateEntity();
        phobos.AddComponent(new Parent(){ParentId = planet4.Id});
        phobos.AddComponent(new OrbitalPath()
        {
            MajorAxis = 35,
            MinorAxis = 32,
            CurrentAngle = 0.5f,
        });
        phobos.AddComponent(new OrbitalVelocity { Value = 0.008f, IsClockWise = false });
        phobos.AddComponent(new Position() { Value = OrbitalTrajectory.GetPosition(32, 35, 0.5f, 0, 0, 0, 0.0f) });
        phobos.AddComponent(new Period(OrbitalTrajectory.GetPeriod(0.008f)));
        phobos.AddComponent(new Size() { Value = 1 }); // Very small moon
        phobos.AddComponent(new Name() { Value = "Phobos" });

        var deimos = EntityManager.CreateEntity();
        deimos.AddComponent(new Parent(){ParentId = planet4.Id});
        deimos.AddComponent(new OrbitalPath()
        {
            MajorAxis = 85,
            MinorAxis = 80,
            CurrentAngle = 2.1f,
        });
        deimos.AddComponent(new OrbitalVelocity { Value = 0.003f, IsClockWise = false });
        deimos.AddComponent(new Position() { Value = OrbitalTrajectory.GetPosition(80, 85, 2.1f, 0, 0, 0, 0.0f) });
        deimos.AddComponent(new Period(OrbitalTrajectory.GetPeriod(0.003f)));
        deimos.AddComponent(new Size() { Value = 1 }); // Very small moon
        deimos.AddComponent(new Name() { Value = "Deimos" });

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
        planet5.AddComponent(new Position() { Value = OrbitalTrajectory.GetPosition(4200, 4500, 2.1f, 3, 12, 5, 1.2f) });
        planet5.AddComponent(new Period(OrbitalTrajectory.GetPeriod(0.0003f)));
        planet5.AddComponent(new Size() { Value = 125 }); // Giant size
        planet5.AddComponent(new Name() { Value = "Jovius" });
        planet5.AddComponent(new MoonCount() { Value = 4 }); // Updated count

        // Jovius major moons
        var io = EntityManager.CreateEntity();
        io.AddComponent(new Parent(){ParentId = planet5.Id});
        io.AddComponent(new OrbitalPath()
        {
            MajorAxis = 180,
            MinorAxis = 175,
            CurrentAngle = 0.0f,
        });
        io.AddComponent(new OrbitalVelocity { Value = 0.006f, IsClockWise = false });
        io.AddComponent(new Position() { Value = OrbitalTrajectory.GetPosition(175, 180, 0.0f, 0, 0, 0, 0.0f) });
        io.AddComponent(new Period(OrbitalTrajectory.GetPeriod(0.006f)));
        io.AddComponent(new Size() { Value = 3 }); // Moon size
        io.AddComponent(new Name() { Value = "Io" });

        var europa = EntityManager.CreateEntity();
        europa.AddComponent(new Parent(){ParentId = planet5.Id});
        europa.AddComponent(new OrbitalPath()
        {
            MajorAxis = 250,
            MinorAxis = 245,
            CurrentAngle = 1.6f,
        });
        europa.AddComponent(new OrbitalVelocity { Value = 0.004f, IsClockWise = false });
        europa.AddComponent(new Position() { Value = OrbitalTrajectory.GetPosition(245, 250, 1.6f, 0, 0, 0, 0.0f) });
        europa.AddComponent(new Period(OrbitalTrajectory.GetPeriod(0.004f)));
        europa.AddComponent(new Size() { Value = 3 }); // Moon size
        europa.AddComponent(new Name() { Value = "Europa" });

        var ganymede = EntityManager.CreateEntity();
        ganymede.AddComponent(new Parent(){ParentId = planet5.Id});
        ganymede.AddComponent(new OrbitalPath()
        {
            MajorAxis = 380,
            MinorAxis = 370,
            CurrentAngle = 3.2f,
        });
        ganymede.AddComponent(new OrbitalVelocity { Value = 0.0025f, IsClockWise = false });
        ganymede.AddComponent(new Position() { Value = OrbitalTrajectory.GetPosition(370, 380, 3.2f, 0, 0, 0, 0.0f) });
        ganymede.AddComponent(new Period(OrbitalTrajectory.GetPeriod(0.0025f)));
        ganymede.AddComponent(new Size() { Value = 5 }); // Larger moon
        ganymede.AddComponent(new Name() { Value = "Ganymede" });

        var callisto = EntityManager.CreateEntity();
        callisto.AddComponent(new Parent(){ParentId = planet5.Id});
        callisto.AddComponent(new OrbitalPath()
        {
            MajorAxis = 520,
            MinorAxis = 510,
            CurrentAngle = 4.8f,
        });
        callisto.AddComponent(new OrbitalVelocity { Value = 0.0015f, IsClockWise = false });
        callisto.AddComponent(new Position() { Value = OrbitalTrajectory.GetPosition(510, 520, 4.8f, 0, 0, 0, 0.0f) });
        callisto.AddComponent(new Period(OrbitalTrajectory.GetPeriod(0.0015f)));
        callisto.AddComponent(new Size() { Value = 4 }); // Moon size
        callisto.AddComponent(new Name() { Value = "Callisto" });

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
        planet6.AddComponent(new Position() { Value = OrbitalTrajectory.GetPosition(6400, 6800, 4.7f, 27, 8, 2, 0.9f) });
        planet6.AddComponent(new Period(OrbitalTrajectory.GetPeriod(0.00018f)));
        planet6.AddComponent(new Size() { Value = 110 }); // Giant size
        planet6.AddComponent(new Name() { Value = "Saturnus" });
        planet6.AddComponent(new MoonCount() { Value = 3 }); // Updated count

        // Saturnus major moons
        var titan = EntityManager.CreateEntity();
        titan.AddComponent(new Parent(){ParentId = planet6.Id});
        titan.AddComponent(new OrbitalPath()
        {
            MajorAxis = 420,
            MinorAxis = 410,
            CurrentAngle = 1.3f,
        });
        titan.AddComponent(new OrbitalVelocity { Value = 0.002f, IsClockWise = false });
        titan.AddComponent(new Position() { Value = OrbitalTrajectory.GetPosition(410, 420, 1.3f, 0, 0, 0, 0.0f) });
        titan.AddComponent(new Period(OrbitalTrajectory.GetPeriod(0.002f)));
        titan.AddComponent(new Size() { Value = 6 }); // Large moon
        titan.AddComponent(new Name() { Value = "Titan" });

        var enceladus = EntityManager.CreateEntity();
        enceladus.AddComponent(new Parent(){ParentId = planet6.Id});
        enceladus.AddComponent(new OrbitalPath()
        {
            MajorAxis = 180,
            MinorAxis = 175,
            CurrentAngle = 3.7f,
        });
        enceladus.AddComponent(new OrbitalVelocity { Value = 0.008f, IsClockWise = false });
        enceladus.AddComponent(new Position() { Value = OrbitalTrajectory.GetPosition(175, 180, 3.7f, 0, 0, 0, 0.0f) });
        enceladus.AddComponent(new Period(OrbitalTrajectory.GetPeriod(0.008f)));
        enceladus.AddComponent(new Size() { Value = 2 }); // Small moon
        enceladus.AddComponent(new Name() { Value = "Enceladus" });

        var mimas = EntityManager.CreateEntity();
        mimas.AddComponent(new Parent(){ParentId = planet6.Id});
        mimas.AddComponent(new OrbitalPath()
        {
            MajorAxis = 125,
            MinorAxis = 120,
            CurrentAngle = 5.2f,
        });
        mimas.AddComponent(new OrbitalVelocity { Value = 0.012f, IsClockWise = false });
        mimas.AddComponent(new Position() { Value = OrbitalTrajectory.GetPosition(120, 125, 5.2f, 0, 0, 0, 0.0f) });
        mimas.AddComponent(new Period(OrbitalTrajectory.GetPeriod(0.012f)));
        mimas.AddComponent(new Size() { Value = 1 }); // Very small moon
        mimas.AddComponent(new Name() { Value = "Mimas" });

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
        planet7.AddComponent(new Position() { Value = OrbitalTrajectory.GetPosition(8800, 9200, 1.9f, 98, 15, 3, 2.1f) });
        planet7.AddComponent(new Period(OrbitalTrajectory.GetPeriod(0.00012f)));
        planet7.AddComponent(new Size() { Value = 88 }); // Mid size
        planet7.AddComponent(new Name() { Value = "Urania" });
        planet7.AddComponent(new MoonCount() { Value = 2 }); // Updated count

        // Urania moons (tilted system)
        var miranda = EntityManager.CreateEntity();
        miranda.AddComponent(new Parent(){ParentId = planet7.Id});
        miranda.AddComponent(new OrbitalPath()
        {
            MajorAxis = 95,
            MinorAxis = 90,
            CurrentAngle = 0.8f,
            TiltX = 95, // Following parent's extreme tilt
        });
        miranda.AddComponent(new OrbitalVelocity { Value = 0.015f, IsClockWise = true });
        miranda.AddComponent(new Position() { Value = OrbitalTrajectory.GetPosition(90, 95, 0.8f, 95, 0, 0, 0.0f) });
        miranda.AddComponent(new Period(OrbitalTrajectory.GetPeriod(0.015f)));
        miranda.AddComponent(new Size() { Value = 2 }); // Small moon
        miranda.AddComponent(new Name() { Value = "Miranda" });

        var ariel = EntityManager.CreateEntity();
        ariel.AddComponent(new Parent(){ParentId = planet7.Id});
        ariel.AddComponent(new OrbitalPath()
        {
            MajorAxis = 160,
            MinorAxis = 155,
            CurrentAngle = 4.1f,
            TiltX = 98, // Following parent's extreme tilt
        });
        ariel.AddComponent(new OrbitalVelocity { Value = 0.008f, IsClockWise = true });
        ariel.AddComponent(new Position() { Value = OrbitalTrajectory.GetPosition(155, 160, 4.1f, 98, 0, 0, 0.0f) });
        ariel.AddComponent(new Period(OrbitalTrajectory.GetPeriod(0.008f)));
        ariel.AddComponent(new Size() { Value = 3 }); // Moon size
        ariel.AddComponent(new Name() { Value = "Ariel" });

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
        planet8.AddComponent(new Position() { Value = OrbitalTrajectory.GetPosition(11200, 12000, 5.5f, 28, 6, 1, 0.6f) });
        planet8.AddComponent(new Period(OrbitalTrajectory.GetPeriod(0.00008f)));
        planet8.AddComponent(new Size() { Value = 82 }); // Mid size
        planet8.AddComponent(new Name() { Value = "Neptunus" });
        planet8.AddComponent(new MoonCount() { Value = 1 }); // Updated count

        // Neptunus moon
        var triton = EntityManager.CreateEntity();
        triton.AddComponent(new Parent(){ParentId = planet8.Id});
        triton.AddComponent(new OrbitalPath()
        {
            MajorAxis = 280,
            MinorAxis = 270,
            CurrentAngle = 2.3f,
            TiltX = 157, // Retrograde orbit
        });
        triton.AddComponent(new OrbitalVelocity { Value = 0.005f, IsClockWise = true }); // Retrograde
        triton.AddComponent(new Position() { Value = OrbitalTrajectory.GetPosition(270, 280, 2.3f, 157, 0, 0, 0.0f) });
        triton.AddComponent(new Period(OrbitalTrajectory.GetPeriod(0.005f)));
        triton.AddComponent(new Size() { Value = 4 }); // Moon size
        triton.AddComponent(new Name() { Value = "Triton" });

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
        planet9.AddComponent(new Position() { Value = OrbitalTrajectory.GetPosition(8000, 18000, 0.8f, 17, 45, 12, 3.2f) });
        planet9.AddComponent(new Period(OrbitalTrajectory.GetPeriod(0.00004f)));
        planet9.AddComponent(new Size() { Value = 6 }); // Moon size - dwarf planet
        planet9.AddComponent(new Name() { Value = "Plutonius" });

        // Plutonius moon - Charon (binary system)
        var charon = EntityManager.CreateEntity();
        charon.AddComponent(new Parent(){ParentId = planet9.Id});
        charon.AddComponent(new OrbitalPath()
        {
            MajorAxis = 25,
            MinorAxis = 24,
            CurrentAngle = 1.5f,
        });
        charon.AddComponent(new OrbitalVelocity { Value = 0.02f, IsClockWise = false });
        charon.AddComponent(new Position() { Value = OrbitalTrajectory.GetPosition(24, 25, 1.5f, 0, 0, 0, 0.0f) });
        charon.AddComponent(new Period(OrbitalTrajectory.GetPeriod(0.02f)));
        charon.AddComponent(new Size() { Value = 3 }); // Large relative to parent
        charon.AddComponent(new Name() { Value = "Charon" });

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
        planet10.AddComponent(new Position() { Value = OrbitalTrajectory.GetPosition(15000, 25000, 3.2f, 65, 32, 18, 4.1f) });
        planet10.AddComponent(new Period(OrbitalTrajectory.GetPeriod(0.00002f)));
        planet10.AddComponent(new Size() { Value = 15 }); // Exo size
        planet10.AddComponent(new Name() { Value = "Eris" });
        #endregion
    }

    private static void CreateSfär()
    {
        var sfärEntity = EntityManager.CreateEntity();
        sfärEntity.AddComponent(new Sfär(){innerBound = 20, outerBound = 40});
        sfärEntity.AddComponent(new PowerConsumption());
        sfärEntity.AddComponent(new PowerGeneration(){Value = 20});
        sfärEntity.AddComponent(new Age(){Value = 0});
        sfärEntity.AddComponent(new SfärState() {InternalPressure = 1, InternalTemperature = 100});
        sfärEntity.AddComponent(new SfärShield());
        sfärEntity.AddComponent(new SfärGrowth(){GrowthState = GrowthState.Resting});
        
    }
}