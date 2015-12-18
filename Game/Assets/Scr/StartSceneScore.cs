using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StartSceneScore : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<Text>().text = "თქვენ დააგროვეთ: " + GlobalParams.GetFullScore().ToString();
	}

    public void UpdateText()
    {
        GetComponent<Text>().text = "თქვენ დააგროვეთ: " + GlobalParams.GetFullScore().ToString();

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
