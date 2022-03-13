using SpaceShipWarBa.Abstracts.DataContainers;
using SpaceShipWarBa.Abstracts.ScriptableObjects;
using UnityEngine;

namespace SpaceShipWarBa.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Projectile Stats",menuName = "Bilge Adam/Stats/Projectile Stats")]
    public class ProjectileStatsSO : AttackerStats, IProjectileStats
    {
        [SerializeField] float _moveSpeed = 10f;
        [SerializeField] int _direction = 1;
        [SerializeField] float _maxTime = 5f;
        [SerializeField] Sprite _collisionSprite;

        public float MoveSpeed => _moveSpeed;
        public float MaxTime => _maxTime;
        public int Direction => _direction;
        public Sprite CollisionSprite => _collisionSprite;
    }    
}