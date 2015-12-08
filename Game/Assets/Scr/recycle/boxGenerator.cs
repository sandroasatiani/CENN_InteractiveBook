using UnityEngine;
using System.Collections;

public class boxGenerator : MonoBehaviour {

	void OnMouseDown()
	{
		GameObject.Find ("referenceSprite").SetActive (false);
	}
	void OnMouseUp()
	{
		Params.isChoosen = false;
	}
}
