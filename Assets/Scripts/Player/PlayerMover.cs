using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private List<Transform> _availablePaths;
    [SerializeField] private SpeedController _speedController;

    private Coroutine _moveCoroutine;
    private float _stepSize;
    private float _moveSpeed;
    private int _shiftSize = 1;
    private int _minPathNumber = 0;
    private int _maxPathNumber;
    private int _currentPathNumber = 1;
    private Vector3 _targetPosition;

    public void MoveLeft()
    {
        if (_moveCoroutine == null)
        {
            if (_currentPathNumber - _shiftSize >= _minPathNumber)
            {
                _currentPathNumber -= _shiftSize;
                _targetPosition.z = _availablePaths[_currentPathNumber].position.z;
                _moveCoroutine = StartCoroutine(Move());
            }
        }
    }

    public void MoveRight()
    {
        if (_moveCoroutine == null)
        {
            if (_currentPathNumber + _shiftSize <= _maxPathNumber)
            {
                _currentPathNumber += _shiftSize;
                _targetPosition.z = _availablePaths[_currentPathNumber].position.z;
                _moveCoroutine = StartCoroutine(Move());
            }
        } 
    }

    private void Awake()
    {
        _maxPathNumber = _availablePaths.Count - _shiftSize;
        _targetPosition = transform.position;
        _stepSize = transform.position.z + _availablePaths[_currentPathNumber + 1].position.z;

        EditSpeed();
    }

    private void OnEnable()
    {
        _speedController.SpeedWasIncreased += EditSpeed;
    }

    private void OnDisable()
    {
        _speedController.SpeedWasIncreased -= EditSpeed;
    }

    private IEnumerator Move()
    {
        while (transform.position != _targetPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _moveSpeed * Time.deltaTime);

            yield return null;
        }

        _moveCoroutine = null;
    }

    private void EditSpeed()
    {
        _moveSpeed = _speedController.Speed;
    }
}
