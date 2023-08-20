using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField, Range(0, 20)] private float _speed;
    [SerializeField] private Transform _startPosition;
    [SerializeField] private Transform _targetPosition;
    [SerializeField] private Floor _floor;

    public void IncreaseSpeed()
    {
        _speed++;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _targetPosition.position, _speed * Time.deltaTime);

        if (transform.position.x >= _targetPosition.position.x)
        {
            transform.position = _startPosition.position;
            _floor.ChangeSpeed();
        }
    }
}
