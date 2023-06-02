using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Arm : MonoBehaviour
{
    [Header("General")]
    InputManager _inputManager;

    [Header("Transform information")]
    [SerializeField] Transform _arm;
    Transform _cameraPosition;

    [Header("Ray Settings")]
    float _rayDistance = 5f;

    [Header("Other Settings")]
    GameObject _currentItem;
    bool _isPickedUp = false;
    float _speed = 5f;

    private void Start()
    {
        _inputManager = InputManager.Instance;
        _cameraPosition = Camera.main.transform;
    }

    private void Update()
    {
        if (_inputManager.PlayerPicksUpItem())
        {
            PickUp();
        }
    }

    private void PickUp()
    {
        if (_isPickedUp)
        {
            Drop();
            return;
        }

        RaycastHit hit;

        if (Physics.Raycast(_cameraPosition.position, _cameraPosition.forward, out hit, _rayDistance))
        {
            Debug.DrawRay(_cameraPosition.position, _cameraPosition.forward * _rayDistance, Color.red);
            if(hit.transform.GetComponent<Rigidbody>() == true)
            {
                _currentItem = hit.transform.gameObject;
                _currentItem.GetComponent<Rigidbody>().isKinematic = true;
                _currentItem.transform.SetParent(this.transform);
                _currentItem.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.Euler(10f, 0f, 0f));

                _isPickedUp = true;
            }
        }
    }

    private void Drop()
    {
        _currentItem.transform.parent = null;
        _currentItem.transform.GetComponent<Rigidbody>().isKinematic = false;

        _isPickedUp = false;
        _currentItem = null;
    }

}
