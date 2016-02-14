using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;



public class MechanismAnim : MonoBehaviour {

    public GameObject LoadingScreen;
	public GameObject wheel;
	public GameObject header;
	public GameObject snake;
	public GameObject kbil_1;
	public GameObject kbil_2;
	public GameObject kbil_3;
	public GameObject kbil_4;
	public GameObject sensor;
	public GameObject reference_text;
    public GameObject reference_StartText;
	public GameObject reference_Product;
	public GameObject reference_Sprite;
    public GameObject reference_Box;
	Vector3 headerPosition;
	static bool go = false;
	bool back = false;
	bool timeOver = false;
	bool startMotion = false;
	bool getProduct = false;
	bool subjectMotion = false;
	static float headerX;
	static string boxName;
	float startX;
	float rotVibZ;
	float rotSnakeZ;
	float time = 0;
	static int rand;
	static float speed = 5.0f;
	GameObject subject;
	GameObject product;
	List<GameObject> ProductList;
	List<Sprite> productSprite;
	List<string> productName;
    List<string> productType;
	static List<string> productTagName;
	float productY;
    public int Score = 180;

    public GameObject ScorePanel;

	void Start ()
	{
        GlobalParams.SettingsIsOpened = false;
		headerPosition = header.transform.position;
		startX = headerPosition.x;
		rotVibZ = 2.0f;
		rotSnakeZ = -1.5f;
		ProductList = new List<GameObject>();
		productSprite = new List<Sprite>();
        productType = new List<string>();
		productName = new List<string>();
		productTagName = new List<string>();
		addProductsInList ();
		showReference();
		productY = GameObject.Find ("roller").transform.position.y * 0.8f;
        Params.RecycleScore = Score;


	}
	void generateReference()
	{
		rand = Random.Range (0, productSprite.Count);

        if (productTagName[rand] == "m")
            reference_Box.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("yutebi/Am_2");
        else if (productTagName[rand] == "p")
            reference_Box.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("yutebi/Ap_4");
        else if (productTagName[rand] == "q")
            reference_Box.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("yutebi/Bq_9");
        else
            reference_Box.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("yutebi/Co_11");


		reference_Product.GetComponent<SpriteRenderer>().sprite = productSprite [rand];
        reference_StartText.GetComponent<TextMesh>().text = "გადაამუშავე " + productType[rand] + " ნარჩენები";
        if (productName[rand] != "კომპოსტი")
            reference_text.GetComponent<TextMesh>().text = "და დაამზადე " + productType[rand] + " " + productName[rand];
        else
            reference_text.GetComponent<TextMesh>().text = "და დაამზადე " +  productName[rand];
	}
    void addDataInList(string _productType, Sprite _sprite, string _productName, string _productTagName)
	{
		productSprite.Add (_sprite);
		productName.Add(_productName);
		productTagName.Add(_productTagName);
        productType.Add(_productType);
	}
	public static string returnTagReference()
	{
		string tag_name;
		tag_name = productTagName [rand];
		return tag_name;
	}
	void showReference()
	{
		Params.isChoosen = true;
		reference_Sprite.SetActive(true);
		generateReference ();
	}

	void addProductsInList()
	{
       
		//metalic
		addDataInList ("მეტალის", Resources.Load<Sprite> ("products/metalic/chanchiki"),"ბოლტი","m");
        addDataInList("მეტალის", Resources.Load<Sprite>("products/metalic/konservis qila"), "\n კონსერვის ქილა", "m");
		addDataInList ("მეტალის", Resources.Load<Sprite> ("products/metalic/metalis dana"),"დანა","m");
		addDataInList ("მეტალის", Resources.Load<Sprite> ("products/metalic/metalis tefshi"),"თეფში","m");
		addDataInList ("მეტალის", Resources.Load<Sprite> ("products/metalic/metalis chaidani"),"ჩაიდანი","m");
		addDataInList ("მეტალის", Resources.Load<Sprite> ("products/metalic/metalis kovzi"),"კოვზი ","m");
		addDataInList ("მეტალის", Resources.Load<Sprite> ("products/metalic/metalis chiqa"),  " ჭიქა","m");
	addDataInList ("მეტალის", Resources.Load<Sprite> ("products/metalic/shurupi"),"ვინტი","m");

		//paper
		addDataInList ("ქაღალდის",Resources.Load<Sprite> ("products/Paper/qagaldis chanta"),"ჩანთა","q");
		addDataInList ("ქაღალდის", Resources.Load<Sprite> ("products/Paper/qagaldis ruloni"),"რულონი","q");
		addDataInList ("ქაღალდის", Resources.Load<Sprite> ("products/Paper/wigni"),"რვეული","q");
		addDataInList ("ქაღალდის", Resources.Load<Sprite> ("products/Paper/yuti"),  "ყუთი","q");

		//plastic
     addDataInList("პლასტმასის", Resources.Load<Sprite>("products/Plastic/bottle"), "ბოთლი", "p");
     addDataInList("პლასტმასის", Resources.Load<Sprite>("products/Plastic/mirrorCleaner"), "მინის \n საწმენდის ჭურჭელი", "p");
     addDataInList("პლასტმასის", Resources.Load<Sprite>("products/Plastic/plastmasis chagali da kovzi"), "\n ჩანგალი და კოვზი", "p");
     addDataInList("პლასტმასის", Resources.Load<Sprite>("products/Plastic/plastmasis chiqa"), "ჭიქა", "p");
     addDataInList("პლასტმასის", Resources.Load<Sprite>("products/Plastic/plastmasis jami"), "ჯამი", "p");
     addDataInList("პლასტმასის", Resources.Load<Sprite>("products/Plastic/plastmasis lego"), "ლეგო", "p");
     addDataInList("პლასტმასის", Resources.Load<Sprite>("products/Plastic/plastmasis sakidi"), "\n ტასაცმლის საკიდი", "p");
     addDataInList("პლასტმასის", Resources.Load<Sprite>("products/Plastic/plastmasis txevadi sapnis botli"), "\n საპნის ჭურჭელი", "p");
	 addDataInList ("პლასტმასის", Resources.Load<Sprite> ("products/Plastic/plate")," თეფში","p");

        //organic
       addDataInList("ორგანული",Resources.Load<Sprite>("products/organic/kom"), "კომპოსტი", "o");

	}
	IEnumerator changeScreen() {
		yield return new WaitForSeconds(0.8f);
		if(ProductList.Count >=3 )
		{
            //Application.LoadLevel(Application.loadedLevel);
            // Load Next Level, Show Score
            ScorePanel.SetActive(true);
            //if (CurrentLevelController.LevelN <5)
            //    Application.LoadLevel("Level_Scene_" + (CurrentLevelController.LevelN+1).ToString());
		}
		else
		{
			
			showReference();
		}
	}
	public static void headerMotion(float _x, string name)
	{
		boxName = name;
 		headerX = _x;

		go = true;
	}
	void createProduct()
	{
		GameObject _product;
		_product = new GameObject();
		product = _product;
		product.name = "Product";
		product.AddComponent<SpriteRenderer> ();
		product.GetComponent<SpriteRenderer> ().sprite = productSprite [rand];
		product.transform.localScale = new Vector3 (0, 0, 0);
		product.transform.position = new Vector3(header.transform.position.x,header.transform.position.y, header.transform.position.z + 1);
		getProduct = true;

	}
	void Update ()
	{

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            LoadingScreen.SetActive(true);
            Application.LoadLevel("StartScene");
        }
		if (Params.startHeaderMotion){
			Params.isChoosen = true;
		}
		if (go)
		{
			if(header.transform.position.x < headerX)
			{
				float step = speed * Time.deltaTime;
				header.transform.position = Vector3.MoveTowards(header.transform.position,new Vector3(headerX,header.transform.position.y,header.transform.position.z),step);
				
			}
			else
			{
				go = false;
				subject = new GameObject ();
				subject.AddComponent<SpriteRenderer>();
				subject.name = "subject";
				subject.transform.localScale = new Vector3(1,1,1);
				GameObject.Find(boxName).GetComponent<itemBox>().getSubjectSpriteItem();
				subject.transform.position = GameObject.Find(boxName).transform.position;
				subjectMotion = true;
			}
		}
		if (subjectMotion)
		{
			if(subject.transform.position.y > header.transform.position.y)
			{
				float step = (speed-1) * Time.deltaTime;
				subject.transform.position = Vector3.MoveTowards(subject.transform.position,new Vector3(header.transform.position.x,header.transform.position.y,header.transform.position.z + 1),step);
				if(subject.transform.localScale.x >= 0)
					subject.transform.localScale = Vector3.Lerp(subject.transform.localScale,new Vector3(0,0,0),0.05f);
				subject.transform.Rotate (new Vector3 (0, 0, 4));
			}
			else
			{
				Destroy(subject);
				subjectMotion = false;
				back = true;
			}
		}
		if (back)
		{
			if(header.transform.position.x > startX)
			{
				float step = speed * Time.deltaTime;
				header.transform.position = Vector3.MoveTowards(header.transform.position,new Vector3(startX,header.transform.position.y,header.transform.position.z),step);
			}
			else
			{
				back = false;
				startMotion = true;
				timeOver = false;
			}
		}
		if (startMotion) {
			if (!timeOver)
			{
				wheel.transform.Rotate (new Vector3 (0, 0, 10));
				kbil_1.transform.Rotate (new Vector3 (0, 0, 4));
				kbil_2.transform.Rotate (new Vector3 (0, 0, -0.5f));
				kbil_3.transform.Rotate (new Vector3 (0, 0, 3));
				kbil_4.transform.Rotate (new Vector3 (0, 0, -1));
				sensor.transform.Rotate (new Vector3 (0, 0, rotVibZ));
				rotVibZ *= -1;
				rotSnakeZ *= -1;
				time+=0.1f;
				if(time >=15)
				{
					time = 0;
					timeOver = true;
					createProduct();
				}
			}
		}
		if (getProduct)
		{

			if(product.transform.position.y > productY)
			{
				float step = (speed-1) * Time.deltaTime;
				product.transform.position = Vector3.MoveTowards(product.transform.position,new Vector3(header.transform.position.x,productY,header.transform.position.z),step);
				if(product.transform.localScale.x < 1.4f)
					product.transform.localScale = Vector3.Lerp(product.transform.localScale,new Vector3(1.4f,1.4f,1.4f),0.05f);
				//product.transform.localScale = new Vector3(1.4f,1.4f,1.4f);
			}
			else
			{


				if( product.transform.position.x < header.transform.position.x + 2.3f)
				{
					float step = (speed-2) * Time.deltaTime;
					product.transform.position = Vector3.MoveTowards(product.transform.position,new Vector3(product.transform.position.x +  2.3f,product.transform.position.y,product.transform.position.z),step);
					for(int i = 0;i<ProductList.Count; i++)
					{
						ProductList[i].transform.position = Vector3.MoveTowards(ProductList[i].transform.position,new Vector3(ProductList[i].transform.position.x +  2.3f,ProductList[i].transform.position.y,ProductList[i].transform.position.z),step);
					}
				}
				else
				{
					ProductList.Add(product.gameObject);
					getProduct = false;
					Params.isChoosen = false;
					StartCoroutine(changeScreen());
						
				}
			}

		}
			

	}
}
