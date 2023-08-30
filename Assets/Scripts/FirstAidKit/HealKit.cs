using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealKit : MonoBehaviour
{
    private int _healValue = 1;

    public int HealValue => _healValue;

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.TryGetComponent<Player>(out Player player))
        {
            gameObject.SetActive(false);
        }
    }
}
