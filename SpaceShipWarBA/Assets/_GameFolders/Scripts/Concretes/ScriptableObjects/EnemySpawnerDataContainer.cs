using SpaceShipWarBa.Abstracts.Controllers;
using SpaceShipWarBa.Controllers;
using UnityEngine;

namespace SpaceShipWarBa.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Enemy Spawner Data Container",menuName = "Bilge Adam/Data Container/Enemy Spawner Data")]
    public class EnemySpawnerDataContainer : ScriptableObject
    {
        [SerializeField] EnemyController _enemyPrefab;
        [Range(0.5f, 5f)] [SerializeField] float _minTime = 1f;
        [Range(3f, 10f)] [SerializeField] float _maxTime = 5f;

        public float RandomTime => Random.Range(_minTime, _maxTime);
        public EnemyController EnemyPrefab => _enemyPrefab;
    }    
}

