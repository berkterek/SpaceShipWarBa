using SpaceShipWarBa.Abstracts.Controllers;
using SpaceShipWarBa.Abstracts.Movements;
using UnityEngine;

namespace SpaceShipWarBa.Movements
{
    public class PlayerTranslateMovement : IMover
    {
        readonly IPlayerController _playerController;
        readonly Transform _transform;
        Vector2 _direction;
        

        public PlayerTranslateMovement(IPlayerController playerController)
        {
            _playerController = playerController;
            _transform = _playerController.transform;
        }

        public void Tick()
        {
            _direction = _playerController.InputReader.Direction;
        }

        public void FixedTick()
        {
            //_playerController.GetComponent<Transform>().Translate(_direction * (Time.deltaTime * _playerController.Stats.MoveSpeed));
            //_playerController.transform.Translate(_direction * (Time.deltaTime * _playerController.Stats.MoveSpeed));
            _transform.Translate(_direction * Time.deltaTime * _playerController.Stats.MoveSpeed);

            //Mathf unity matematik class'idir unity developerlar tarafindan yazilmis bir class'tir kopleke matemeakt islmelerini bizim icin hazir yapar
            //Clamp method'u bizden uc parametre ister birinsi degerin kendisi ikincisi minimum donus degeri ucuncudusu maxsimim donus degeridir min ve max lari gecmesek deger olarak bize degerin kendisini doner eger min veya max'î gecersek bize bu min veya max degerin kendisini doner
            Vector3 transformPosition = _transform.position;
            float xPosition = Mathf.Clamp(
                transformPosition.x, 
                -_playerController.Stats.HorizontalBorder,
                _playerController.Stats.HorizontalBorder
                );

            float yPosition = Mathf.Clamp(
                transformPosition.y,
                _playerController.Stats.VerticalDownBorder,
                _playerController.Stats.VerticalUpBorder
            );

            _transform.position = new Vector3(xPosition, yPosition, 0f);
        }
    }
}