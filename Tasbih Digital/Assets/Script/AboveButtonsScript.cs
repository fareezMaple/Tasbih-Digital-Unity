using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AboveButtonsScript : MonoBehaviour
{
    public GameObject VibrateButtonIcon;
    public GameObject SoundButtonIcon;

    public GameObject infoPanel;

    private bool isMute;
    private bool isVibrate;

    // Start is called before the first frame update
    void Start()
    {
        isMute = false;
        isVibrate = true;
    }

    public void MuteSoundSwitch()
    {
        if (isMute)
        {
            isMute = false; //bukak sound
            SoundButtonIcon.GetComponent<CustomSpriteSwapper>().changeAlphaColour(!isMute);
            GameObject.Find("GameManager").GetComponent<AudioSource>().mute = false;
        } else
        {
            isMute = true; //tutup sound
            SoundButtonIcon.GetComponent<CustomSpriteSwapper>().changeAlphaColour(!isMute);
            GameObject.Find("GameManager").GetComponent<AudioSource>().mute = true;
            
        }
        
        Debug.Log("Sound is " + !isMute);
        PlayerPrefs.SetInt("SoundSetting", BoolConverter.instance.boolToInt(isMute));
    }

    public void VibrateSwitch()
    {
        if (isVibrate) //akan berfungsi macam suiz
        {
            isVibrate = false; //akan bervibrate
            VibrateButtonIcon.GetComponent<CustomSpriteSwapper>().changeAlphaColour(isVibrate);
            FindObjectOfType<GameManager>().isVibrateOn = isVibrate;
            Debug.Log("Vibrate is OFF");
        }
        else
        {
            isVibrate = true; //takkan tervibrate
            VibrateButtonIcon.GetComponent<CustomSpriteSwapper>().changeAlphaColour(isVibrate);
            FindObjectOfType<GameManager>().isVibrateOn = isVibrate;
            Debug.Log("Vibrate is ON");
        }
    }

    public void showPanel()
    {
        infoPanel.SetActive(!infoPanel.activeSelf);
    }

    public void openWebsite()
    {
        Application.OpenURL("https://sites.google.com/view/tasbihdigitalfareez/home");
    }
}
