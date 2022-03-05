using System;
using SpaceShipWarBa.Abstracts.Combats;
using SpaceShipWarBa.Abstracts.Controllers;
using SpaceShipWarBa.Combats;
using UnityEngine;

namespace SpaceShipWarBa.Controllers
{
    public class EnemyController : MonoBehaviour,IHealthController
    {
        public IHealth Health { get; private set; }

        void Awake()
        {
            Health = new Health();
        }

        public void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.TryGetComponent(out IAttackerController attackerController)) return;
            
            Health.TakeDamage(attackerController.Attacker);
        }
    }    
}

