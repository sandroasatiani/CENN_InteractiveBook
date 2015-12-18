using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class ItemGarbage : MonoBehaviour {

    public string GeorgianName;
    public float ReturnToStartPosTime = 2;
    Vector3 point;
    bool canBeDropped = false;
    Vector3 startingPos;
    Animator animator;
    GameObject currentBin;
    GameObject binGO;
    string selectedType;
    GameObject GarbageNameTxt;
    GameObject currentTxt;
    GameObject EnlargedBin;
    Color currentTextColor;
    float garbageBoundY;

    

    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    void OnMouseDown()
    {
        startingPos = gameObject.transform.position;

        if (CurrentLevelController.LevelN == 1)
            ShowUpText();
        if (gameObject.GetComponent<AudioSource>())
            gameObject.GetComponent<AudioSource>().Play();
       
    }

    void ShowUpText()
    {
        
        switch (gameObject.tag)
        {
            case "Metalic_Garbage":
                currentTxt = TypeController.Metalic_Txt;
                EnlargedBin = CurrentLevelController.instance.Metalic_Bin;
                currentTextColor = new Color32(0,82,129,255);
                break;
            case "Plastic_Garbage":
                currentTxt = TypeController.Plastic_Txt;
                EnlargedBin = CurrentLevelController.instance.Plastic_Bin;
                currentTextColor = new Color32(204, 34, 34, 255);
                break;
            case "Paper_Garbage":
                currentTxt = TypeController.Paper_Txt;
                EnlargedBin = CurrentLevelController.instance.Paper_Bin;
                currentTextColor = new Color32(255, 187, 51, 255);
                break;
            case "Organic_Garbage":
                currentTxt = TypeController.Organic_Txt;
                EnlargedBin = CurrentLevelController.instance.Organic_Bin;
                currentTextColor = new Color32(0, 153, 68, 255);
                break;
            default:
                currentTxt = TypeController.Paper_Txt;
                break;
        }
        
        if (EnlargedBin !=null)
        {
            EnlargedBin.GetComponent<Animator>().SetTrigger("Enlarge");
            currentTxt = Instantiate(currentTxt, EnlargedBin.transform.position + new Vector3(0, -3, 5), Quaternion.identity) as GameObject;
            //currentTxt.GetComponent<Renderer>().sortingLayerName= "Garbage_Text";
        }
        print(gameObject.GetComponent<SpriteRenderer>().bounds.size.y);
        garbageBoundY = gameObject.GetComponent<SpriteRenderer>().bounds.size.y / 2;
        GarbageNameTxt = Instantiate(CurrentLevelController.instance.GarbageNameText, transform.position + new Vector3(0, 1 + garbageBoundY, 0), Quaternion.identity) as GameObject;
        GarbageNameTxt.GetComponent<TextMesh>().text = GeorgianName;
        GarbageNameTxt.GetComponent<TextMesh>().color = currentTextColor;

    }

    void OnMouseDrag()
    {

        if (GlobalParams.IsPaused) return;
        point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(point.x, point.y, transform.position.z);
        if (CurrentLevelController.LevelN == 1)
            GarbageNameTxt.transform.position = transform.position + new Vector3(0, 1 + garbageBoundY, 5);
    }

    void OnMouseUp()
    {
        if (CurrentLevelController.LevelN == 1)
        {
            if (currentTxt.activeInHierarchy)
                    Destroy(currentTxt);
            Destroy(GarbageNameTxt);

            if (EnlargedBin != null)
            {
                EnlargedBin.GetComponent<Animator>().SetTrigger("Shrink");
            }
        }
             
        //print("drag is over");
        if(canBeDropped)
        {
            DropInBin(gameObject.tag);
            currentBin.GetComponent<AudioSource>().Play();
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
        CurrentLevelController.GarbageDropped++;
        GarbageAmountText.UpdateText();
        
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


