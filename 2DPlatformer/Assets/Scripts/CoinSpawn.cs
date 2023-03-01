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

    private void Start()
    {
        StartCoinSpawn(10);
    }

    private IEnumerator Spawn()
    {
        _spawning = true;
        int coinsSpawned = 0;

        while (coinsSpawned < _count)
        {
            int spawnIndex = Random.Range(0, _spawnPoints.Length);
            Instantiate(_template, _spawnPoints[spawnIndex].position, Quaternion.identity);
            coinsSpawned++;
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
