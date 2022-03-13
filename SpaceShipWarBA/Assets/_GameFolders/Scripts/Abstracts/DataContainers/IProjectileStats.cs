using UnityEngine;

namespace SpaceShipWarBa.Abstracts.DataContainers
{
    public interface IProjectileStats
    {
        float MoveSpeed { get; }
        float MaxTime { get; }
        int Direction { get; }
        Sprite CollisionSprite { get; } 
    }
}