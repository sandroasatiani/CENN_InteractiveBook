using UnityEngine;
using System.Collections;

public class hide : MonoBehaviour {
	
	void OnMouseDown()
	{
		GameObject.Find("referenceSprite").SetActive(false);
		Params.isChoosen = false;
	}
}
