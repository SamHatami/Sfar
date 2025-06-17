using Sfär.Core.Interfaces;
using Sfär.Core.Utility.Math;

namespace Sfär.Core.Components.Generic;

public struct Position : IDataComponent
{
    public Vector3 Value { get; set; }
}