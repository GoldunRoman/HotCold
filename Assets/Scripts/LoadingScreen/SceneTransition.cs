using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneTransition : MonoBehaviour
{
    [SerializeField]
    Image _progressBar;
    private void Start()
    {
        LoadScenes();
    }

    public void LoadScenes()
    {
        string sceneToLoad = BootstrappedData.Instance.GetSceneName();
        StartCoroutine(AsyncSceneLoading.Instance.LoadSceneAsync(_progressBar, sceneToLoad));
    }
}
