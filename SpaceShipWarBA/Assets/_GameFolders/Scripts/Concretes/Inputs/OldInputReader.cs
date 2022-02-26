using SpaceShipWarBa.Abstracts.Inputs;
using UnityEngine;

namespace SpaceShipWarBa.Inputs
{
    public class OldInputReader : IInputReader
    {
        public Vector2 Direction
        {
            get
            {
                float x = Input.GetAxis("Horizontal");
                float y = Input.GetAxis("Vertical");

                Vector2 direction = new Vector2(x, y);
                return direction.normalized;
            }
        }
    }    
}
