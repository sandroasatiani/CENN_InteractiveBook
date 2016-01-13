using UnityEngine;
using System.Collections;

public class factory : MonoBehaviour {
    Vector3 startPos;
	float i;
	void Start () {
        startPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
		i = Random.Range ( 0.01f,0.03f);;
	}
	
	void Update () {
        if (gameObject.transform.position.x < 30)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x + Random.Range (0.05f, 0.1f), gameObject.transform.position.y + i, gameObject.transform.position.z);
            i = i *(- 1);
        }
        else
            gameObject.transform.position = startPos;
	}
}