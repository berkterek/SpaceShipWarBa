using SpaceShipWarBa.Abstracts.Inputs;
using SpaceShipWarBa.Abstracts.Movements;
using SpaceShipWarBa.Inputs;
using SpaceShipWarBa.Movements;
using UnityEngine;

namespace SpaceShipWarBa.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        IMover _mover;
        
        public IInputReader InputReader { get; private set; }

        void Awake()
        {
            #region IInputReader ornek anlatim icin
            //eski input systemde calistirip yeni input sisteme calisma zamani gecirmek icin yazilmis bir ornek
            //_inputReader = new OldInputReader();
                #endregion
            
            InputReader = new NewInputReader();
            //burdaki this anlami bu class'in kendisi demektir
            _mover = new PlayerTransformMovement(this);
        }

        void Update()
        {
            _mover.Tick();
        }

        void FixedUpdate()
        {
            //yurume islemlerini yapiyoruz fizik
            //this.transform.Translate(_direction * Time.deltaTime);
            _mover.FixedTick();
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