using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CurrentLevelScore : MonoBehaviour {

	void Start () {
        string text = "ქულა: " + GlobalParams.currentlevelScore + "@ სულ: " + GlobalParams.GetFullScore() ;
        text = text.Replace("@", System.Environment.NewLine);
        GetComponent<Text>().text = text;
	}
	
	
}
