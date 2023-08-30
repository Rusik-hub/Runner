using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject _container;

    private List<GameObject> _pool = new List<GameObject>();

    protected void Initialize(GameObject prefab)
    {
        GameObject gameObject = Instantiate(prefab, _container.transform);
        gameObject.SetActive(false);

        _pool.Add(gameObject);
    }

    protected void UnshowAllObjects()
    {
        foreach (var gameObject in _pool)
        {
            gameObject.SetActive(false);
        }
    }

    protected bool TryGetObject(out GameObject result, int index)
    {
        result = _pool[index];

        return result != null;
    }

    protected bool CheckObjectUsage(int index)
    {
        return _pool[index].activeSelf;
    }

    protected void FillPull(List<GameObject> prefabs)
    {
        foreach (GameObject prefab in prefabs)
        {
            Initialize(prefab);
        }
    }
}
