using System.Numerics;
using Sfär.Core.Interfaces;

namespace Sfär.Core.Components.Station;

public struct ModuleShape:IDataComponent
{
    public Vector3[] ShapePoints { get; set; } //local points 
}