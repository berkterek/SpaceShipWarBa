using SpaceShipWarBa.Abstracts.Controllers;
using SpaceShipWarBa.Abstracts.DataContainers;
using SpaceShipWarBa.Abstracts.Movements;
using SpaceShipWarBa.Movements;
using SpaceShipWarBa.ScriptableObjects;
using UnityEngine;

namespace SpaceShipWarBa.Controllers
{
    public class EnemyController : BaseCharacterController, IEnemyController
    {
        [SerializeField] GameObject _path;
        [SerializeField] EnemyStatsSO _stats;

        public IEnemyStats Stats => _stats;
        IEnemyMover _mover;

        void Awake()
        {
            AwakeProcess(this, _stats, _stats);
            _mover = new EnemyTranslateMovement(this,_path);
        }

        protected override void OnEnable()
        {
            base.OnEnable();
            _mover.OnEndOfPaths += HandleOnDead;
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
            
        }
    }
}