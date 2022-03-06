using System;
using SpaceShipWarBa.Abstracts.Controllers;
using SpaceShipWarBa.Abstracts.DataContainers;
using SpaceShipWarBa.Combats;
using SpaceShipWarBa.ScriptableObjects;
using UnityEngine;

namespace SpaceShipWarBa.Controllers
{
    public class EnemyController : BaseCharacterController, IEnemyController
    {
        [SerializeField] EnemyStatsSO _stats;

        public IEnemyStats Stats => _stats;

        void Awake()
        {
            AwakeProcess(this, _stats, _stats);
        }

        protected override void FireProcess()
        {
        }
    }
}