using UnityEngine;
using System.Collections;

public class SkipController : MonoBehaviour {

    public GameObject LoadingScreen;
	public void LoadNextLevel()
    {
        if (GlobalParams.CurrentLevel <5)
        {
            Application.LoadLevel("Level_Scene_" + (GlobalParams.CurrentLevel + 1).ToString());
        }
    }

    public void LoadRecycle()
    {
        Application.LoadLevel("Recycle");
    }


    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            LoadingScreen.SetActive(true);
            Application.LoadLevel("StartScene");
        }
    }
}
