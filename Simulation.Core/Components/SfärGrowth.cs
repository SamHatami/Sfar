using Simulation.Core.Enums.Station;
using Simulation.Core.Interfaces;

namespace Simulation.Core.Components;

public struct SfärGrowth :IDataComponent
{
    public GrowthState GrowthState { get; set; }
    public int RestCyclesRemaining { get; set; }
    public float GrowthProgress { get; set; }
}