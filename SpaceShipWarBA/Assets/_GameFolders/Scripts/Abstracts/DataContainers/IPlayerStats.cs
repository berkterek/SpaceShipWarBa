using UnityEngine;

namespace SpaceShipWarBa.Abstracts.DataContainers
{
    public interface IPlayerStats : ICharacterStats
    {
        float HorizontalBorder { get; }
        float VerticalUpBorder { get; }
        float VerticalDownBorder { get; }
        Sprite[] Sprites { get; }
        AudioClip LaserSound { get; }
    }
}