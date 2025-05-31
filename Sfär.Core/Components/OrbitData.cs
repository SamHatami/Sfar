using Sfär.Core.Cluster;

namespace Sfär.Core.Components;

public struct OrbitData: IComponent
{
    public int Velocity { get; set; }
    public Vector3[] OrbitPath { get; set; }
}