﻿using UnityEngine;
using System.Collections;

public class TimerLogic : MonoBehaviour {

    public float Timer = 180;
    float angle;
    bool levelIsFinished = false;
    public GameObject TimerArrow;
    
	void Start () {
        angle = Timer;
	}
	
	void Update () {

        if (GlobalParams.IsPaused) return;
        if (levelIsFinished) return;
        if (CurrentLevelController.GarbageDropped<CurrentLevelController.GarbageAmount)
        {
            
            if (Timer>0)
            {
                Timer -= Time.deltaTime;
                TimerArrow.transform.Rotate(0, 0, (-360 / angle) * Time.deltaTime);
            }

               
        }
        else
        {
            SettingsBtnsController.ShowScorePanel();
            levelIsFinished = true;
            GlobalParams.SaveScore((int)Timer);
            GlobalParams.currentlevelScore = (int)Timer;

        }
	
	}
}
