using Simulation.Core.Interfaces;

namespace Simulation.Core.Components.Station;

public struct SfärCore:IDataComponent
{
   //core energy is always drained but is replenished by the nearby star in its initial state
    public int PowerGeneration { get; set; }
    public int PowerConsumption { get; set; }
    
}