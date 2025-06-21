using Simulation.Core.Interfaces;
using Simulation.Core.Utility.MathExtension;

namespace Simulation.Core.Components.Generic;

public struct Position : IDataComponent
{
    public Vector3 Value { get; set; } //Position on Universe-space
}