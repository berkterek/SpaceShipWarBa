using SpaceShipWarBa.Abstracts.DataContainers;
using UnityEngine;

namespace SpaceShipWarBa.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Player Stats",menuName = "Bilge Adam/Stats/Player Stats")]
    public class PlayerStatsSO : ScriptableObject, IPlayerStats
    {
        [SerializeField] float _moveSpeed;
        [SerializeField] float _horizontalBorder = 2f;

        public float MoveSpeed => _moveSpeed;
        public float HorizontalBorder => _horizontalBorder;
    }
}