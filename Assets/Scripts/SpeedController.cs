using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpeedController : MonoBehaviour
{
    [SerializeField] private UnityEvent _speedWasIncreased;
    [SerializeField] private List<Parallax> _parallax;
    [SerializeField] private float _speed;

    public float Speed => _speed;

    public event UnityAction SpeedWasIncreased
    {
        add => _speedWasIncreased.AddListener(value);
        remove => _speedWasIncreased.RemoveListener(value);
    }

    public void IncreaseSpeed()
    {
        _speed++;

        _speedWasIncreased?.Invoke();
    }

    private void OnEnable()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            _parallax.Add(transform.GetChild(i).GetComponent<Parallax>());
        }

        for (int i = 0; i < _parallax.Count; i++)
        {
            _parallax[i].TargetPositionAchieved += IncreaseSpeed;
        }
    }

    private void OnDisable()
    {
        for (int i = 0; i < _parallax.Count; i++)
        {
            _parallax[i].TargetPositionAchieved -= IncreaseSpeed;
        }
    }
}
