using UnityEngine;
using System.Collections;

public class MovieController : MonoBehaviour {

    public GameObject Movie_1;

	void Start () {
	
	}

    public void StartMovie()
    {
        Movie_1.GetComponent<AfterEffectAnimation>().Play();
        
    }

     public void LoadRecycle()
    {
        Application.LoadLevel("Recycle");
    }


    public void GoToNextLevel()
    {
        if (GlobalParams.CurrentLevel < 5)
        {
            Application.LoadLevel("Level_Scene_" + (GlobalParams.CurrentLevel + 1).ToString());
        }
    }
	
	// Update is called once per frame
	void Update () {
	if ( Movie_1.GetComponent<AfterEffectAnimation>().currentFrame ==440)
        {
            gameObject.GetComponent<Animator>().SetTrigger("FollowCar");
        }
    else if (Movie_1.GetComponent<AfterEffectAnimation>().currentFrame ==441)
    {
        gameObject.GetComponent<Animator>().SetTrigger("FollowCar");
    }
	}
}
