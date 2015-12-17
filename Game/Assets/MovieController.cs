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
	
	// Update is called once per frame
	void Update () {
	if ( Movie_1.GetComponent<AfterEffectAnimation>().currentFrame ==440)
        {
            gameObject.GetComponent<Animator>().SetTrigger("FollowCar");
        }
	}
}
