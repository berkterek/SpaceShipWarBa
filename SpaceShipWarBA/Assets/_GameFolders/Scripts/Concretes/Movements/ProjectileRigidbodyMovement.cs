using SpaceShipWarBa.Abstracts.Controllers;
using SpaceShipWarBa.Abstracts.DataContainers;
using SpaceShipWarBa.Abstracts.Movements;
using UnityEngine;

namespace SpaceShipWarBa.Movements
{
    public class ProjectileRigidbodyMovement : IMover
    {
        readonly Rigidbody2D _rigidbody2D;
        readonly IProjectileStats _projectileStats;
        float _movement = 0f;

        public ProjectileRigidbodyMovement(IProjectileController projectileController)
        {
            _rigidbody2D = projectileController.transform.GetComponent<Rigidbody2D>();
            _projectileStats = projectileController.Stats;
        }
        
        public void Tick()
        {
            _movement = _projectileStats.Direction * _projectileStats.MoveSpeed;
        }

        public void FixedTick()
        {
            _rigidbody2D.velocity = Vector2.up * _movement * Time.deltaTime;
        }
    }
}