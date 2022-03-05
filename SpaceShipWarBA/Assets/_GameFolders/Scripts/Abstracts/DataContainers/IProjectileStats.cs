namespace SpaceShipWarBa.Abstracts.DataContainers
{
    public interface IProjectileStats
    {
        float MoveSpeed { get; }
        float MaxTime { get; }
        int Direction { get; }
    }
}