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
        [SerializeField] int _scoreValue = 10;

        [Header("Sounds")] 
        [SerializeField] AudioClip[] _laserSounds;
        [SerializeField] AudioClip _deadSound;
        
        public override float FireRate => Random.Range(_fireRate, _maxFireRate);
        public int ScoreValue => _scoreValue;
        public AudioClip LaserSound => _laserSounds[Random.Range(0, _laserSounds.Length)];
        public AudioClip DeadSound => _deadSound;
        public AudioClip TakeHitSound { get; }
    }
}