using Simulation.Core.Enums.Station;
using Simulation.Core.Interfaces;
using Simulation.Core.Utility.MathExtension;

namespace Simulation.Core.Components.Station;

public struct SfärModule:IDataComponent
{
    public ModuleType ModuleType { get; init; }
    public Vector3[] Slots { get; init; }
    //connection ports?
    //I have a feeling that a full transform component will be needed here... 
}