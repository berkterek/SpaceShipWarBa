using SpaceShipWarBa.Abstracts.DataContainers;
using UnityEngine;

namespace SpaceShipWarBa.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Projectile Stats",menuName = "Bilge Adam/Stats/Projectile Stats")]
    public class ProjectileStatsSO : ScriptableObject, IProjectileStats
    {
        [SerializeField] float _moveSpeed = 10f;
        [SerializeField] int _direction = 1;
        [SerializeField] float _maxTime = 5f;

        public float MoveSpeed => _moveSpeed;
        public float MaxTime => _maxTime;
        public int Direction => _direction;
    }    
}

