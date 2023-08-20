using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsSpawner : MonoBehaviour
{
    [SerializeField] private GameObject obstaclePrefab;
    [SerializeField] private float minDistanceToSpawn = 10;
    [SerializeField] private float maxDistanceToSpawn = 30;
    [SerializeField] private int coinCountToIncreaseSpawn;

    private Vector2 _previuousPlayerPosition;
    private float _distanceToSpawnNext;

    private LevelData _levelData;
    private CoinCollector _coinCollector;

    private void Start()
    {
        _levelData = FindObjectOfType<LevelData>();
        _coinCollector = FindObjectOfType<CoinCollector>();

        _previuousPlayerPosition = _levelData.GetPlayerPosition();
        _distanceToSpawnNext = Random.Range(minDistanceToSpawn, maxDistanceToSpawn);
    }

    private void Update()
    {
        if (Vector3.Distance(_levelData.GetPlayerPosition(), _previuousPlayerPosition) < _distanceToSpawnNext)
            return;

        SpawnObject(1);
    }

    private void SpawnObject(int count)
    {
        _previuousPlayerPosition = _levelData.GetPlayerPosition();
        _distanceToSpawnNext = Random.Range(minDistanceToSpawn, maxDistanceToSpawn);
        Instantiate(obstaclePrefab, new Vector3(_previuousPlayerPosition.x + 30, Random.Range(_levelData.GetDownLimit().y + 4, _levelData.GetUpLimit().y - 4), 0), Quaternion.identity);

        if (coinCountToIncreaseSpawn > 0 && GetSpawnCountWithCurrentCoins() > count)
            SpawnObject(count + 1);
    }

    private int GetSpawnCountWithCurrentCoins()
    {
        return _coinCollector.GetCollectedCount() == 1 ? 2 : _coinCollector.GetCollectedCount() + 1 / coinCountToIncreaseSpawn;
    }
}
