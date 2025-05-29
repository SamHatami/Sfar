using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using ScottPlot;
using Sfär.Core.Cluster;
namespace Sfär.Core.Orbits;

public class OrbitalTrajectory
{
    // rotate ellipse in 2d: https://math.stackexchange.com/questions/2645689/what-is-the-parametric-equation-of-a-rotated-ellipse-given-the-angle-of-rotatio
    //parametic form of ellipse: https://math.stackexchange.com/questions/22064/calculating-a-point-that-lies-on-an-ellipse-given-an-angle
    
    private static readonly int steps = 1000; //Resolution, might need to increase the bigger the distances
    private static int _universeCenter = GlobalSettings.UniverseSize/2;
    Vector3[] positions = new Vector3[steps];
    Coordinates[] coordinates = new Coordinates[steps];
    
    //Theta is rotation against the normal axis before 3d tranformation [rad]
    public void CreateEllipseInSpace(int minorAxis, int majorAxis, int xTilt, int yTilt, int zTilt, double theta = 0)
    { 
        var radStep = (2*Math.PI) / steps;
        var ellipsoidal_factor = 0.1;
        for (int i = 0; i < steps; i++)
        {
            positions[i].X = double.ConvertToInteger<int>(
                _universeCenter+majorAxis*Math.Cos(radStep*i)*Math.Cos(theta)-minorAxis*Math.Sin(radStep*i)*Math.Sin(theta));
            positions[i].Y = double.ConvertToInteger<int>(
                _universeCenter+majorAxis*Math.Cos(radStep*i)*Math.Sin(theta)+minorAxis*Math.Sin(radStep*i)*Math.Cos(theta));
            positions[i].Z = 0;
            
            coordinates[i].X = positions[i].X;
            coordinates[i].Y = positions[i].Y;
        }
        
        
        int structSize = Unsafe.SizeOf<Vector3>();
        int arraySize = steps * structSize;
        Console.WriteLine($"One Vector3: {structSize} bytes");
        Console.WriteLine($"{steps} Vector3s: {arraySize} bytes ({arraySize / 1024.0:F1} KB)");
        
        PrintTrajectory();
        
    }

    void PrintTrajectory()
    {
        var plot = new ScottPlot.Plot();
        plot.Add.Scatter(coordinates);
        plot.Axes.SquareUnits();
        plot.SavePng("OrbitalTrajectory.png",4000, 4000);
    }
}