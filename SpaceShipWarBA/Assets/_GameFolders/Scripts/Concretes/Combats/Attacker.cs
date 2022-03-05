using SpaceShipWarBa.Abstracts.Combats;
using SpaceShipWarBa.Abstracts.ScriptableObjects;

namespace SpaceShipWarBa.Combats
{
    public class Attacker : IAttacker
    {
        readonly AttackerStats _attackerStats;
        
        public int Damage => _attackerStats.MaxDamage;

        public Attacker(AttackerStats attackerStats)
        {
            _attackerStats = attackerStats;
        }
    }    
}