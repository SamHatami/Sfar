# Sfär Simulation Project Documentation

## Project Overview

**Sfär** is a space-based Entity Component System (ECS) simulation written in C# targeting .NET 9.0. The project simulates a growing space station called a "Sfär" alongside a complex solar system with realistic orbital mechanics.

## What is a Sfär?

A Sfär is a spherical space station that serves as the central focus of the simulation. Key characteristics:

- **Growing Structure**: The Sfär can expand its outer boundary from an initial size, creating more space for modules
- **Power Management**: Requires energy to maintain its shield and internal systems
- **Modular Design**: Contains various modules (scaffolding, structural, service, living quarters, etc.)
- **Environmental Systems**: Maintains internal temperature and pressure
- **Shield System**: Protects the station using a Fibonacci spiral node arrangement

## Core Systems

### Entity Component System (ECS) Architecture

The project implements a custom ECS pattern:

- **Entities**: Represent objects in the simulation (planets, moons, Sfär, modules)
- **Components**: Data containers (Position, Mass, OrbitalPath, PowerGeneration, etc.)
- **Systems**: Logic processors that operate on entities with specific component combinations

### Key Systems

1. **OrbitalMotionSystem**: Handles realistic elliptical orbital mechanics for celestial bodies
2. **SfärGrowthSystem**: Manages the expansion and contraction cycles of the Sfär
3. **SfärPowerConsumptionSystem**: Calculates total power usage across all modules
4. **SfärShieldSystem**: Manages the protective shield using Fibonacci spiral geometry
5. **SfärStateSystem**: Simulates internal thermodynamics (temperature/pressure)

### Time Management

- Custom time system with configurable time steps
- Hierarchical time units: Hours → Days → Months → Cycles
- Real-time simulation with timer-based updates

## Technical Architecture

### Project Structure

```
Sfär.sln
├── Simulation.Core/        # Main simulation logic
│   ├── Components/         # ECS data components
│   ├── Systems/           # ECS logic systems
│   ├── Entities/          # Entity definitions and factories
│   ├── Managers/          # System coordination
│   ├── Utility/           # Math helpers and extensions
│   └── Generators/        # Content generation (names, solar systems)
├── Simulation.Console/     # Console application entry point
└── Simulation.Tests/       # Unit tests
```

### Key Technical Features

- **Custom Vector3 Implementation**: Integer-based 3D vectors for space coordinates
- **Orbital Mechanics**: Parametric ellipse calculations with 3D rotations
- **Component Management**: Type-safe component storage with reflection-based registration
- **Fibonacci Spiral Shield**: Mathematically distributed shield nodes on sphere surface
- **Thermodynamics Simulation**: Gas laws for internal Sfär atmosphere

### Performance Considerations

- Maximum 5,000 entities supported
- Array-based storage for cache efficiency
- Span<T> usage for high-performance iterations
- Component type mapping with pre-computed IDs

## Solar System Simulation

The simulation includes a detailed 10-planet solar system with:

- **Central Star**: Sol with realistic mass and luminosity
- **Planetary Variety**: Rocky planets, gas giants, ice giants, and dwarf planets
- **Complex Orbits**: Elliptical paths with realistic eccentricity and inclination
- **Moon Systems**: Major moons for gas giants with their own orbital mechanics
- **Diverse Properties**: Planet classification by size and type

### Notable Celestial Bodies

- **Mercurius**: Fast, close Mercury-like planet
- **Venusia**: Retrograde rotation Venus analogue
- **Terra**: Earth-like with Luna moon
- **Jovius**: Gas giant with 4 major moons (Io, Europa, Ganymede, Callisto)
- **Saturnus**: Ringed gas giant with Titan, Enceladus, and Mimas
- **Urania**: Extremely tilted ice giant (98° tilt)
- **Plutonius**: Distant dwarf planet with binary moon Charon

## Sfär Growth Mechanics

The Sfär undergoes growth cycles:

1. **Resting Phase**: Cooling down, pressure/temperature decrease
2. **Growth Phase**: When internal conditions exceed thresholds (121°C, 16 pressure units)
3. **Shrinking Phase**: Returns to original size after reaching maximum expansion
4. **Cycle Repeat**: 50 rest cycles between growth periods

## Dependencies

- **.NET 9.0**: Latest .NET runtime
- **ScottPlot 5.0.55**: For trajectory visualization and debugging
- **xUnit**: Testing framework

## Development Notes

### Debugging Features

- Trajectory plotting for orbital paths
- Console output for thermodynamic values
- Real-time position tracking for celestial bodies

### Future Expansion Possibilities

- Mining systems for resource extraction
- Advanced module types and connections
- Multiplayer or AI-controlled entities
- More complex physics simulations
- Visual rendering system

## Getting Started

1. **Build**: Standard .NET build process
2. **Run**: Execute Simulation.Console project
3. **Observe**: Watch console for system status updates
4. **Interact**: Press any key to stop simulation

The simulation runs in real-time with 100ms ticks, where each tick represents one in-game hour. The time step can be adjusted for faster simulation speeds.

---

*This documentation captures the current state of the Sfär simulation project as a unique blend of space station management, simplified orbital mechanics, and basic thermodynamic simulation within a custom ECS framework.*