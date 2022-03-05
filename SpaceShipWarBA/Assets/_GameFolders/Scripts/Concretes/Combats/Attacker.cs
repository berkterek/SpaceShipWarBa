using SpaceShipWarBa.Abstracts.Combats;

namespace SpaceShipWarBa.Combats
{
    public class Attacker : IAttacker 
    {
        public int Damage { get; }

        public Attacker()
        {
            Damage = 10;
        }
    }    
}