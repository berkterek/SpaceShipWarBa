using System.Collections;
using SpaceShipWarBa.Abstracts.Combats;
using SpaceShipWarBa.Abstracts.DataContainers;
using SpaceShipWarBa.Abstracts.ScriptableObjects;
using SpaceShipWarBa.Abstracts.Sounds;
using SpaceShipWarBa.Combats;
using UnityEngine;

namespace SpaceShipWarBa.Abstracts.Controllers
{
    [RequireComponent(typeof(Collider2D))]
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class BaseCharacterController : MonoBehaviour
    {
        [SerializeField] GameObject _body;
        [SerializeField] ParticleSystem _particle;
        [SerializeField] Collider2D _collider2D;
        
        protected IDying _dying;
        protected float _currentAttackTime = 0f;
        protected ICharacterSoundPlayer _sound;

        public IAttacker Attacker { get; private set; }
        public IHealth Health { get; private set; }

        protected void AwakeProcess(IEntityController entityController, ICharacterStats characterStats,
            AttackerStats attackerStats)
        {
            Health = new CharacterHealth(characterStats);
            Attacker = new Attacker(attackerStats);
            _dying = new DyingWithDestroy(entityController);
        }

        protected virtual void OnEnable()
        {
            Health.OnDead += HandleOnDead;
            Health.OnTookDamage += HandleOnTookDamage;
        }

        protected virtual void OnDisable()
        {
            Health.OnDead -= HandleOnDead;
            Health.OnTookDamage -= HandleOnTookDamage;
        }

        protected virtual void Update()
        {
            FireProcess();
        }

        public virtual void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.TryGetComponent(out IAttackerController attackerController)) return;

            Health.TakeDamage(attackerController.Attacker);
        }

        protected abstract void FireProcess();

        protected virtual void HandleOnDead()
        {
            StartCoroutine(HandleOnDeadAsync());
        }

        IEnumerator HandleOnDeadAsync()
        {
            _collider2D.enabled = false;
            _body.SetActive(false);
            _particle.gameObject.SetActive(true);

            yield return new WaitForSeconds(0.3f);
            
            _dying.DyingAction();
        }
        
        protected virtual void HandleOnTookDamage(int currentHealth, int maxHealth)
        {
            _sound.TakeHitSound();
        }
    }
}