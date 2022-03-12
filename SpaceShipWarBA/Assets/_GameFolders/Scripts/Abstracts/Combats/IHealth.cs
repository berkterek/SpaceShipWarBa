
namespace SpaceShipWarBa.Abstracts.Combats
{
    public interface IHealth
    {
        void TakeDamage(IAttacker attacker);
        event System.Action OnDead;
        event System.Action<int, int> OnTookDamage;
    }    
}