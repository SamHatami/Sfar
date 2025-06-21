using Simulation.Core.Interfaces;
using Simulation.Core.Utility.MathExtension;

namespace Simulation.Core.Components.Station;

public struct SfärShield : IDataComponent
{
    public int ShieldSize { get; set; }
    public Vector3[] Nodes { get; set; }
    
    public int PowerConsumption { get; set; } // some arbitraty units per time step
}