using Simulation.Core.Interfaces;

namespace Simulation.Core.Systems;

public struct SfärState: IDataComponent
{
    public int InternalTemperature { get; set; }
    public int InternalPressure { get; set; }
    
}