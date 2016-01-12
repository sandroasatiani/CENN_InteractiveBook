using UnityEngine;
using System.Collections;

public class GarbageNameText : MonoBehaviour {

    public int SortLayer = 0;
    // Use this for initialization
    void Start()
    {
        Renderer renderer = this.gameObject.GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.sortingOrder = SortLayer;
                gameObject.GetComponent<Renderer>().sortingLayerName = "GarbageTxt";
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
