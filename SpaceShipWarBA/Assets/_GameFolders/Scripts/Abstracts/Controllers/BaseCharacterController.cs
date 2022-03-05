using SpaceShipWarBa.Abstracts.Combats;
using SpaceShipWarBa.Abstracts.Controllers;
using SpaceShipWarBa.Abstracts.Movements;
using UnityEngine;

namespace SpaceShipWarBa.Abstracts.Controllers
{
    [RequireComponent(typeof(Collider2D))]
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class BaseCharacterController : MonoBehaviour
    {
        protected IMover _mover;
        protected IDying _dying;
        protected float _currentAttackTime = 0f;
        
        public IAttacker Attacker { get; protected set; }
        public IHealth Health { get; protected set; }
        
        protected virtual void OnEnable()
        {
            Health.OnDead += _dying.DyingAction;
        }

        protected virtual void OnDisable()
        {
            Health.OnDead -= _dying.DyingAction;
        }
        
        protected virtual void Update()
        {
            _mover.Tick();

            FireProcess();
        }

        protected virtual void FixedUpdate()
        {
            _mover.FixedTick();
        }

        public virtual void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.TryGetComponent(out IAttackerController attackerController)) return;
            
            Health.TakeDamage(attackerController.Attacker);
        }

        protected abstract void FireProcess();
    }
}