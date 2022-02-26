using SpaceShipWarBa.Abstracts.Movements;
using SpaceShipWarBa.Controllers;
using UnityEngine;

namespace SpaceShipWarBa.Movements
{
    public class PlayerTransformMovement : IMover
    {
        readonly PlayerController _playerController;
        Vector2 _direction;
        
        public PlayerTransformMovement(PlayerController playerController)
        {
            _playerController = playerController;
        }
        
        public void Tick()
        {
            _direction = _playerController.InputReader.Direction;
        }

        public void FixedTick()
        {
            //yurutme
            _playerController.transform.position += (Vector3)_direction * Time.deltaTime;
        }
    }
}