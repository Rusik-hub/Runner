using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private UnityEvent _healthUpdated;
    [SerializeField] private UnityEvent _dead;

    private int _health = 3;
    private int _minDamage = 1;

    public int Health => _health;

    public event UnityAction HealthUpdated
    {
        add => _healthUpdated.AddListener(value);
        remove => _healthUpdated.RemoveListener(value);
    }

    public event UnityAction Dead
    {
        add => _dead.AddListener(value);
        remove => _dead.RemoveListener(value);
    }

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.TryGetComponent<Barrier>(out Barrier barrier))
        {
            TakeDamage(barrier.Damage);

            _healthUpdated?.Invoke();
        }
    }

    private void Awake()
    {
        _healthUpdated?.Invoke();
    }

    private void TakeDamage(int damage)
    {
        if (damage > 0)
            _health -= damage;
        else
            _health -= _minDamage;

        if (_health <= 0)
            Die();
    }

    private void Die()
    {
        Time.timeScale = 0;

        _dead?.Invoke();
    }
}
