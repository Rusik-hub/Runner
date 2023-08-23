using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int _health = 3;
    private int _damage = 1;

    private void TakeDamage()
    {
        _health -= _damage;

        if (_health <= 0)
            Die();

        Debug.Log(_health);
    }

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.TryGetComponent<Barrier>(out Barrier barrier))
        {
            TakeDamage();
        }
    }

    private void Die()
    {

    }
}
