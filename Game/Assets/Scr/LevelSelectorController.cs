using UnityEngine;
using System.Collections;

public class LevelSelectorController : MonoBehaviour {

    public GameObject Levels;
    
	public void LoadLevel(int levelN)
    {
        Application.LoadLevel("Level_Scene_" + levelN.ToString());
    }

    public void Start()
    {
        for (int i = 0; i < GlobalParams.PassedLevels(); i++)
        {
            Levels.transform.GetChild(i).gameObject.transform.FindChild("Cover").gameObject.SetActive(false);
        }
    }
}
