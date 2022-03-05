using SpaceShipWarBa.Abstracts.Combats;
using UnityEngine;

namespace SpaceShipWarBa.Abstracts.Controllers
{
    public interface IHealthController
    {
        IHealth Health { get; }
        void OnTriggerEnter2D(Collider2D other);
    }
}