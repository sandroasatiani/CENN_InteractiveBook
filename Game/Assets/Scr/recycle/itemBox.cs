using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;

public class itemBox : MonoBehaviour {
	string objectName;
	bool isActive;
	bool shake = false;
	SpriteRenderer spRend;
	string Shadow_name;
	int i=0;

	//string subj_name;

	void Start ()
	{
		objectName = gameObject.name;
		isActive = true;
		spRend = gameObject.GetComponent<SpriteRenderer> ();
		Shadow_name = spRend.sprite.name [0].ToString();
	}

	void OnMouseDown()
	{
		if (gameObject.tag == MechanismAnim.returnTagReference ()) {
			if (!Params.isChoosen && isActive) {
				isActive = false;
				Params.isChoosen = true;
				MechanismAnim.headerMotion (gameObject.transform.position.x, gameObject.name);
			}
		} else
            if (!Params.isChoosen && isActive)
            {
                shake = true;
                if (Params.RecycleScore >0)
                    Params.RecycleScore -= 60;
                /// qulis dakargva
            }
			
	}

	public void getSubjectSpriteItem()
	{
		GameObject.Find ("subject").GetComponent<SpriteRenderer> ().sprite = gameObject.GetComponent<SpriteRenderer> ().sprite;
		spRend.sprite = Resources.Load<UnityEngine.Sprite> ("box/" + Shadow_name);
	}
	void Update () 
	{
		if (shake) 
		{
			if(i<10)
			{
				gameObject.transform.Rotate (new Vector3 (0, 0, 10));
				i++;
			}
			else if(i<20)
			{
				gameObject.transform.Rotate (new Vector3 (0, 0, -10));
				i++;
			}
			else
			{
				shake = false;
				i=0;
			}


		}

	}
}
