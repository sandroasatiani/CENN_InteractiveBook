using UnityEngine;
using System.Collections;

public class SettingsBtnsController : MonoBehaviour {
    public GameObject ExpendedSettings;
    public GameObject InfoPanel;
    public GameObject PausePanel;
	public void ShowInfo()
    {
        if (!InfoPanel.activeInHierarchy)
        {
            if (!GlobalParams.IsPaused) GlobalParams.IsPaused = true;
            InfoPanel.SetActive(true);
        }

    }
    public void HideInfo()
    {
        if (InfoPanel.activeInHierarchy)
        {
            InfoPanel.SetActive(false);
            if (GlobalParams.IsPaused) GlobalParams.IsPaused = false;
        }
    }

    public void ToggleMusic()
    {

    }


    public void PauseGame()
    {
        if (!PausePanel.activeInHierarchy)
        {
            PausePanel.SetActive(true);
            Time.timeScale = 0;
            GlobalParams.IsPaused = true;

        }
    }

    public void ResumeGame()
    {
        if (PausePanel.activeInHierarchy)
        {
            PausePanel.SetActive(false);
            Time.timeScale = 1;
            GlobalParams.IsPaused = false;
        }
    }


    public void GoToHome()
    {
        Application.LoadLevel("StartScene");

    }

    public void GoToLevelSelector()
    {
        Application.LoadLevel("LevelSelector");
    }

    public void ToggleExpendedSettings()
    {
        ExpendedSettings.SetActive(!ExpendedSettings.activeInHierarchy);
    }

}
