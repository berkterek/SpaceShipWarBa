using SpaceShipWarBa.Abstracts.DataContainers;
using SpaceShipWarBa.Abstracts.ScriptableObjects;
using SpaceShipWarBa.Controllers;
using UnityEngine;

namespace SpaceShipWarBa.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Player Stats",menuName = "Bilge Adam/Stats/Player Stats")]
    public class PlayerStatsSO : CharacterStats, IPlayerStats
    {
        [Header("Animations")] 
        [SerializeField] Sprite[] _sprites;
        
        [Header("Movements")]
        [SerializeField] float _moveSpeed;
        [SerializeField] float _horizontalBorder = 2f;
        [SerializeField] float _verticalUpBorder = 1f;
        [SerializeField] float _verticalDownBorder = -5f;

        [Header("Combats")]
        [Range(0.1f,5f)]
        [SerializeField] float _fireRate = 0.3f;
        [SerializeField] ProjectileController _projectile;

        public float MoveSpeed => _moveSpeed;
        public float HorizontalBorder => _horizontalBorder;
        public float VerticalUpBorder => _verticalUpBorder;
        public float VerticalDownBorder => _verticalDownBorder;
        public Sprite[] Sprites => _sprites;
        
        public float FireRate => _fireRate;
        public ProjectileController Projectile => _projectile;
    }
}