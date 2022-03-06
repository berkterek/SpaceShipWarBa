namespace SpaceShipWarBa.Abstracts.Movements
{
    public interface IEnemyMover : IMover
    {
        event System.Action OnEndOfPaths;
    }
}