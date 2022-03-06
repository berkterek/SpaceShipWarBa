using SpaceShipWarBa.Abstracts.Controllers;
using SpaceShipWarBa.Abstracts.Movements;
using UnityEngine;

namespace SpaceShipWarBa.Movements
{
    public class EnemyTranslateMovement : IEnemyMover
    {
        readonly IEnemyController _enemyController;
        readonly Transform _thisTransform;
        readonly Transform[] _paths;
        
        Vector3 _direction;
        int _index = 0;
        public event System.Action OnEndOfPaths;

        public EnemyTranslateMovement(IEnemyController enemyController, GameObject path)
        {
            _enemyController = enemyController;
            _thisTransform = _enemyController.transform;

            _paths = new Transform[path.transform.childCount];
            for (int i = 0; i < path.transform.childCount; i++)
            {
                _paths[i] = path.transform.GetChild(i);
                Debug.Log(_paths[i].gameObject.name);
            }

            SetNewIndex();
        }

        public void Tick()
        {
            bool distanceResult = Vector3.Distance(_thisTransform.position,_direction) < 0.1f;

            if (distanceResult)
            {
                _index++;

                if (_index < _paths.Length)
                {
                    SetNewIndex(_index);
                }
                else
                {
                    //End of paths
                    OnEndOfPaths?.Invoke();
                }
            }
        }

        public void FixedTick()
        {
            _thisTransform.position = Vector2.MoveTowards(
                _thisTransform.position,
                _direction,
                _enemyController.Stats.MoveSpeed * Time.deltaTime
            );
        }

        private void SetNewIndex(int index = 0)
        {
            _direction = _paths[index].position;
        }
    }
}