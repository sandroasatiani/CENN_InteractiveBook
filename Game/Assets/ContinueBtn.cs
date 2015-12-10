using UnityEngine;
using System.Collections;

public class ContinueBtn : MonoBehaviour {

    void OnMouseDown()
    {
       if (CurrentLevelController.LevelN <5)
       {
           Application.LoadLevel("Level_Scene_" + (CurrentLevelController.LevelN + 1).ToString());
           GlobalParams.SavePassedLevels(CurrentLevelController.LevelN);
       }
    }
}
