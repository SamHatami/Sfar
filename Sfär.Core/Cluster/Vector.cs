namespace Sfär.Core.Cluster;

/// <summary>
/// A vector with three integer values, representing a point or a vector in space
/// </summary>
public struct Vector3
{
    public int X, Y, Z;
    public int Magnitude { get; }
    
    public Vector3(int x, int y, int z)
    {
        X = x;
        Y = y;
        Z = z;
        Magnitude = x*x + y*y + z*z;
    }
}

/// <summary>
/// A vector with two integer values, representing a point or a vector on a plane
/// </summary>
public struct Vector2
{
    public int X, Y, Z;
    public int Magnitude { get; }
    
    public Vector2(int x, int y)
    {
        X = x;
        Y = y;
        Magnitude = x*x + y*y;
    }
}