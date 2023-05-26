using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonEvents : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void BeginOfflineGame()
    {
        BootstrappedData.Instance.SetSceneName("OfflineMode");
        SceneManager.LoadScene("LoadingScreen");
    }
}
