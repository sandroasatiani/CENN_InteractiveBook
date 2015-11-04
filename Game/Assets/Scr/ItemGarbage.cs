using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class ItemGarbage : MonoBehaviour {

    public float ReturnToStartPosTime = 2;
    Vector3 point;
    bool canBeDropped = false;
    Vector3 startingPos;
    Animator animator;
    GameObject currentBin;
    GameObject binGO;


    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    void OnMouseDown()
    {
        startingPos = gameObject.transform.position;
        print(startingPos);
    }

    void OnMouseDrag()
    {
        
        point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(point.x, point.y, transform.position.z);
    }

    void OnMouseUp()
    {
        //print("drag is over");
        if(canBeDropped)
        {
            DropInBin(gameObject.tag);
        }
        else
        {
            StartCoroutine(MoveToStartPos());
            if (currentBin !=null)
            {
                currentBin.GetComponent<Animator>().SetTrigger("Shake");

            }
            //transform.position = startingPos; 
        }
        
    }
   
    void OnTriggerEnter2D(Collider2D other)
    {
        print(other.gameObject.tag);
        currentBin = other.gameObject;
        switch (gameObject.tag)
        {
            case "Plastic_Garbage":
                if (other.gameObject.tag == "Plastic_Bin")
                {
                    canBeDropped = true;
                    binGO = other.gameObject;
                }
                break;
            case "Paper_Garbage":
                if (other.gameObject.tag == "Paper_Bin")
                {
                    canBeDropped = true;
                    binGO = other.gameObject;
                }
                break;
            case "Metalic_Garbage":
                if (other.gameObject.tag == "Metalic_Bin")
                {
                    canBeDropped = true;
                    binGO = other.gameObject;
                }
                break;
            case "Organic_Garbage":
                if (other.gameObject.tag == "Organic_Bin")
                {
                    canBeDropped = true;
                    binGO = other.gameObject;
                }
                break;

            default:
                break;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        canBeDropped = false;
        currentBin = null;
    }

    private void DropInBin(string type)
    {
        binGO.GetComponent<Animator>().SetTrigger("Swallow");
        animator.SetTrigger("DropIn");
        
    }

    IEnumerator MoveToStartPos()
    {
        float startTime = Time.time;
        while (Vector3.Distance(transform.position,startingPos) > 0.2f)
       {
            yield return null;
            transform.position = Vector3.Lerp(transform.position, startingPos, (Time.time - startTime));
       }
        transform.position = startingPos;

    }

    public void DestroyMe()
    {
        Destroy(gameObject);
    }


}


