using UnityEngine;

namespace SpaceShipWarBa.Abstracts.ScriptableObjects
{
    public abstract class AttackerStats : ScriptableObject
    {
        [Header("Combats")]
        [SerializeField] protected int _maxDamage = 10;
        
        public int MaxDamage => _maxDamage;
    }
}