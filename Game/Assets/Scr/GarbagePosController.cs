using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class GarbagePosController : MonoBehaviour {

    public GameObject LevelGO;

    public GameObject AllGarbage;
    public List<Vector3> PositionsList;
    List<int> randomIntList;


    void Awake ()
    {
       for (int i = 0; i < LevelGO.transform.childCount; i++)
       {
           //print(LevelGO.transform.GetChild(i).gameObject.transform.position);
           PositionsList.Add(LevelGO.transform.GetChild(i).gameObject.transform.position);
       }
    }


	void Start () {

        List<int> randomNumList = Enumerable.Range(0, AllGarbage.transform.childCount).ToList();
        randomNumList.Shuffle();    
        for (int i = 0; i < LevelGO.transform.childCount; i++)
        {
            Instantiate(AllGarbage.transform.GetChild(randomNumList[i]), PositionsList[i], Quaternion.identity);
        }
	}
	

}

//static class MyExtensions
//{
//    public static void Shuffle<T>(this IList<T> list)
//    {
//        System.Random rng = new System.Random();
//        int n = list.Count;
//        while (n > 1)
//        {
//            n--;
//            int k = rng.Next(n + 1);
//            T value = list[k];
//            list[k] = list[n];
//            list[n] = value;
//        }
//    }
//}