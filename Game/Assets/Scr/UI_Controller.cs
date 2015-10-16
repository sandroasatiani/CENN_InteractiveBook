using UnityEngine;
using System.Collections;

public class UI_Controller : MonoBehaviour {

	public void RestartGame()
    {
        Application.LoadLevel(0);
    }
}
