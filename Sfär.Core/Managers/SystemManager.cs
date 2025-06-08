using System.Reflection;
using Sfär.Core.Interfaces;

namespace Sfär.Core.Managers;

public class SystemManager
{
    private ISystem[] _systems = new ISystem[100] ;
    
    public SystemManager()
    {
        var q = from t in Assembly.GetExecutingAssembly().GetTypes()
            where t.IsClass && t.Namespace == "Sfär.Core.Systems"
            select t;
        
        _systems = new ISystem[q.Count()];

        for (var i = 0; i < q.Count(); i++)
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
    
    public void Update(int timeStep)
    {
            foreach (var system in _systems)
            {
                if(system == null) continue;
                
                system.Update(timeStep);
            }
    }
}