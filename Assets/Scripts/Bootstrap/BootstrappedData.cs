using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public static class PerformBootstrap
{
    const string SceneName = "Bootstrap";

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void Execute()
    {
        for(int sceneIndex = 0; sceneIndex < SceneManager.sceneCount; ++sceneIndex)
        {
            var candidate = SceneManager.GetSceneAt(sceneIndex);

            if (candidate.name == SceneName)
            {
                return;
            }
        }

        SceneManager.LoadScene(SceneName, LoadSceneMode.Additive);
    }
}


public class BootstrappedData : MonoBehaviour
{
    #region Singletone
    private static BootstrappedData _instance;
    public static BootstrappedData Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("Bootstrapped Data is null.");
            }
            return _instance;
        }
    }
    #endregion

    [Header("Scene transition data")]
    string _sceneName;

    [Header("Settings")]
    SettingsData _settingsData;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Found another BootstrappedData on " + gameObject.name);
        }

        Debug.Log("Bootstrap initialized.");
        _instance = this;

        DontDestroyOnLoad(gameObject);
    }

    #region SettingsDataOperations
    public void InitSettings(SettingsData data)
    {
        _settingsData = data;
    }

    public SettingsData GetSettingsData()
    { 
        if(_settingsData == null)
        {
            throw new NullReferenceException("BootstrappedData :: GetSettingsData(). SettingsData is null");
        }

        return _settingsData;
    }
    #endregion

    #region AsyncScenesLoadingOperations
    public void SetSceneName(string sceneToLoadName)
    {
        _sceneName = sceneToLoadName;
    }

    public string GetSceneName()
    {
        return _sceneName;
    }

    public void ClearLoadSceneData()
    {
        _sceneName = null;
    }
    #endregion

}
