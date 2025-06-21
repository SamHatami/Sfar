using Simulation.Core.Components;
using Simulation.Core.Components.Celestial;
using Simulation.Core.Components.Generic;
using Simulation.Core.Entities;
using Simulation.Core.Interfaces;

namespace Simulation.Core.Generators.NameGenerators;

public class PlanetNameGenerator: INameGenerator
{
    private List<Entity> _entities;
    public void CreateAndSetNames(Entity[] entities)
    {
        _entities = entities.OrderBy(e => e.GetComponent<OrbitalPath>().MeanDistance).ToList();

        for (int i = 0; i < _entities.Count; i++)
        {
            var sizeClass = _entities[i].GetComponent<PlanetClassification>().SizeClass.ToString("G");
            var planetType = _entities[i].GetComponent<PlanetClassification>().PlanetType.ToString("G")[0];
            var naming = $"P{i+1}-{sizeClass}-{planetType}";

            var name = _entities[i].GetComponent<Name>();
            name.Value = naming;
            _entities[i].SetComponent(name);
            
        }
    }
}