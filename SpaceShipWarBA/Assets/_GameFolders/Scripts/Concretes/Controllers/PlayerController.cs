using SpaceShipWarBa.Abstracts.Inputs;
using SpaceShipWarBa.Inputs;
using UnityEngine;

namespace SpaceShipWarBa.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        IInputReader _inputReader;

        void Awake()
        {
            _inputReader = new OldInputReader();
        }

        void Update()
        {
            Debug.Log(_inputReader.Direction);
        }

        //
        [ContextMenu(nameof(SetNewInput))]
        public void SetNewInput()
        {
            _inputReader = new NewInputReader();
        }
    }    
}