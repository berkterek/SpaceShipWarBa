namespace SpaceShipWarBa.Abstracts.DataContainers
{
    public interface IEnemyStats : ICharacterStats
    {
        int ScoreValue { get; }
    }
}