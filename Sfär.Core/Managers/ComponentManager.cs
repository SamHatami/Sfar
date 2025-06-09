namespace Sfär.Core.Managers;

public class ComponentManager
{

      private Dictionary<int,List<int>> ComponentMap = new(); 

      private Dictionary<Type, int> ComponentIds = new();
    
    
    //alternativt en Dictionary<int,ulong> där uLong får bit-operation. Men för att få ut index för varje entitet så behövs en loop genom ulong oavsett?
    public ComponentManager(){
  
      var componentTypes = from t in Assembly.GetExecutingAssembly().GetTypes()
            where t.IsValueType && !t.IsEnum && t.Namespace == "Sfär.Core.Components"
            select t;
        
        for (var i = 0; i < componentTypes.Count(); i++)
        {
            try
            {
                var componentType = componentsList[i];
                
                if (typeof(IComponent).IsAssignableFrom(componentType))
                  ComponentIds[componentType] = i; 
            }
            catch (Exception e)
            {
                Console.WriteLine($"Could not add component {components.ElementAt(i).Name} to Components");
            }
        }
      
    }
    //go through assembly and namespace and add to this dictionary instead.....

    

    public int GetId<T>()
    {
        return ComponentIds[typeof(T)];
    }

    public void AddToComponentMap<T>(int entityId)
    {
        var componentId = GetId<T>();
        
        if (!ComponentMap.ContainsKey(componentId))
            ComponentMap.Add(componentId, new List<int>());
        
        var componentMask = ComponentMap[componentId];
        componentMask.Add(entityId);
    }

    public int[] GetEntityIdsFor<T>()
    {
        var componentId = GetId<T>();
        var componentMask = ComponentMap[componentId];
       
        return componentMask.ToArray();
    }


}
