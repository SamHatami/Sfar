using Simulation.Core.Interfaces;
using Simulation.Core.Utility.MathExtension;

namespace Simulation.Core.Components;

public struct Position : IDataComponent
{
    public Vector3 Value { get; set; } //Position on Universe-space
}