using UnityEngine;
using System.Collections;

public class cloudScript : MonoBehaviour {
    float x, y;
    public float X, Y;
    bool _x, _y;
	void Start () {
        x = gameObject.transform.position.x;
        y = gameObject.transform.position.y;
     //   X = 0.001f;
       // Y= 0.0008f;
	}
	
	void Update () {

       if(_x)
       {
           gameObject.transform.position = new Vector3(gameObject.transform.position.x + X, gameObject.transform.position.y, gameObject.transform.position.z);
           if (gameObject.transform.position.x > x + 0.1f)
               _x = false;
       }
        else
       {
           gameObject.transform.position = new Vector3(gameObject.transform.position.x - X, gameObject.transform.position.y, gameObject.transform.position.z);
           if (gameObject.transform.position.x < x - 0.1f)
               _x = true;
       }
       if (_y)
       {
           gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + Y, gameObject.transform.position.z);
           if (gameObject.transform.position.y > y + 0.01f)
               _y = false;
       }
       else
       {
           gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - Y, gameObject.transform.position.z);
           if (gameObject.transform.position.y < y - 0.01f)
               _y = true;
       }
	
	}
}
