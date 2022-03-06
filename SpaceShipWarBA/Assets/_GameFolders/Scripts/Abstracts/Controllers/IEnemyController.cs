using SpaceShipWarBa.Abstracts.DataContainers;
using UnityEditor.Graphs;

namespace SpaceShipWarBa.Abstracts.Controllers
{
    public interface IEnemyController : IEntityController, IAttackerController, IHealthController
    {
        IEnemyStats Stats { get; }
    }
}