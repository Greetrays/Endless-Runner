using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float _delaySeconds;
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private Transform[] _spawnPoints;

    private float _elepsedTime;

    private void Update()
    {
        _elepsedTime += Time.deltaTime;

        if (_elepsedTime >= _delaySeconds)
        {
            _elepsedTime = 0;

            int spawnPointNumber = Random.Range(0, _spawnPoints.Length);

            Instantiate(_enemyPrefab, _spawnPoints[spawnPointNumber]);
        }
    }
}
