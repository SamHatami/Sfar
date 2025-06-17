using Sfär.Core.Components;
using Sfär.Core.Components.Celestial;
using Sfär.Core.Components.Generic;
using Sfär.Core.Entities;
using Sfär.Core.Interfaces;

namespace Sfär.Core.Generators.NameGenerators;

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