using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    [SerializeField] private List<Parallax> _parts;

    public void ChangeSpeed()
    {
        foreach (var part in _parts)
        {
            part.IncreaseSpeed();
        }
    }
}
