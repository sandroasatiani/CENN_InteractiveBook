using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;



public class MechanismAnim : MonoBehaviour {

	public GameObject wheel;
	public GameObject header;
	public GameObject snake;
	public GameObject kbil_1;
	public GameObject kbil_2;
	public GameObject kbil_3;
	public GameObject kbil_4;
	public GameObject sensor;
	public GameObject reference_text;
	public GameObject reference_Product;
	public GameObject reference_Sprite;
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
	 static List<string> productTagName;
	float productY;
    public int Score = 180;

    public GameObject ScorePanel;

	void Start ()
	{
		headerPosition = header.transform.position;
		startX = headerPosition.x;
		rotVibZ = 2.0f;
		rotSnakeZ = -1.5f;
		ProductList = new List<GameObject>();
		productSprite = new List<Sprite>();
		productName = new List<string>();
		productTagName = new List<string>();
		addProductsInList ();
		showReference();
		productY = GameObject.Find ("roller").transform.position.y * 0.8f;

	}
	void generateReference()
	{
		rand = Random.Range (0, productSprite.Count);

		reference_Product.GetComponent<SpriteRenderer>().sprite = productSprite [rand];
		reference_text.GetComponent<TextMesh> ().text = "გააკეთე " + productName[rand];
	}
	void addDataInList(Sprite _sprite, string _productName, string _productTagName)
	{
		productSprite.Add (_sprite);
		productName.Add(_productName);
		productTagName.Add(_productTagName);
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
		addDataInList (Resources.Load<Sprite> ("products/metalic/chanchiki"),"მეტალის  \n ჭანჭიკი","m");
		addDataInList (Resources.Load<Sprite> ("products/metalic/konservis qila"),"მეტალის  \n ქილა","m");
		addDataInList (Resources.Load<Sprite> ("products/metalic/metalis dana"),"მეტალის  \n დანა","m");
		addDataInList (Resources.Load<Sprite> ("products/metalic/metalis tefshi"),"მეტალის  \n თეფში","m");
		addDataInList (Resources.Load<Sprite> ("products/metalic/metalis chaidani"),"მეტალის  \n ჩაიდანი","m");
		addDataInList (Resources.Load<Sprite> ("products/metalic/metalis kovzi"),"მეტალის  \n კოვზი ","m");
		addDataInList (Resources.Load<Sprite> ("products/metalic/metalis chiqa"),"მეტალის  \n ჭიქა","m");
		addDataInList (Resources.Load<Sprite> ("products/metalic/shurupi"),"მეტალის  \n შურუპი","m");

		//paper
		addDataInList (Resources.Load<Sprite> ("products/Paper/qagaldis chanta"),"ქაღალდის  \n ჩანთა","q");
		addDataInList (Resources.Load<Sprite> ("products/Paper/qagaldis ruloni"),"ქაღალდის  \n რულონი","q");
		addDataInList (Resources.Load<Sprite> ("products/Paper/wigni"),"წიგნი","q");
		addDataInList (Resources.Load<Sprite> ("products/Paper/yuti"),"ქაღალდის  \n ყუთი","q");

		//plastic
		addDataInList (Resources.Load<Sprite> ("products/Plastic/bottle"),"პლასტმასის  \n ბოთლი","p");
		addDataInList (Resources.Load<Sprite> ("products/Plastic/mirrorCleaner"),"მინის  \n საწმენდის ბოთლი","p");
		addDataInList (Resources.Load<Sprite> ("products/Plastic/plastmasis chagali da kovzi"),"პლასტმასის  \n ჩანგალი და კოვზი","p");
		addDataInList (Resources.Load<Sprite> ("products/Plastic/plastmasis chiqa"),"პლასტმასის  \n ჭიქა","p");
		addDataInList (Resources.Load<Sprite> ("products/Plastic/plastmasis jami"),"პლასტმასის  \n ჯამი","p");
		addDataInList (Resources.Load<Sprite> ("products/Plastic/plastmasis lego"),"პლასტმასის  \n ლეგო","p");
		addDataInList (Resources.Load<Sprite> ("products/Plastic/plastmasis sakidi"),"ტანსაცმლის  \n საკიდი","p");
		addDataInList (Resources.Load<Sprite> ("products/Plastic/plastmasis txevadi sapnis botli"),"თხევადი  \n საპნის ბოთლი","p");
		addDataInList (Resources.Load<Sprite> ("products/Plastic/plate"),"პლასტმასის  \n თეფში","p");

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
