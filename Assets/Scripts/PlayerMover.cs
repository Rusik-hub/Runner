using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private List<Transform> _availablePaths;
    [SerializeField, Range(0.1f, 20f)] private float _moveSpeed;

    private Coroutine _moveCoroutine;
    private int _shiftSize = 1;
    [SerializeField] private float _stepSize;
    private int _minPathNumber = 0;
    [SerializeField] private int _maxPathNumber;
    [SerializeField] private int _currentPathNumber = 1;
    [SerializeField] private Vector3 _targetPosition;

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
    }

    private void Update()
    {
        //empty
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
}
