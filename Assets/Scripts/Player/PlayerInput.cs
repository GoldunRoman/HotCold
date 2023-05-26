using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] FixedJoystick _joystick;
    [SerializeField] Movement _movement;

    private void Start()
    {
        _movement = GetComponent<Movement>();
    }

    private void FixedUpdate()
    {
        float horizontalInput = _joystick.Horizontal;
        float verticalInput = _joystick.Vertical;

        _movement.Move(new Vector3(horizontalInput, 0, verticalInput));
    }
}
