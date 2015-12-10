using UnityEngine;
using System.Collections;

public class Params : MonoBehaviour {

	public static bool startHeaderMotion = false;
	public static bool isChoosen = false;
    public static int RecycleScore = 180;
	void Start () {
        RecycleScore = 180;
        print("Reseted Score: " + RecycleScore);
	
	}
	
	void Update () {
	
	}
}
    