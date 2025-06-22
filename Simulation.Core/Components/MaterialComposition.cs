using Simulation.Core.DataBases;
using Simulation.Core.Interfaces;

namespace Simulation.Core.Components;

public struct MaterialComposition : IDataComponent
{
    public Dictionary<MaterialType, int> Materials { get; set; }
}