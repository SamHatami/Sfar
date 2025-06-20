using System.Reflection;
using Sfär.Core.Interfaces;

namespace Sfär.Core.Managers;

public static class SystemManager
{
    private static ISystem[] _systems = new ISystem[GlobalSettings.MaxSystems] ;
    private static int _systemsCount;
    
    static SystemManager()
    {
        var q = from t in Assembly.GetExecutingAssembly().GetTypes()
            where t.IsClass && t.Namespace == "Sfär.Core.Systems"
            select t;
        
        _systemsCount  = q.Count();
        
        for (var i = 0; i < _systemsCount; i++)
        {
            try
            {
                _systems[i] = (ISystem)Activator.CreateInstance(q.ElementAt(i));
            }
            catch (Exception e)
            {
                Console.WriteLine($"Could not add system {q.ElementAt(i).Name} to systemregistry");
            }
        }
        
    }
    
    public static void Update(int timeStep)
    {
        for (var i = 0; i < _systemsCount; i++)
            _systems[i].Update(timeStep);
        
    }
}