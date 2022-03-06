using SpaceShipWarBa.Abstracts.Animations;
using SpaceShipWarBa.Abstracts.Controllers;
using SpaceShipWarBa.Abstracts.DataContainers;
using SpaceShipWarBa.Abstracts.Inputs;
using SpaceShipWarBa.Animations;
using SpaceShipWarBa.Combats;
using SpaceShipWarBa.Inputs;
using SpaceShipWarBa.Movements;
using SpaceShipWarBa.ScriptableObjects;
using UnityEngine;

namespace SpaceShipWarBa.Controllers
{
    public class PlayerController : BaseCharacterController, IPlayerController
    {
        [SerializeField] PlayerStatsSO _stats;

        IAnimation _animation;

        public IInputReader InputReader { get; private set; }
        public IPlayerStats Stats => _stats;

        void Awake()
        {
            #region IInputReader ornek anlatim icin

            //eski input systemde calistirip yeni input sisteme calisma zamani gecirmek icin yazilmis bir ornek
            //_inputReader = new OldInputReader();

            #endregion

            InputReader = new NewInputReader();
            //burdaki this anlami bu class'in kendisi demektir
            _mover = new PlayerTranslateMovement(this);
            _animation = new PlayerAnimation(this);

            AwakeProcess(this, _stats, _stats);
        }

        void LateUpdate()
        {
            _animation.LateTick();
        }

        protected override void FireProcess()
        {
            _currentAttackTime += Time.deltaTime;

            //Fire Process
            if (_currentAttackTime > _stats.FireRate)
            {
                _currentAttackTime = 0f;
                Instantiate(_stats.Projectile, transform.position, Quaternion.identity);
            }
        }

        #region IInputReader ornek anlatim

        //calisma zmaamni eski input sistemden yeni input sisteme gecirdik yazdigimz kod bu kadar esnek bir yapidir
        // [ContextMenu(nameof(SetNewInput))]
        // public void SetNewInput()
        // {
        //     _inputReader = new NewInputReader();
        // }

        #endregion
    }
}