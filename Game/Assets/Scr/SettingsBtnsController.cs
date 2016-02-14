using UnityEngine;
using System.Collections;

public class SettingsBtnsController : MonoBehaviour {
    public GameObject ExpendedSettings;
    public GameObject InfoPanel;
    public GameObject PausePanel;
    public GameObject ScorePanel;
    public static  GameObject ScorePanel_static;
    public void Start()
    {

        ScorePanel_static = ScorePanel;
    }
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

    public void RestartLevel()
    {
        Application.LoadLevel("Level_Scene_" + CurrentLevelController.LevelN.ToString());
    }

    public void ContinueToRecycle()
    {
        Application.LoadLevel("Recycle");
    }

    public static void ShowScorePanel()
    {
        if (!ScorePanel_static.activeInHierarchy)
            ScorePanel_static.SetActive(true);
    }

    public void ShowMovieToFactory()
    {
        Application.LoadLevel("Movie_ToFactory");
    }

    public void GoToFinishScreen()
    {
        Application.LoadLevel("FinishScene");
    }

    

}
