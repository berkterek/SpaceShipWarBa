using SpaceShipWarBa.Abstracts.Combats;
using SpaceShipWarBa.Abstracts.DataContainers;

namespace SpaceShipWarBa.Combats
{
    public class CharacterHealth : IHealth
    {
        readonly int _maxHealth;
        int _currentHealth;
        bool IsDead => _currentHealth <= 0;
        public event System.Action OnDead;
        public event System.Action<int, int> OnTookDamage;

        //Yapici method ile biz current health'i belirleriz
        public CharacterHealth(ICharacterStats stats)
        {
            _currentHealth = stats.MaxHealth;
            _maxHealth = stats.MaxHealth;
        }

        public void TakeDamage(IAttacker attacker)
        {
            if (IsDead) return;

                //attacker bizim current health'imize zarar veriyor
            _currentHealth -= attacker.Damage;
            OnTookDamage?.Invoke(_currentHealth,_maxHealth);

            if (IsDead)
            {
                OnDead?.Invoke();
                // if (OnDead != null)
                // {
                //     OnDead.Invoke();
                // }
            }
        }
    }
}