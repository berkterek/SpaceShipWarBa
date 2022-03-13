using SpaceShipWarBa.Abstracts.Controllers;
using SpaceShipWarBa.Abstracts.DataContainers;
using SpaceShipWarBa.Abstracts.Movements;
using SpaceShipWarBa.Managers;
using SpaceShipWarBa.Movements;
using SpaceShipWarBa.ScriptableObjects;
using UnityEngine;

namespace SpaceShipWarBa.Controllers
{
    public class EnemyController : BaseCharacterController, IEnemyController
    {
        [SerializeField] EnemyStatsSO _stats;

        public IEnemyStats Stats => _stats;

        IEnemyMover _mover;
        float _currentDelayTime;

        void Awake()
        {
            AwakeProcess(this, _stats, _stats);
        }

        void Start()
        {
            _currentDelayTime = _stats.FireRate;
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            _mover.OnEndOfPaths -= HandleOnDead;
        }

        protected override void Update()
        {
            _mover.Tick();
            base.Update();
        }

        void FixedUpdate()
        {
            _mover.FixedTick();
        }

        protected override void FireProcess()
        {
            _currentAttackTime += Time.deltaTime;
            if (_currentAttackTime > _currentDelayTime)
            {
                _currentDelayTime = _stats.FireRate;
                _currentAttackTime = 0f;
                Instantiate(_stats.Projectile, transform.position, Quaternion.identity);
            }
        }

        public void SetPath(GameObject path)
        {
            _mover = new EnemyTranslateMovement(this, path);
            _mover.OnEndOfPaths += _dying.DyingAction;
        }

        protected override void HandleOnDead()
        {
            if (GameManager.Instance != null)
            {
                GameManager.Instance.SetScore(_stats.ScoreValue);    
            }
            
            base.HandleOnDead();
        }
    }
}