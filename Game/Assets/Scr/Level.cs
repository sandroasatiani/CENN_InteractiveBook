using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Level : MonoBehaviour {

    public string name;
    public GameObject garbage_Positions_GO;
    public string stageName;


    public void Load()
    {
        for (int i = 0; i < garbage_Positions_GO.transform.childCount; i++)
        {
            
        }
    }

    public void UnLoad()
    {

    }
	
}
