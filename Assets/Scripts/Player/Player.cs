using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private UnityEvent _isHealthUpdated;
    [SerializeField] private UnityEvent _isDead;

    private int _health = 3;
    private int _damage = 1;

    public int Health => _health;

    public event UnityAction IsHealthUpdated
    {
        add => _isHealthUpdated.AddListener(value);
        remove => _isHealthUpdated.RemoveListener(value);
    }

    public event UnityAction IsDead
    {
        add => _isDead.AddListener(value);
        remove => _isDead.RemoveListener(value);
    }

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.TryGetComponent<Barrier>(out Barrier barrier))
        {
            TakeDamage();

            _isHealthUpdated?.Invoke();
        }
    }

    private void Awake()
    {
        _isHealthUpdated?.Invoke();
    }

    private void TakeDamage()
    {
        _health -= _damage;

        if (_health <= 0)
            Die();
    }

    private void Die()
    {
        Time.timeScale = 0;

        _isDead?.Invoke();
    }
}
