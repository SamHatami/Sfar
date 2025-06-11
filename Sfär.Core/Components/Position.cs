using Sfär.Core.Interfaces;
using Sfär.Core.Utility;
using Sfär.Core.Utility.Math;

namespace Sfär.Core.Components;

public struct Position : IDataComponent
{
    public Vector3 Value { get; set; }
}