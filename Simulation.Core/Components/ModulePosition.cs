using Simulation.Core.Interfaces;
using Simulation.Core.Utility.MathExtension;

namespace Simulation.Core.Components;

public struct ModulePosition:IDataComponent
{
    public Vector3 Value { get; init; } //Position in SfärSpace not in Universe space
}