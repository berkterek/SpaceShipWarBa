using UnityEngine;

namespace SpaceShipWarBa.Abstracts.DataContainers
{
    public interface ICharacterStats
    {
        float MoveSpeed { get; }
        int MaxHealth { get; }
        int MaxDamage { get; }
        float FireRate { get; }
        AudioClip LaserSound { get; }
        public AudioClip DeadSound { get; }
    }
}