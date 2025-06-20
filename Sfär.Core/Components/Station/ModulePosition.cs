using Sfär.Core.Interfaces;
using Sfär.Core.Utility.MathExtension;

namespace Sfär.Core.Components.Station;

public struct ModulePosition:IDataComponent
{
    public Vector3 Value{ get; set; } //Position in SfärSpace not in Universe space
}