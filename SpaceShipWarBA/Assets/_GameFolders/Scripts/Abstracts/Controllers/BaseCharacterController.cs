using SpaceShipWarBa.Abstracts.Combats;
using SpaceShipWarBa.Abstracts.DataContainers;
using SpaceShipWarBa.Abstracts.Movements;
using SpaceShipWarBa.Abstracts.ScriptableObjects;
using SpaceShipWarBa.Combats;
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

        protected void AwakeProcess(IEntityController entityController, ICharacterStats characterStats,
            AttackerStats attackerStats)
        {
            Health = new CharacterHealth(characterStats);
            Attacker = new Attacker(attackerStats);
            _dying = new DyingWithDestroy(entityController);
        }

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