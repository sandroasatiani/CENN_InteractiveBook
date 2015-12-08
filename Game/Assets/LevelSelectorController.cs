using UnityEngine;
using System.Collections;

public class LevelSelectorController : MonoBehaviour {

    
	public void LoadLevel(int levelN)
    {
        Application.LoadLevel("Level_Scene_" + levelN.ToString());
    }
}
