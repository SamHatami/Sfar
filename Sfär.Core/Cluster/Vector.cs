namespace Sfär.Core.Cluster;

/// <summary>
/// A vector with three integer values, representing a point or a vector in space
/// </summary>
public struct Vector3
{
    public int X, Y, Z = 0;
    public int Magnitude { get; }

    public Vector3(int x, int y, int z)
    {
        X = x;
        Y = y;
        Z = z;
        Magnitude = x * x + y * y + z * z;
    }
}

/// <summary>
/// A vector with two integer values, representing a point or a vector on a plane
/// </summary>
public struct Vector2
{
    public int X, Y, Z = 0;
    public int Magnitude { get; }

    public Vector2(int x, int y)
    {
        X = x;
        Y = y;
        Magnitude = x * x + y * y;
    }
}

public static class VectorExtension
{
    public static Vector3 Rotate(this Vector3 vec, Axis axis, int angleRad)
    {
        var rotationMatrix = axis switch
        {
            Axis.X => RotationX(angleRad),
            Axis.Y => RotationY(angleRad),
            Axis.Z => RotationZ(angleRad),
            _ => new double[3, 3]
        };

    
        return new Vector3
        {
            X = (int)Math.Round(rotationMatrix[0, 0] * vec.X + rotationMatrix[0, 1] * vec.Y + rotationMatrix[0, 2] * vec.Z),
            Y = (int)Math.Round(rotationMatrix[1, 0] * vec.X + rotationMatrix[1, 1] * vec.Y + rotationMatrix[1, 2] * vec.Z),
            Z = (int)Math.Round(rotationMatrix[2, 0] * vec.X + rotationMatrix[2, 1] * vec.Y + rotationMatrix[2, 2] * vec.Z)
        };

    }

    private static double[,] RotationZ(int angleRad)
    {
        var cosA = Math.Cos(angleRad);
        var sinA = Math.Sin(angleRad);
        double[,] rotationZ =
        {
            { cosA, sinA, 0 },
            { sinA, cosA, 0 },
            { 0, 0, 1 }
        };

        return rotationZ;
    }

    private static double[,] RotationY(int angleRad)
    {
        var cosA = Math.Cos(angleRad);
        var sinA = Math.Sin(angleRad);
        double[,] rotationY =
        {
            { cosA, 0, sinA },
            { 0, 1, 0 },
            { -sinA, 0, cosA },
        };

        return rotationY;
    }

    private static double[,] RotationX(int angleRad)
    {
        var cosA = Math.Cos(angleRad);
        var sinA = Math.Sin(angleRad);
        double[,] rotationY =
        {
            { 1, 0, 0 },
            { 0, cosA, -sinA },
            { 0, sinA, cosA },
        };

        return rotationY;
    }
}

public enum Axis
{
    X,
    Y,
    Z
}