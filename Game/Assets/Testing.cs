using UnityEngine;
using System.Collections;
using System.Text;

public class Testing : MonoBehaviour {

    public string name;
	void Start () {

        // read the string as UTF-8 bytes.
        byte[] encodedBytes = Encoding.UTF8.GetBytes(GetComponent<TextMesh>().text);

    // convert them into unicode bytes.
    byte[] unicodeBytes = Encoding.Convert(Encoding.UTF8, Encoding.Unicode, encodedBytes);

    // builds the converted string.


    GetComponent<TextMesh>().text = Encoding.Unicode.GetString(encodedBytes);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
