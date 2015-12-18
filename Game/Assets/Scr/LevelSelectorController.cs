using UnityEngine;
using System.Collections;

public class LevelSelectorController : MonoBehaviour {

    public GameObject Levels;
    
	public void LoadLevel(int levelN)
    {
        if (levelN <= GlobalParams.PassedLevels() + 1)
            Application.LoadLevel("Level_Scene_" + levelN.ToString());
    }

    public void Start()
    {
        GlobalParams.CurrentLevel = 0;
        for (int i = 0; i < GlobalParams.PassedLevels()+1; i++)
        {
            if (Levels.transform.childCount < GlobalParams.PassedLevels() + 1) return;
            Levels.transform.GetChild(i).gameObject.transform.FindChild("Cover").gameObject.SetActive(false);
        }
    }
    public void GoToHome()
    {
        Application.LoadLevel("StartScene");
    }

    public void LoadKichenMovie()
    {
        Application.LoadLevel("Movie_Kichen");
    }
}
