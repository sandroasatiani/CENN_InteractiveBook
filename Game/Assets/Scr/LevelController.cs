using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;

public class LevelController : MonoBehaviour {
    public GameObject LevelControllerPanel;
    public GameObject BackgroundImage;
    public GameObject Bins;
    public GameObject AllGarbage;
    public List<GameObject> Levels;

    [HideInInspector]public List<Vector3> PositionsList;

	void Start () {
        //LoadLevel(1);
	}
	
	void Update () {
	
	}

    public void LoadLevel(int levelNum)
    {
        if (LevelControllerPanel.activeInHierarchy)
            LevelControllerPanel.SetActive(false);

        BackgroundImage.GetComponent<Image>().overrideSprite = Resources.Load<Sprite>("Level_Background/Stage_" + levelNum.ToString());
        print("Level_Background/Stage_" + levelNum.ToString());
        GameObject currentLevel =  Instantiate(Levels[levelNum - 1], Vector3.zero, Quaternion.identity) as GameObject;
        GameObject LevelGO = currentLevel.transform.Find("Garbage_Positions").gameObject;
        Camera.main.backgroundColor = currentLevel.transform.Find("StageBGColor").gameObject.GetComponent<SpriteRenderer>().color;

        for (int i = 0; i < LevelGO.transform.childCount; i++)
        {
            PositionsList.Add(LevelGO.transform.GetChild(i).gameObject.transform.position);
        }

        List<int> randomNumList = Enumerable.Range(0, AllGarbage.transform.childCount).ToList();
        randomNumList.Shuffle();

        for (int i = 0; i < LevelGO.transform.childCount; i++)
        {
            Instantiate(AllGarbage.transform.GetChild(randomNumList[i]), PositionsList[i], Quaternion.identity);
        }

        Instantiate(Bins, Levels[levelNum - 1].transform.Find("Bins_Pos").transform.position, Quaternion.identity);


    }
}


static class MyExtensions
{
    public static void Shuffle<T>(this IList<T> list)
    {
        System.Random rng = new System.Random();
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }
}