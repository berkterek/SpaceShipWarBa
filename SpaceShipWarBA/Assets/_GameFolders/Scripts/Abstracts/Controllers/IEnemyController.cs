using SpaceShipWarBa.Abstracts.DataContainers;
using UnityEditor.Graphs;
using UnityEngine;

namespace SpaceShipWarBa.Abstracts.Controllers
{
    public interface IEnemyController : IEntityController, IAttackerController, IHealthController
    {
        IEnemyStats Stats { get; }
        void SetPath(GameObject path);
    }
}