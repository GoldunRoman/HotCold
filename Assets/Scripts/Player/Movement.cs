using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody _rb;
    SurfaceNormal _surfaceNormal;
    [SerializeField] float _speed = 5.0f;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _surfaceNormal = GetComponent<SurfaceNormal>();
    }

    public void Move(Vector3 direction)
    {
        Vector3 directionAlongSurface = _surfaceNormal.Project(direction.normalized);
        Vector3 offset = directionAlongSurface * (_speed * Time.deltaTime);

        _rb.MovePosition(_rb.position + offset);
    }
}
