using SpaceShipWarBa.Abstracts.Animations;
using SpaceShipWarBa.Abstracts.Controllers;
using UnityEngine;

namespace SpaceShipWarBa.Animations
{
    public class PlayerAnimation : IAnimation
    {
        readonly IPlayerController _playerController;
        readonly SpriteRenderer _spriteRenderer;
        
        public PlayerAnimation(IPlayerController playerController)
        {
            _playerController = playerController;
            _spriteRenderer = _playerController.transform.GetComponentInChildren<SpriteRenderer>();
        }
        
        public void LateTick()
        {
            DirectionAnimationPlay();
        }

        void DirectionAnimationPlay()
        {
            if (_playerController.InputReader.Direction.x < 0)
            {
                //left
                _spriteRenderer.sprite = _playerController.Stats.Sprites[1];
            }
            else if (_playerController.InputReader.Direction.x > 0)
            {
                //right
                _spriteRenderer.sprite = _playerController.Stats.Sprites[2];
            }
            else
            {
                //forward
                _spriteRenderer.sprite = _playerController.Stats.Sprites[0];
            }
        }
    }    
}

