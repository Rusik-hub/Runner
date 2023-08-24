using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSpawner : ObjectPool
{
    [SerializeField] private List<BuildingSpawnPoint> _points;
    [SerializeField] private List<GameObject> _prefabs;

    private int _spawnPointsCount;
    private int _prefabsCount;
    private int _minChanceOfShowing = 0;
    private int _maxChanceOfShowing = 100;
    private int _chanceOfShowing = 70;
    private float _coordinateSystemOrigin = 0;
    private float _rotateForRightPart = 180;
    private float _rotateForLeftPart = 0;

    public void UpdateBuildingsState()
    {
        UnshowAllObjects();
        ShowRandomBuildings();
    }

    private void Start()
    {
        _spawnPointsCount = _points.Count;
        _prefabsCount = _prefabs.Count;

        FillPull();
    }

    private void ShowRandomBuildings()
    {
        for (int i = 0; i < _spawnPointsCount; i++)
        {
            int indexOfBuilding = Random.Range(0, _prefabsCount);

            if (_chanceOfShowing >= Random.Range(_minChanceOfShowing, _maxChanceOfShowing))
            {
                while (CheckObjectUsage(indexOfBuilding))
                {
                    indexOfBuilding = Random.Range(0, _prefabsCount);
                }

                TryGetObject(out GameObject gameObject, indexOfBuilding);

                gameObject.transform.position = _points[i].transform.position;

                if (gameObject.transform.position.z > _coordinateSystemOrigin)
                    gameObject.transform.rotation = Quaternion.Euler(0, _rotateForRightPart, 0);
                else
                    gameObject.transform.rotation = Quaternion.Euler(0, _rotateForLeftPart, 0);

                gameObject.SetActive(true);
            }
        }
    }

    private void FillPull()
    {
        for (int i = 0; i < _prefabsCount; i++)
        {
            Initialize(_prefabs[i]);
        }
    }
}
