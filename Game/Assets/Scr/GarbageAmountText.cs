using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class GarbageAmountText : MonoBehaviour {
    static Text thisText;
    static int amount;
	void Start () {
        thisText = gameObject.GetComponent<Text>();
        
	}
	
    public static void SetAmount()
    {
         amount = CurrentLevelController.GarbageAmount;
    }

    public static void UpdateText()
    {

        thisText.text = CurrentLevelController.GarbageDropped.ToString() + "/" + amount.ToString();
    }
	
}
