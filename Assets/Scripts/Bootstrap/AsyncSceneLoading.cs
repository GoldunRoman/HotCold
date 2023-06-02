using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AsyncSceneLoading : MonoBehaviour
{
    #region Singletone
    private static AsyncSceneLoading _instance;
    public static AsyncSceneLoading Instance
    {
        get
        {
            return _instance;
        }
    }

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Found another AsyncSceneLoading on " + gameObject.name);
        }

        Debug.Log("AsyncSceneLoading initialized.");
        _instance = this;
    }
    #endregion

    private void Start()
    {
        StartCoroutine(LoadSceneAsync("MainMenu"));
    }

    public IEnumerator LoadSceneAsync(string sceneName)
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName);

        while (!asyncOperation.isDone)
        {
            yield return new WaitForEndOfFrame();
        }
    }

    public IEnumerator LoadSceneAsync(Image progressBar, string sceneName)
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName);

        while (!asyncOperation.isDone)
        {
            progressBar.fillAmount = asyncOperation.progress;
            yield return new WaitForEndOfFrame();
        }
    }
}
