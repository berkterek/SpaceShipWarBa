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
        [SerializeField] float _horizontalBorder = 2f;
        [SerializeField] float _verticalUpBorder = 1f;
        [SerializeField] float _verticalDownBorder = -5f;

        [Header("Sounds")] 
        [SerializeField] AudioClip _laserSound;
        [SerializeField] AudioClip _deadSound;

        public float HorizontalBorder => _horizontalBorder;
        public float VerticalUpBorder => _verticalUpBorder;
        public float VerticalDownBorder => _verticalDownBorder;
        public Sprite[] Sprites => _sprites;
        public AudioClip LaserSound => _laserSound;
        public AudioClip DeadSound => _deadSound;
    }
}