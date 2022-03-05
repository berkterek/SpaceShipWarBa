using SpaceShipWarBa.Abstracts.Combats;
using SpaceShipWarBa.Abstracts.Controllers;
using SpaceShipWarBa.Abstracts.DataContainers;
using SpaceShipWarBa.Abstracts.Movements;
using SpaceShipWarBa.Combats;
using SpaceShipWarBa.Movements;
using SpaceShipWarBa.ScriptableObjects;
using UnityEngine;

namespace SpaceShipWarBa.Controllers
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Collider2D))]
    public class ProjectileController : MonoBehaviour, IProjectileController
    {
        [SerializeField] ProjectileStatsSO _stats;

        float _currentTime = 0f;
        IMover _mover;
        IDying _dying;

        public IAttacker Attacker { get; private set; }
        public IProjectileStats Stats => _stats;

        void Awake()
        {
            Attacker = new Attacker(_stats);
            _mover = new ProjectileRigidbodyMovement(this);
            _dying = new DyingWithDestroy(this);
        }

        void Update()
        {
            TimeToDie();

            _mover.Tick();
        }

        void FixedUpdate()
        {
            _mover.FixedTick();
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            _dying.DyingAction();
        }

        private void TimeToDie()
        {
            _currentTime += Time.deltaTime;

            if (_currentTime > _stats.MaxTime)
            {
                _dying.DyingAction();
            }
        }
    }
}