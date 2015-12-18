using UnityEngine;
using System.Collections;

public class ContinueBtn : MonoBehaviour {

    void OnMouseDown()
    {
       if (CurrentLevelController.LevelN <5)
       {
           Application.LoadLevel("Level_Scene_" + (GlobalParams.CurrentLevel + 1).ToString());
           GlobalParams.SavePassedLevels(CurrentLevelController.LevelN);
       }
       if (CurrentLevelController.LevelN >= 5)
           Application.LoadLevel("FinishScene");
    }
}
