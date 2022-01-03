using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : ObjectPool
{
    [SerializeField] private float _delaySeconds;
    [SerializeField] private GameObject _prefab;
    [SerializeField] private Transform[] _spawnPoints;

    private float _elepsedTime;

    private void Start()
    {
        Initialized(_prefab);
    }

    private void Update()
    {
        _elepsedTime += Time.deltaTime;

        if (TryGetObject(out GameObject obj))
        {
            if (_elepsedTime >= _delaySeconds)
            {
                _elepsedTime = 0;

                int spawnPointNumber = Random.Range(0, _spawnPoints.Length);

                SetObject(obj, _spawnPoints[spawnPointNumber]);
            }
        }
    }

    private void SetObject(GameObject obj, Transform spawnPoint)
    {
        obj.SetActive(true);
        obj.transform.position = spawnPoint.position;
    }
}
