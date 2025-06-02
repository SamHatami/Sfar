using Sfär.Core.Utility;

namespace Sfär.Core.Components;

public struct OrbitData: IComponent
{
    public int Velocity { get; set; } = 0;
    public required Vector3[] OrbitPath { get; init; }

    public OrbitData(Vector3[] orbitPath)
    {
        OrbitPath = orbitPath;
    }
}