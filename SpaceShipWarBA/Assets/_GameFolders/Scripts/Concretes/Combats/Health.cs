using SpaceShipWarBa.Abstracts.Combats;
using UnityEngine;

namespace SpaceShipWarBa.Combats
{
    public class Health : IHealth
    {
        int _currentHealth;
        bool IsDead => _currentHealth <= 0; 

        //Yapici method ile biz current health'i belirleriz
        public Health()
        {
            _currentHealth = 100;
            Debug.Log(_currentHealth);
        }

        public void TakeDamage(IAttacker attacker)
        {
            if (IsDead) return;

                //attacker bizim current health'imize zarar veriyor
            _currentHealth -= attacker.Damage;
            Debug.Log(_currentHealth);

            if (IsDead)
            {
                //dying
            }
        }
    }
}