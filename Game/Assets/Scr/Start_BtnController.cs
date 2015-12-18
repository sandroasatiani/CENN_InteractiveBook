using UnityEngine;
using System.Collections;

public class Start_BtnController : MonoBehaviour {

	public void ResetGame()
    {
        PlayerPrefs.DeleteAll();
    }

}
