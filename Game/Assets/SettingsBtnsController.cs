using UnityEngine;
using System.Collections;

public class SettingsBtnsController : MonoBehaviour {
    public GameObject ExpendedSettings;
	public void ShowInfo()
    {


    }

    public void ToggleMusic()
    {

    }


    public void PauseGame()
    {

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
