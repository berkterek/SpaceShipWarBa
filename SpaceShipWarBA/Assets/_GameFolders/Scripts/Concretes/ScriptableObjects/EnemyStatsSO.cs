using SpaceShipWarBa.Abstracts.DataContainers;
using SpaceShipWarBa.Abstracts.ScriptableObjects;
using UnityEngine;

namespace SpaceShipWarBa.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Enemy Stats",menuName = "Bilge Adam/Stats/Enemy Stats")]
    public class EnemyStatsSO : CharacterStats, IEnemyStats
    {
        [Header("Combats")] [Range(0.1f, 5f)] [SerializeField]
        float _maxFireRate = 3f;

        public override float FireRate => Random.Range(_fireRate, _maxFireRate);
    }
}