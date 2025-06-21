using System.Numerics;
using Simulation.Core.Interfaces;

namespace Simulation.Core.Components.Station;

public struct ModuleShape:IDataComponent
{
    public Vector3[] ShapePoints { get; set; } //local points 
}