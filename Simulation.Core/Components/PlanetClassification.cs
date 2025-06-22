using Simulation.Core.Enums;
using Simulation.Core.Interfaces;

namespace Simulation.Core.Components;

public struct PlanetClassification : IDataComponent
{
    public PlanetType PlanetType { get; set; }
    public PlanetSizeClass SizeClass { get; set; }
    
}