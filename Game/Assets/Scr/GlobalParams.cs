using UnityEngine;
using System.Collections;

public class GlobalParams : MonoBehaviour {

    public static bool IsPaused = true;
    public static int currentlevelScore=0;

    public void SavePassedLevels(int level)
    {
        if (level > PassedLevels())
            PlayerPrefs.SetInt("Passed_Levels", level);
    }

    public static  int  PassedLevels()
    {
        return PlayerPrefs.GetInt("Passed_Levels");
    }

    public static void SaveScore (int score)
    {
        PlayerPrefs.SetInt("Score", GetFullScore() + score);
    }
    public static  int GetFullScore()
    {
        return PlayerPrefs.GetInt("Score");
    }
    

}
