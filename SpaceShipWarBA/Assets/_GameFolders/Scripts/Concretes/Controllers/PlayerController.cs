using SpaceShipWarBa.Abstracts.Animations;
using SpaceShipWarBa.Abstracts.Combats;
using SpaceShipWarBa.Abstracts.Controllers;
using SpaceShipWarBa.Abstracts.DataContainers;
using SpaceShipWarBa.Abstracts.Inputs;
using SpaceShipWarBa.Abstracts.Movements;
using SpaceShipWarBa.Animations;
using SpaceShipWarBa.Combats;
using SpaceShipWarBa.Inputs;
using SpaceShipWarBa.Movements;
using SpaceShipWarBa.ScriptableObjects;
using UnityEngine;

namespace SpaceShipWarBa.Controllers
{
    [RequireComponent(typeof(Collider2D))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerController : MonoBehaviour, IPlayerController
    {
        [SerializeField] PlayerStatsSO _stats;
        
        IMover _mover;
        IAnimation _animation;
        IHealth _health;

        public IInputReader InputReader { get; private set; }
        public IPlayerStats Stats => _stats;
        public IAttacker Attacker { get; private set; }
        public IHealth Health { get; private set; }

        float _currentAttackTime = 0f;
        
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
            Health = new Health();
            Attacker = new Attacker();
        }

        void Update()
        {
            _mover.Tick();

            FireProcess();
        }

        void FixedUpdate()
        {
            //yurume islemlerini yapiyoruz fizik
            _mover.FixedTick();
        }

        void LateUpdate()
        {
            _animation.LateTick();
        }
        
        public void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.TryGetComponent(out IAttackerController attackerController)) return;
            
            Health.TakeDamage(attackerController.Attacker);
        }

        private void FireProcess()
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