using UnityEngine;
using System.Collections;

public class HideScorePanelREC : MonoBehaviour {

    public GameObject ScorePanel;
    void OnMouseDown()
    {
        ScorePanel.SetActive(false);
    }
}
