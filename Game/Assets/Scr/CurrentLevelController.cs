using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class CurrentLevelController : MonoBehaviour {

    
    public GameObject AllGarbage;
    public GameObject GarbagePositions;
    public static int GarbageAmount = 0;
    public static int GarbageDropped = 0;
    public static int LevelN;
	void Start () {
        GlobalParams.currentlevelScore = 0;
        //Reseting Static For Reload
        GarbageDropped = 0;
        GarbageAmount = 0;
        LevelN = 0;
        //----
        GlobalParams.IsPaused = true;

        string LevelNum = Application.loadedLevelName.Remove(0,12);
        LevelN = int.Parse(LevelNum);

        List<int> randomNumList = Enumerable.Range(0, AllGarbage.transform.childCount).ToList();
        randomNumList.Shuffle();
        GarbageAmount = GarbagePositions.transform.childCount;
        GarbageAmountText.SetAmount();
        GarbageAmountText.UpdateText();
        
        for (int i = 0; i < GarbagePositions.transform.childCount; i++)
        {
            Instantiate(AllGarbage.transform.GetChild(randomNumList[i]), GarbagePositions.transform.GetChild(i).transform.position, Quaternion.identity);
        }


	}
	
	
}
