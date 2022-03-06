using SpaceShipWarBa.Abstracts.DataContainers;
using SpaceShipWarBa.Abstracts.ScriptableObjects;
using UnityEngine;

namespace SpaceShipWarBa.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Enemy Stats",menuName = "Bilge Adam/Stats/Enemy Stats")]
    public class EnemyStatsSO : CharacterStats, IEnemyStats
    {
        
    }
}