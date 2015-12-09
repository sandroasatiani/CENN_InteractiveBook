using UnityEngine;
using System.Collections;

public class GlobalParams : MonoBehaviour {

    public static bool IsPaused = true;

    public void SavePassedLevels(int level)
    {
        if (level > PassedLevels())
            PlayerPrefs.SetInt("Passed_Levels", level);
    }

    public static  int  PassedLevels()
    {
        return PlayerPrefs.GetInt("Passed_Levels");
    }

}
