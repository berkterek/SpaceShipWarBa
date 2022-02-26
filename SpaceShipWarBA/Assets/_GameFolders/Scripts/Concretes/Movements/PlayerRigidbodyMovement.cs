using SpaceShipWarBa.Abstracts.Movements;
using SpaceShipWarBa.Controllers;
using UnityEngine;

namespace SpaceShipWarBa.Movements
{
    public class PlayerRigidbodyMovement : IMover
    {
        readonly PlayerController _playerController;
        readonly Rigidbody2D _rigidbody2D;
        
        Vector2 _direction;
        
        public PlayerRigidbodyMovement(PlayerController playerController)
        {
            _playerController = playerController;
            _rigidbody2D = playerController.GetComponent<Rigidbody2D>();
        }
        
        public void Tick()
        {
            _direction = _playerController.InputReader.Direction;
        }

        public void FixedTick()
        {
            _rigidbody2D.velocity = _direction * Time.deltaTime;
            //_rigidbody2D.velocity = _direction * Time.deltaTime;
        }
    }
}