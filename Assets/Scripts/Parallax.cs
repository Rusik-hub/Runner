using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(MeshRenderer))]

public class Parallax : MonoBehaviour
{
    [SerializeField] private BarrierSpawner _barrierSpawner;
    [SerializeField] private BuildingSpawner _buildingSpawner;
    [SerializeField] private UnityEvent _isTargetPositionAchieved;

    private SpeedController _speedController;
    private Vector3 _startPosition = new Vector3(-25, 0, 0);
    private Vector3 _targetPosition = new Vector3(125, 0, 0);
    private Material _targetMaterial;
    private MeshRenderer _meshRenderer;
    private float _speed = 10;

    public event UnityAction IsTargetPositionAchieved
    {
        add => _isTargetPositionAchieved.AddListener(value);
        remove => _isTargetPositionAchieved.RemoveListener(value);
    }

    public void SetMaterial(Material material)
    {
        _targetMaterial = material;
    }

    private void Awake()
    {
        _speedController = transform.parent.GetComponent<SpeedController>();
    }

    private void OnEnable()
    {
        _speedController.SpeedWasIncreased += EditSpeed;
    }

    private void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _meshRenderer.material = _targetMaterial;

        EditSpeed();
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

        _meshRenderer.material = _targetMaterial;
    }

    private void EditSpeed()
    {
        _speed = _speedController.Speed;
    }
}
