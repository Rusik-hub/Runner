using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int _health = 3;
    private int _minDamage = 1;

    public void TakeDamage(int damage)
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

    }
}
