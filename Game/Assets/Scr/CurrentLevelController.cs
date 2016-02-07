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

    public GameObject Plastic_Bin;
    public GameObject Metalic_Bin;
    public GameObject Paper_Bin;
    public GameObject Organic_Bin;

    public GameObject GarbageNameText;

    public static CurrentLevelController instance;


	void Start () {

        if (instance == null)
            instance = this;
        else if (instance != null)
            Destroy(this);

        GlobalParams.currentlevelScore = 0;
        //Reseting Static For Reload
        GarbageDropped = 0;
        GarbageAmount = 0;
        LevelN = 0;
        //----
        GlobalParams.IsPaused = true;

        string LevelNum = Application.loadedLevelName.Remove(0,12);
        LevelN = int.Parse(LevelNum);
        GlobalParams.CurrentLevel = LevelN;

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

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.LoadLevel("StartScene");
        }
    }

	
	
}
