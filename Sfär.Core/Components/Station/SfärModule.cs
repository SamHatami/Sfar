using Sfär.Core.Enums.Station;
using Sfär.Core.Utility.MathExtension;

namespace Sfär.Core.Components.Station;

public struct SfärModule
{
    public ModuleType ModuleType { get; set; }
    public Vector3[] Positions { get; set; }
}