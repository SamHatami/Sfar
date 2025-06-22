using Simulation.Core.Components;
using Simulation.Core.Interfaces;
using Simulation.Core.Managers;

namespace Simulation.Core.Entities;
public class Entity
{
    public Entity(int id)
    {
        Id = id;
        Components = new IDataComponent[GlobalSettings.MaxComponents]; 
    }

    public int Id { get; }
    public IDataComponent?[] Components { get; } 
    
    public void AddComponent<T>(T component) where T : IDataComponent
    {
        var id = ComponentManager.GetId<T>();
        if(Components[id] is not null) return;  //already added the component, use SetComponent to overwrite
        
        ComponentManager.AddToComponentMap<T>(Id);
        Components[id] = component;
    }

    public T GetComponent<T>() where T : IDataComponent
    {
        var id = ComponentManager.GetId<T>();
        return (T)Components[id];
    }

    public bool TryGetComponent<T>(out T component) where T : IDataComponent //TryGetComponent?
    {
        var id = ComponentManager.GetId<T>();
        if(Components[id] is null)
        {
            component = default;
            return false;
        }

        component = (T)Components[id];
        return component is not null;
    }

    public void SetComponent<T>(T component) where T : IDataComponent
    {
        var id = ComponentManager.GetId<T>();
        Components[id] = component;
    }
}