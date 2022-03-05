using UnityEngine;

namespace SpaceShipWarBa.Abstracts.DataContainers
{
    public interface IPlayerStats
    {
        float MoveSpeed { get; }
        float HorizontalBorder { get; }
        float VerticalUpBorder { get; }
        float VerticalDownBorder { get; }
        Sprite[] Sprites { get; }
        int MaxHealth { get; }
        int MaxDamage { get; }
        float FireRate { get; }
    }
}