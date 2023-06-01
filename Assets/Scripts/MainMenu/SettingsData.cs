using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsData : MonoBehaviour
{
    BootstrappedData _bootstrappedData;
    public float _speed = 2.0f;


    private void Start()
    {
        _bootstrappedData = BootstrappedData.Instance;
        _bootstrappedData.InitSettings(this);
    }

}
