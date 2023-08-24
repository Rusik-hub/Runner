using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerMover))]

public class PlayerInput : MonoBehaviour
{
    private PlayerMover _mover;

    private void Start()
    {
        _mover = GetComponent<PlayerMover>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            _mover.MoveLeft();
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            _mover.MoveRight();
        }
    }
}
