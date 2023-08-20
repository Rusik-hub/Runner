using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierSpawner : MonoBehaviour
{
    [SerializeField, Range(0, 10)] private float _delay;
    [SerializeField] private List<BarrierSpawnPoint> _points;
    [SerializeField] private List<Barrier> _barriersPull;

    private int _firstBarrier;
    private int _secondBarrier;

    public float _timer;

    private void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            _points.Add(this.gameObject.transform.GetChild(i).GetComponent<BarrierSpawnPoint>());
        }
    }

    private void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= _delay)
        {
            CreateBarriers();

            _timer = 0;
        }
    }

    private void CreateBarriers()
    {
        _firstBarrier = Random.Range(0, _points.Count);

        while (_secondBarrier == _firstBarrier)
            _secondBarrier = Random.Range(0, _points.Count);

        
    }
}
