using Vector3 = Sfär.Core.Cluster.Vector3;

namespace Sfär.Core.Components;

public struct SpatialComponent : IComponent
{
    int Distance { get; set; }
    Vector3 Position { get; set; }
}