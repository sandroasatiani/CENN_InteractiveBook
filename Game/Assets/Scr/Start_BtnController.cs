using UnityEngine;
using System.Collections;

public class Start_BtnController : MonoBehaviour {

    public GameObject SettingExpended;
    public GameObject Music_OffImg;

    void Start()
    {

        if (AudioListener.volume == 1)
        {
            if (Music_OffImg.activeInHierarchy)
                Music_OffImg.SetActive(false);
        }
        else if (AudioListener.volume == 0)
        {
            if (!Music_OffImg.activeInHierarchy)
                Music_OffImg.SetActive(true);

        }
    }
	public void ResetGame()
    {
        PlayerPrefs.DeleteAll();
    }

    public void ToggleSettingExpended()
    {
        SettingExpended.SetActive(!SettingExpended.activeInHierarchy);
        GlobalParams.SettingsIsOpened = !GlobalParams.SettingsIsOpened;
    }

    public void ToggleMusic()
    {
        if (AudioListener.volume == 1)

        {
            if (!Music_OffImg.activeInHierarchy)
                Music_OffImg.SetActive(true);
            AudioListener.volume = 0;
        }
        else if (AudioListener.volume == 0)
        {
            if (Music_OffImg.activeInHierarchy)
                Music_OffImg.SetActive(false);
            AudioListener.volume = 1;

        }
    }

}
