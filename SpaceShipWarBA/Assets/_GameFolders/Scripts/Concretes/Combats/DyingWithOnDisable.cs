using SpaceShipWarBa.Abstracts.Combats;
using SpaceShipWarBa.Abstracts.Controllers;
using UnityEngine;

namespace SpaceShipWarBa.Combats
{
    public class DyingWithOnDisable : IDying
    {
        readonly Transform _transform;
        
        public DyingWithOnDisable(IEntityController entityController)
        {
            _transform = entityController.transform;
        }
        
        public void DyingAction()
        {
            _transform.gameObject.SetActive(false);
        }
    }
}