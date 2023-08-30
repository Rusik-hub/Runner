using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealKitSpawner : ObjectPool
{
    [SerializeField] private List<GameObject> _prefabs;
    [SerializeField] private List<HealKitSpawnPoint> _points;

    private float _minTimeForSpawn = 3;
    private float _maxTimeForSpawn = 5;

    private Coroutine _waitingCoroutine;

    private void Start()
    {
        FillPull(_prefabs);

        _waitingCoroutine = StartCoroutine(CreateKit());
    }

    private IEnumerator CreateKit()
    {
        var timer = new WaitForSeconds(Random.Range(_minTimeForSpawn, _maxTimeForSpawn));
        int prefabIndex = Random.Range(0, _prefabs.Count);
        int pointIndex = Random.Range(0, _points.Count);

        yield return timer;

        UnshowAllObjects();

        if (TryGetObject(out GameObject result, prefabIndex))
        {
            result.transform.position = _points[pointIndex].transform.position;
            result.SetActive(true);
        }

        _waitingCoroutine = StartCoroutine(CreateKit());
    }
}
