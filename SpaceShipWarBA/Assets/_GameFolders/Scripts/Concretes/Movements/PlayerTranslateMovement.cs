using SpaceShipWarBa.Abstracts.Movements;
using SpaceShipWarBa.Controllers;
using UnityEngine;

namespace SpaceShipWarBa.Movements
{
    public class PlayerTranslateMovement : IMover
    {
        readonly PlayerController _playerController;
        Vector2 _direction;

        public PlayerTranslateMovement(PlayerController playerController)
        {
            _playerController = playerController;
        }

        public void Tick()
        {
            _direction = _playerController.InputReader.Direction;
        }

        public void FixedTick()
        {
            _playerController.transform.Translate(_direction * Time.deltaTime);
        }
    }
}