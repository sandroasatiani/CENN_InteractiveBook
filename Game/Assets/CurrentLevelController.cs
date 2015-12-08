﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class CurrentLevelController : MonoBehaviour {

    
    public GameObject AllGarbage;
    public GameObject GarbagePositions;
    public static int GarbageAmount;

	void Start () {


        List<int> randomNumList = Enumerable.Range(0, AllGarbage.transform.childCount).ToList();
        randomNumList.Shuffle();
        GarbageAmount = GarbagePositions.transform.childCount;
        print(GarbageAmount);
        for (int i = 0; i < GarbagePositions.transform.childCount; i++)
        {
            Instantiate(AllGarbage.transform.GetChild(randomNumList[i]), GarbagePositions.transform.GetChild(i).transform.position, Quaternion.identity);
        }


	}
	
	
}
