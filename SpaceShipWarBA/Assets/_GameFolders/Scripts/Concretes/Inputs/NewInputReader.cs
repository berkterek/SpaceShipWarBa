using SpaceShipWarBa.Abstracts.Inputs;
using UnityEngine;
using UnityEngine.InputSystem;

namespace SpaceShipWarBa.Inputs
{
    public class NewInputReader : IInputReader
    {
        //get public set private olunca anlami disariya bilgi dondurebilir ama sadece icierinden guncellenir bir veri set edileblir anlamina gelir 
        public Vector2 Direction { get; private set; }

        public NewInputReader()
        {
            GameInput gameInput = new GameInput();
            
            gameInput.Player.Movement.performed += HandleOnMovement;
            gameInput.Player.Movement.canceled += HandleOnMovement;
            
            gameInput.Enable();
        }

        void HandleOnMovement(InputAction.CallbackContext context)
        {
            Direction = context.ReadValue<Vector2>(); //x y
            //Direction = new Vector3(Direction.x, 0f, Direction.y); //x z deger vermis oluyorum
        }
    }
}

