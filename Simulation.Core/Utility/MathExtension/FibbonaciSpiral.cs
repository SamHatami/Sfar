namespace Simulation.Core.Utility.MathExtension;
using static Math;

public static class FibbonaciSpiral
{
    //https://extremelearning.com.au/how-to-evenly-distribute-points-on-a-sphere-more-effectively-than-the-canonical-fibonacci-lattice/
    public static Vector3[] GetNodes(int nrOfPoints, int radius)
    {
        var points = new Vector3[nrOfPoints];
        var golderRatio = (1 + Sqrt(5)) / 2;

        for (int i = 0; i < nrOfPoints; i++)
        {
            var theta = 2 * PI * i / golderRatio;
            var phi = Acos(1-2*(i+0.5)/nrOfPoints);
            
            int x = (int)Floor(Cos(theta)*Sin(phi))*radius;
            int y = (int)Floor(Sin(theta)*Sin(phi))*radius;
            int z = (int)Floor(Cos(phi))*radius;
            
            points[i] = new Vector3(x, y, z);
        }
        
        return points;
    }
}