using SpaceShipWarBa.Abstracts.Combats;
using SpaceShipWarBa.Abstracts.ScriptableObjects;

namespace SpaceShipWarBa.Combats
{
    public class CharacterHealth : IHealth
    {
        int _currentHealth;
        bool IsDead => _currentHealth <= 0; 

        //Yapici method ile biz current health'i belirleriz
        public CharacterHealth(CharacterStats stats)
        {
            _currentHealth = stats.MaxHealth;
        }

        public void TakeDamage(IAttacker attacker)
        {
            if (IsDead) return;

                //attacker bizim current health'imize zarar veriyor
            _currentHealth -= attacker.Damage;

            if (IsDead)
            {
                //dying
            }
        }
    }
}