using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FinishScreenScoreTxt : MonoBehaviour {

	void Start () {
        gameObject.GetComponent<Text>().text = "სულ დაგროვებული ქულა: " + GlobalParams.GetFullScore().ToString();
	}
	
	void Update () {
	
	}
}
