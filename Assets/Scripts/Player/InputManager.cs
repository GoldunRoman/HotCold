using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    #region Singletone
    static InputManager _instance;
    public static InputManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("InputManager is null.");
            }
            return _instance;
        }
    }
    #endregion

    PlayerInput _playerInput;
    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Found another InputManager on " + gameObject.name);
        }

        Debug.Log("InputManager initialized.");
        _instance = this;


        _playerInput = new PlayerInput();

    }

    private void OnEnable()
    {
        _playerInput.Enable();
    }

    private void OnDisable()
    {
        _playerInput.Disable();
    }

    public Vector2 GetPlayerMovement()
    {
        return _playerInput.PlayerMain.Move.ReadValue<Vector2>();
    }

    public Vector2 GetMouseDelta()
    {
        return _playerInput.PlayerMain.Look.ReadValue<Vector2>();
    }

    public bool PlayerJumpedThisFrame()
    {
        return _playerInput.PlayerMain.Jump.triggered;
    }
}
