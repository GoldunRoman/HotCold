using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonEvents : MonoBehaviour
{
    [SerializeField] GameObject _settingsPanel;

    public void BeginOfflineGame()
    {
        BootstrappedData.Instance.SetSceneName("Game");
        SceneManager.LoadScene("LoadingScreen");
    }

    public void OpenSettingsPanel()
    {
        _settingsPanel.SetActive(true);
    }

    public void CloseApp()
    {
        Application.Quit();
    }

}
