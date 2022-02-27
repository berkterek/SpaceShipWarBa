using UnityEngine;

namespace SpaceShipWarBa.Abstracts.DataContainers
{
    public interface IPlayerStats
    {
        float MoveSpeed { get; }
        float HorizontalBorder { get; }
        public float VerticalUpBorder { get; }
        public float VerticalDownBorder { get; }
        Sprite[] Sprites { get; }
    }
}