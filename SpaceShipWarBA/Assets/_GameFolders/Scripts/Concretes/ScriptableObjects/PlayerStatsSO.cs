using SpaceShipWarBa.Abstracts.DataContainers;
using UnityEngine;

namespace SpaceShipWarBa.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Player Stats",menuName = "Bilge Adam/Stats/Player Stats")]
    public class PlayerStatsSO : ScriptableObject, IPlayerStats
    {
        [Header("Animations")] 
        [SerializeField] Sprite[] _sprites;
        
        [Header("Movements")]
        [SerializeField] float _moveSpeed;
        [SerializeField] float _horizontalBorder = 2f;
        [SerializeField] float _verticalUpBorder = 1f;
        [SerializeField] float _verticalDownBorder = -5f;

        [Header("Combats")] 
        [Tooltip("This line is character's max health")]
        [SerializeField] int _maxHealth = 100;
        [SerializeField] int _maxDamage = 10;
        [Range(0.1f,5f)]
        [SerializeField] float _fireRate = 0.3f;

        public float MoveSpeed => _moveSpeed;
        public float HorizontalBorder => _horizontalBorder;
        public float VerticalUpBorder => _verticalUpBorder;
        public float VerticalDownBorder => _verticalDownBorder;
        public Sprite[] Sprites => _sprites;
        public int MaxHealth => _maxHealth;
        public int MaxDamage => _maxDamage;
        public float FireRate => _fireRate;
    }
}