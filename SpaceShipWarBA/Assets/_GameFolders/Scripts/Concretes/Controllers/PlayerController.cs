using SpaceShipWarBa.Abstracts.Animations;
using SpaceShipWarBa.Abstracts.Controllers;
using SpaceShipWarBa.Abstracts.DataContainers;
using SpaceShipWarBa.Abstracts.Inputs;
using SpaceShipWarBa.Abstracts.Movements;
using SpaceShipWarBa.Animations;
using SpaceShipWarBa.Inputs;
using SpaceShipWarBa.Managers;
using SpaceShipWarBa.Movements;
using SpaceShipWarBa.ScriptableObjects;
using SpaceShipWarBa.Sounds;
using UnityEngine;

namespace SpaceShipWarBa.Controllers
{
    public class PlayerController : BaseCharacterController, IPlayerController
    {
        [SerializeField] PlayerStatsSO _stats;
        [SerializeField] TwoIntParametreEventHandlerSO _healthEvent;

        IAnimation _animation;
        IMover _mover;

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
            _sound = new AudioSourceSoundPlayer(this, _stats);
        }

        protected override void Update()
        {
            _mover.Tick();
            base.Update();
        }

        void LateUpdate()
        {
            _mover.FixedTick();
            _animation.LateTick();
        }

        protected override void FireProcess()
        {
            _currentAttackTime += Time.deltaTime;

            if (_currentAttackTime > _stats.FireRate)
            {
                _currentAttackTime = 0f;
                Instantiate(_stats.Projectile, transform.position, Quaternion.identity);
                _sound.LaserSound();
            }
        }

        protected override void HandleOnTookDamage(int currentHealth, int maxHealth)
        {
            base.HandleOnTookDamage(currentHealth, maxHealth);
            _healthEvent.TwoIntEventHandler(currentHealth,maxHealth);
        }

        protected override void HandleOnDead()
        {
            GameManager.Instance.GameOverProcess();
            _sound.DeadSound();
            base.HandleOnDead();
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