using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShipWarBa.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Player Stats",menuName = "Bilge Adam/Stats/Player Stats")]
    public class PlayerStatsSO : ScriptableObject
    {
        [SerializeField] float _moveSpeed;

        public float MoveSpeed => _moveSpeed;
    }    
}

