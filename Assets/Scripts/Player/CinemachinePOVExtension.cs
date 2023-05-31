using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinemachinePOVExtension : CinemachineExtension
{
    [SerializeField] float _horizontalSensivity = 10f;
    [SerializeField] float _verticalSensivity = 10f;
    [SerializeField] float _clampAngle = 80f;


    InputManager _inputManager;
    Vector3 _startingRotation;

    protected override void Awake()
    {
        _inputManager = InputManager.Instance;

        if(_startingRotation == null)
        {
            _startingRotation = transform.localRotation.eulerAngles;
        }

        base.Awake();
    }

    protected override void PostPipelineStageCallback(CinemachineVirtualCameraBase vcam, CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
    {
        if (vcam.Follow)
        {
            if(stage == CinemachineCore.Stage.Aim)
            {
                Vector2 deltaInput = _inputManager.GetMouseDelta();
                _startingRotation.x += deltaInput.x * _verticalSensivity * Time.deltaTime;
                _startingRotation.y += deltaInput.y * _horizontalSensivity * Time.deltaTime;
                _startingRotation.y = Mathf.Clamp(_startingRotation.y, -_clampAngle, _clampAngle);
                state.RawOrientation = Quaternion.Euler(-_startingRotation.y, _startingRotation.x, 0f);
            }
        }
    }
}
