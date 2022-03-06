using SpaceShipWarBa.Controllers;
using UnityEngine;

namespace SpaceShipWarBa.Abstracts.ScriptableObjects
{
    public abstract class CharacterStats : AttackerStats
    {
        [Header("Movements")]
        [SerializeField] float _moveSpeed;
        
        [Header("Combats")]
        [Tooltip("This line is character's max health")]
        [SerializeField] int _maxHealth = 100;
        [Range(0.1f,5f)]
        [SerializeField] float _fireRate = 0.3f;
        [SerializeField] ProjectileController _projectile;
        
        public float MoveSpeed => _moveSpeed;
        public float FireRate => _fireRate;
        public ProjectileController Projectile => _projectile;
        
        public int MaxHealth => _maxHealth;
    }
}