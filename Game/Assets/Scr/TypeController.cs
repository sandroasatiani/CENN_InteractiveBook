using UnityEngine;
using System.Collections;

public class TypeController : MonoBehaviour {

    public GameObject setPlastic_Txt;
    public GameObject setOrganic_Txt;
    public GameObject setMetalic_Txt;
    public GameObject setPaper_Txt;

    public static GameObject Plastic_Txt;
    public static GameObject Organic_Txt;
    public static GameObject Metalic_Txt;
    public static GameObject Paper_Txt;

    void Start()
    {
        Plastic_Txt = setPlastic_Txt;
        Organic_Txt = setOrganic_Txt;
        Metalic_Txt = setMetalic_Txt;
        Paper_Txt = setPaper_Txt;
    }

}
