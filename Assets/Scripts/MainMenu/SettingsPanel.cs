using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsPanel : MonoBehaviour
{
    [SerializeField] Slider _sensivitySlider, _volumeSlider;
    void Start()
    {
        this.gameObject.SetActive(false);
    }

    void Update()
    {
        
    }

    public void CloseSettingsAndSendDataToBootstrap()
    {
        float sensivity = _sensivitySlider.value;
        float volume = _volumeSlider.value;

        BootstrappedData.Instance.SetCameraSettings(sensivity);

        Debug.Log($"Sensivity = {sensivity} and Volume = {volume}");

        this.gameObject.SetActive(false);
    }
}
