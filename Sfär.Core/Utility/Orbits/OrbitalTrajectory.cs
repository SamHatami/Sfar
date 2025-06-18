using System.Runtime.CompilerServices;
using ScottPlot;
using Sfär.Core.Utility.MathExtension;

namespace Sfär.Core.Utility.Orbits;

public static class OrbitalTrajectory
{
    //parametic form of ellipse: https://math.stackexchange.com/questions/22064/calculating-a-point-that-lies-on-an-ellipse-given-an-angle

    private static readonly int steps = 100; //Resolution, might need to increase the bigger the distances
    private static readonly int _universeCenter = GlobalSettings.UniverseSize / 2;


   // Theta is rotation against the normal axis before 3d tranformation [rad]
     public static Vector3[] CreateEllipseInSpace(int minorAxis, int majorAxis, int xTilt = 0, int yTilt = 0,
         int zTilt = 0, double theta = 0)
     {
         var positions = new Vector3[steps];
         var radStep = (2 * System.Math.PI) / steps;
         for (var i = 0; i < steps-1; i++)
         {
             positions[i].X = double.ConvertToInteger<int>(
                 _universeCenter + majorAxis * System.Math.Cos(radStep * i) * System.Math.Cos(theta) -
                 minorAxis * System.Math.Sin(radStep * i) * System.Math.Sin(theta));
             positions[i].Y = double.ConvertToInteger<int>(
                 _universeCenter + majorAxis * System.Math.Cos(radStep * i) * System.Math.Sin(theta) +
                 minorAxis * System.Math.Sin(radStep * i) * System.Math.Cos(theta));
             positions[i].Z = 0;

             positions[i] = positions[i].Rotate(Axis.X, xTilt);
             positions[i] = positions[i].Rotate(Axis.Y, yTilt);
             positions[i] = positions[i].Rotate(Axis.Z, zTilt);
         }

#if DEBUG
    PrintArraySize(positions);
    var coordinates = positions.Select(p => new Coordinates(p.X, p.Y)).ToArray();

    PrintTrajectory(coordinates);
#endif
         return positions;
     }
     
     public static Vector3 GetPosition(int minorAxis, int majorAxis, float angle, int xTilt = 0, int yTilt = 0,
         int zTilt = 0, double theta = 0, Vector3 center = default)
     {
        
         var newPosition = new Vector3
         {
             X = double.ConvertToInteger<int>(
                 center.X + majorAxis * System.Math.Cos(angle) * System.Math.Cos(theta) -
                 minorAxis * System.Math.Sin(angle) * System.Math.Sin(theta)),
             Y = double.ConvertToInteger<int>(
                 center.Y + majorAxis * System.Math.Cos(angle) * System.Math.Sin(theta) +
                 minorAxis * System.Math.Sin(angle) * System.Math.Cos(theta)),
             Z = center.Z
         };
        
         newPosition = newPosition.Rotate(Axis.X, xTilt);
         newPosition = newPosition.Rotate(Axis.Y, yTilt);
         newPosition = newPosition.Rotate(Axis.Z, zTilt);
        
         return newPosition;
     }

     public static float GetPeriod(float radialVelocity)
     {

         return (float)(2*System.Math.PI/radialVelocity);

     }

        //https://circumferencecalculator.net/ellipse-perimeter-calculator
    public static int GetPerimeter(double a, double b)
    {
        var h = System.Math.Pow((a - b) / (a + b), 2);
        var A = System.Math.PI*(a+b);
        var B = 1+(3*h)/(10+System.Math.Sqrt(4-3*h));
        return (int)(A*B);
    }
    
    //Claude based on https://www.mathsisfun.com/geometry/ellipse-perimeter.html
    public static double EllipsePerimeter(double a, double b, int terms = 10)
    {
        double h = System.Math.Pow(a - b, 2) / System.Math.Pow(a + b, 2);
        double sum = 1.0;
        double hPower = h;
    
        // Precomputed coefficients for first few terms
        double[] coeffs = { 0.25, 0.015625, 0.00390625, 0.001525878906 };
    
        for (int n = 1; n < System.Math.Min(terms, coeffs.Length + 1); n++)
        {
            sum += coeffs[n-1] * hPower;
            hPower *= h;
        }
    
        return System.Math.PI * (a + b) * sum;
    }

    private static void PrintArraySize(Vector3[] positions)
    {
        var structSize = Unsafe.SizeOf<Vector3>();
        var arraySize = steps * structSize;
        Console.WriteLine($"One Vector3: {structSize} bytes");
        Console.WriteLine($"{steps} Vector3s: {arraySize} bytes ({arraySize / 1024.0:F1} KB)");
    }
    private static void PrintTrajectory(Coordinates[] coordinates)
    {
        var plot = new ScottPlot.Plot();
        plot.Add.Scatter(coordinates);
        plot.Axes.SquareUnits();
        plot.SavePng("OrbitalTrajectory.png",4000, 4000);
    }
}