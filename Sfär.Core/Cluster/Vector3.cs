namespace Sfär.Core.Cluster;

/// <summary>
/// A vector with three integer values, representing a point in space or a vector
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
        Magnitude = (int)(x*x + y*y + z*z);
    }
}