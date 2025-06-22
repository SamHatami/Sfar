using Simulation.Core.Interfaces;

namespace Simulation.Core.Components;

public struct SfärState: IDataComponent
{
    public float InternalTemperature { get; set; }
    public float InternalPressure { get; set; }
    
}