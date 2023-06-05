using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinPanel : MonoBehaviour
{
    [SerializeField] GameObject _physicsParrentObject;

    private void Start()
    {
        this.gameObject.SetActive(false); 
    }

    public void PlayAgainButton()
    {
        BootstrappedData.Instance.SetSceneName("Game");
        SceneManager.LoadScene("LoadingScreen");
    }

    public void QuitButton()
    {
        BootstrappedData.Instance.SetSceneName("MainMenu");
        SceneManager.LoadScene("LoadingScreen");
    }
    
}
