using Sfär.Core.Cluster;

namespace Sfär.Core.Components;

public struct SpatialData : IComponent
{
    int Distance { get; set; }
    Vector3 Position { get; set; }
}