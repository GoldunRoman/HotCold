using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HotOrColdDetector : MonoBehaviour
{
    [SerializeField] Image _image; 
    Gift _gift; 

    float _minDistance = 0f; 
    float _maxDistance = 15f; 

    Color _startColor; 
    Color _targetColor; 

    private void Start()
    {
        _gift = FindFirstObjectByType<Gift>();
        _maxDistance = _gift.DistanceToPlayerArm();

        _startColor = new Color(0f, 0f, 1f);
        _targetColor = new Color(1f, 0f, 0f);
    }

    private void Update()
    {
        LerpColors();
    }

    private void LerpColors()
    {
        float distance = _gift.DistanceToPlayerArm();
        float colorChangeProgress = Mathf.InverseLerp(_minDistance, _maxDistance, distance);
        _image.color = Color.Lerp(_targetColor, _startColor, colorChangeProgress);
    }
}
