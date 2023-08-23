using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Parallax : MonoBehaviour
{
    [SerializeField] private BarrierSpawner _spawner;
    [SerializeField] private UnityEvent _isTargetPositionAchieved;

    private SpeedController _speedController;
    private Vector3 _startPosition = new Vector3(-25, 0, 0);
    private Vector3 _targetPosition = new Vector3(125, 0, 0);
    private float _speed = 10;

    public event UnityAction IsTargetPositionAchieved
    {
        add => _isTargetPositionAchieved.AddListener(value);
        remove => _isTargetPositionAchieved.RemoveListener(value);
    }

    private void OnEnable()
    {
        _speedController = transform.parent.GetComponent<SpeedController>();

        EditSpeed();

        _speedController.SpeedWasIncreased += EditSpeed;
    }

    private void OnDisable()
    {
        _speedController.SpeedWasIncreased -= EditSpeed;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _speed * Time.deltaTime);

        if (transform.position.x >= _targetPosition.x)
        {
            AchieveTargetPosition();
        }
    }

    private void AchieveTargetPosition()
    {
        transform.position = _startPosition;

        _spawner.UpdateBarriersState();
        _isTargetPositionAchieved?.Invoke();
    }

    private void EditSpeed()
    {
        _speed = _speedController.Speed;
    }
}
