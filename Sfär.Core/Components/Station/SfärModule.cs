using Sfär.Core.Enums.Station;
using Sfär.Core.Interfaces;
using Sfär.Core.Utility.MathExtension;

namespace Sfär.Core.Components.Station;

public struct SfärModule:IDataComponent
{
    public ModuleType ModuleType { get; set; }
    public Vector3[] Positions { get; set; }
    //connection ports?
    //I have a feeling that a full transform component will be needed here... 
}