using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinemachinePOVExtension : CinemachineExtension
{
    [SerializeField] float _sensivity;
    [SerializeField] float _clampAngle = 90f;

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
                Vector2 deltaInput = _inputManager.GetTouchScreenDelta();
                _startingRotation.x += deltaInput.x * BootstrappedData.Instance.sensivity * Time.deltaTime;
                _startingRotation.y += deltaInput.y * _sensivity * Time.deltaTime;
                _startingRotation.y = Mathf.Clamp(_startingRotation.y, -_clampAngle, _clampAngle);
                state.RawOrientation = Quaternion.Euler(-_startingRotation.y, _startingRotation.x, 0f);
            }
        }
    }
}
