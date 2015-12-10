using UnityEngine;
using System.Collections;

public class Rec_ScoreText : MonoBehaviour {

	// Use this for initialization
	void Start () {
        string text = "ქულა: " + Params.RecycleScore + "@ სულ: " + GlobalParams.GetFullScore();
        text = text.Replace("@", System.Environment.NewLine);
        GetComponent<TextMesh>().text = text;
        GlobalParams.SaveScore(Params.RecycleScore);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
