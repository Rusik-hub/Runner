using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierSpawner : ObjectPool
{
    [SerializeField] private List<SpawnPointBarrier> _points;
    [SerializeField] private List<GameObject> _prefabs;

    private int _barriersOneTypeCount = 2;
    private int _shiftIndex = 1;
    private int _spawnPointsCount;
    private int _prefabsCount;

    private void Start()
    {
        _spawnPointsCount = _points.Count - _shiftIndex;
        _prefabsCount = _prefabs.Count;

        AddPoints();
        FillPull();
    }

    public void UpdateBarriersState()
    {
        UnshowAllObjects();
        ShowRandomBarriers();
    }

    private void ShowRandomBarriers()
    {
        int firstBarrierPoint = Random.Range(0, _spawnPointsCount);
        int secondBarrierPoint = Random.Range(0, _spawnPointsCount);
        int firstBarrierIndex = Random.Range(0, _prefabsCount);
        int secondBarrierIndex = Random.Range(0, _prefabsCount);

        while (secondBarrierPoint == firstBarrierPoint)
            secondBarrierPoint = Random.Range(0, _spawnPointsCount);

        while (secondBarrierIndex == firstBarrierIndex)
            secondBarrierIndex = Random.Range(0, _prefabsCount);

        if (TryGetObject(out GameObject firstResult, firstBarrierIndex))
        {
            firstResult.transform.position = _points[firstBarrierPoint].transform.position;
            firstResult.SetActive(true);
        }

        if (TryGetObject(out GameObject secondResult, secondBarrierIndex))
        {
            secondResult.transform.position = _points[secondBarrierPoint].transform.position;
            secondResult.SetActive(true);
        }
    }

    private void AddPoints()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            _points.Add(this.gameObject.transform.GetChild(i).GetComponent<SpawnPointBarrier>());
        }
    }

    private void FillPull()
    {
        for (int i = 0; i < _barriersOneTypeCount; i++)
        {
            for (int j = 0; j < _prefabs.Count; j++)
            {
                Initialize(_prefabs[j]);
            }
        }
    }
}
