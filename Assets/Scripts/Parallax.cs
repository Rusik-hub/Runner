using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Parallax : MonoBehaviour
{
    [SerializeField] private BarrierSpawner _barrierSpawner;
    [SerializeField] private BuildingSpawner _buildingSpawner;
    [SerializeField] private UnityEvent _isTargetPositionAchieved;

    private SpeedController _speedController;
    private Vector3 _startPosition = new Vector3(-25, 0, 0);
    private Vector3 _targetPosition = new Vector3(125, 0, 0);
    private Material _currentMaterial;
    private float _speed = 10;

    public event UnityAction IsTargetPositionAchieved
    {
        add => _isTargetPositionAchieved.AddListener(value);
        remove => _isTargetPositionAchieved.RemoveListener(value);
    }

    public void SetMaterial(Material material)
    {
        _currentMaterial = material;
    }

    private void Awake()
    {
        _speedController = transform.parent.GetComponent<SpeedController>();
        GetComponent<MeshRenderer>().material = _currentMaterial;

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

        _barrierSpawner.UpdateBarriersState();
        _buildingSpawner.UpdateBuildingsState();
        _isTargetPositionAchieved?.Invoke();

        GetComponent<MeshRenderer>().material = _currentMaterial;
    }

    private void EditSpeed()
    {
        _speed = _speedController.Speed;
    }
}
