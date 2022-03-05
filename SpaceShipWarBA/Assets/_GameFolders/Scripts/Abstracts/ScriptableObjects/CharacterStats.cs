using UnityEngine;

namespace SpaceShipWarBa.Abstracts.ScriptableObjects
{
    public abstract class CharacterStats : AttackerStats
    {
        [Tooltip("This line is character's max health")]
        [SerializeField] int _maxHealth = 100;
        
        public int MaxHealth => _maxHealth;
    }
}