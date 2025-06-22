using Simulation.Core.Interfaces;

namespace Simulation.Core.Components.Station;

public struct SfärState: IDataComponent
{
    public float InternalTemperature { get; set; }
    public float InternalPressure { get; set; }
    
}