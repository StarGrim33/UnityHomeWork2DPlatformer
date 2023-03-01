using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawn : MonoBehaviour
{
    [SerializeField] private Coin _template;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private int _count;

    private Coroutine _coroutine;
    private int _time = 2;
    private bool _spawning = false;
    private List<Vector2> _spawnedCoinsPoints = new List<Vector2>();

    private void Start()
    {
        StartCoinSpawn(_count);
    }

    private IEnumerator Spawn()
    {
        _spawning = true;
        int coinsSpawned = 0;

        while (coinsSpawned < _count)
        {
            int spawnIndex = Random.Range(0, _spawnPoints.Length);
            Vector2 spawnPosition = _spawnPoints[spawnIndex].position;

            if (_spawnedCoinsPoints.Contains(spawnPosition) == false)
            {
                Instantiate(_template, spawnPosition, Quaternion.identity);
                _spawnedCoinsPoints.Add(spawnPosition);
                coinsSpawned++;
            }

            yield return new WaitForSeconds(_time);
        }

        _spawning = false;
    }

    private void StartCoinSpawn(int amount)
    {
        _count = amount;
        _coroutine = StartCoroutine(Spawn());
    }
}
