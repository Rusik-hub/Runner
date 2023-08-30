using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealKitSpawner : ObjectPool
{
    [SerializeField] private List<GameObject> _prefabs;
    [SerializeField] private List<HealKitSpawnPoint> _points;
    [SerializeField] private Parallax _parallax;

    private float _minTimeForSpawn = 10;
    private float _maxTimeForSpawn = 20;
    private bool _canSpawn = false;

    private Coroutine _waitingCoroutine;

    private void OnEnable()
    {
        _parallax.TargetPositionAchieved += TryCreateKit;
    }

    private void Start()
    {
        FillPull(_prefabs);

        _waitingCoroutine = StartCoroutine(StartTimer());
    }

    private void OnDisable()
    {
        _parallax.TargetPositionAchieved -= TryCreateKit;
    }

    private IEnumerator StartTimer()
    {
        var timer = new WaitForSeconds(Random.Range(_minTimeForSpawn, _maxTimeForSpawn));
        
        yield return timer;

        _canSpawn = true;
        _waitingCoroutine = StartCoroutine(StartTimer());
    }

    private void TryCreateKit()
    {
        UnshowAllObjects();

        if (_canSpawn)
        {
            int prefabIndex = Random.Range(0, _prefabs.Count);
            int pointIndex = Random.Range(0, _points.Count);

            if (TryGetObject(out GameObject result, prefabIndex))
            {
                result.transform.position = _points[pointIndex].transform.position;
                result.SetActive(true);

                _canSpawn = false;
            }
        }
    }
}
