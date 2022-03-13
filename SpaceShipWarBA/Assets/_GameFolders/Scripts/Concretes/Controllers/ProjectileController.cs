using System.Collections;
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
        bool _isOnTrigger = false;
        SpriteRenderer _spriteRenderer;
        Collider2D _collider2D;
        Rigidbody2D _rigidbody;

        public IAttacker Attacker { get; private set; }
        public IProjectileStats Stats => _stats;

        void Awake()
        {
            _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
            _collider2D = GetComponent<Collider2D>();
            _rigidbody = GetComponent<Rigidbody2D>();
            Attacker = new Attacker(_stats);
            _mover = new ProjectileRigidbodyMovement(this);
            _dying = new DyingWithDestroy(this);
        }

        void Update()
        {
            if (_isOnTrigger) return;
            
            TimeToDie();
            _mover.Tick();
        }

        void FixedUpdate()
        {
            if (_isOnTrigger) return;
            
            _mover.FixedTick();
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            StartCoroutine(DyingAsync());
        }

        IEnumerator DyingAsync()
        {
            _isOnTrigger = true;

            _rigidbody.velocity = Vector2.zero;
            _collider2D.enabled = false;
            _spriteRenderer.sprite = _stats.CollisionSprite;

            yield return new WaitForSeconds(0.2f);
            
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