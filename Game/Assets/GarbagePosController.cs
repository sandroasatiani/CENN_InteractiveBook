using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class GarbagePosController : MonoBehaviour {

    public GameObject LevelGO;

    public List<GameObject> GarbageList;
    public  List<GameObject> PositionsList;
    List<int> randomIntList;
    int randomNum;


    void Awake ()
    {
        for (int i = 0; i < LevelGO.transform.childCount; i++)
        {
            PositionsList.Add(LevelGO.transform.GetChild(i).gameObject);
        }
    }


	void Start () {

        List<int> randomNumList = Enumerable.Range(0, GarbageList.Count).ToList();
        randomNumList.Shuffle();
        for (int i = 0; i < randomNumList.Count; i++)
        {
            print(randomNumList[i]);
            
        }

        for (int i = 0; i < GarbageList.Count; i++)
        {
            Instantiate(GarbageList[i], PositionsList[randomNumList[i]].transform.position, Quaternion.identity);
        }
	}
	
	// Update is called once per frame
	void Update () {
	
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