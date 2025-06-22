using Simulation.Core.Entities;

namespace Simulation.Core.Interfaces;

public interface IEntityFactory
{
    Entity Create();
}