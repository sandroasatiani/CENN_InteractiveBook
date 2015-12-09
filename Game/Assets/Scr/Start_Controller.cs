using UnityEngine;
using System.Collections;

public class Start_Controller : MonoBehaviour {


    public void StartGame()
    {
        Application.LoadLevel("LevelSelector");
        print("Game Started");
    }

    public void ShowAbout()
    {
        print("Showing About");
    }

}
