using SpaceShipWarBa.Abstracts.Combats;
using SpaceShipWarBa.Abstracts.Controllers;
using UnityEngine;

namespace SpaceShipWarBa.Combats
{
    public class DyingWithDestroy : IDying
    {
        readonly Transform _transform;
        
        public DyingWithDestroy(IEntityController entityController)
        {
            _transform = entityController.transform;
        }
        
        public void DyingAction()
        {
            GameObject.Destroy(_transform.gameObject);
        }
    }
}