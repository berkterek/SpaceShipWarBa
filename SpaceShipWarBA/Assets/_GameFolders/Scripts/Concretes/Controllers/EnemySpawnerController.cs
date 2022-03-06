using SpaceShipWarBa.Abstracts.Controllers;
using SpaceShipWarBa.ScriptableObjects;
using UnityEngine;

public class EnemySpawnerController : MonoBehaviour
{
    [SerializeField] EnemySpawnerDataContainer _enemySpawnerDataContainer;
    [SerializeField] Transform _spawnPoint;
    [SerializeField] GameObject _path;

    float _currentTime = 0f;
    float _maxRandomTime = 0f;

    void Start()
    {
        SetRandomMaxTime();
    }

    void Update()
    {
        _currentTime += Time.deltaTime;

        if (_currentTime > _maxRandomTime)
        {
            SetRandomMaxTime();
            IEnemyController newEnemy = Instantiate(_enemySpawnerDataContainer.EnemyPrefab, _spawnPoint.position, _spawnPoint.rotation);
            newEnemy.SetPath(_path);
        }
    }

    private void SetRandomMaxTime()
    {
        _currentTime = 0f;
        _maxRandomTime = _enemySpawnerDataContainer.RandomTime;
    }
}
