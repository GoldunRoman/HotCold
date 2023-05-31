using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    CharacterController _characterController;
    InputManager _inputManager;
    Transform _cameraTransform;
    Vector3 _velocity;
    bool _isGrounded;
    [SerializeField] float _speed = 2.0f;
    [SerializeField] float _jumpHeight = 1.0f;
    [SerializeField] float _gravityValue = -9.81f;

    private void Start()
    {
        if (!TryGetComponent(out _characterController))
        {
            Debug.LogError("Null reference exception in PlayerController script. CharacterController is null.");
        }

        _inputManager = InputManager.Instance;
        _cameraTransform = Camera.main.transform;
    }

    void Update()
    {
        PreventFromFallingThroughTextures();
        Movement();
        Jump(); 
    }

    private void PreventFromFallingThroughTextures()
    {
        _isGrounded = _characterController.isGrounded;
        if (_isGrounded && _velocity.y < 0)
        {
            _velocity.y = 0f;
        }
    }

    private void Movement()
    {
        Vector2 movementInput = _inputManager.GetPlayerMovement();

        Vector3 move = new Vector3(movementInput.x, 0f, movementInput.y);
        move = _cameraTransform.forward * move.z + _cameraTransform.right * move.x;
        move.y = 0f;

        _characterController.Move(move * Time.deltaTime * _speed);
    }

    private void Jump()
    {
        if (_inputManager.PlayerJumpedThisFrame() && _isGrounded)
        {
            _velocity.y += Mathf.Sqrt(_jumpHeight * -3.0f * _gravityValue);
        }

        _velocity.y += _gravityValue * Time.deltaTime;
        _characterController.Move(_velocity * Time.deltaTime);
    }
}
