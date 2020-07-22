using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AboveButtonsScript : MonoBehaviour
{
    public GameObject VibrateButtonIcon;
    public GameObject SoundButtonIcon;

    private string SOUND_SETTING = "SoundSetting";
    private string VIBRATE_SETTING = "VibrateSetting";

    public GameObject infoPanel;
    private BoolConverter boolConverter;

    private bool isMute;
    private bool isVibrate;

    public bool onIsSound => !isMute; //return to other class
    public bool onIsVibrate => isVibrate; //return to other class

    void Start()
    {
        boolConverter = GetComponent<BoolConverter>();

        int tempIsMute = PlayerPrefs.GetInt(SOUND_SETTING, 0);
        int tempIsVibrate = PlayerPrefs.GetInt(VIBRATE_SETTING, 1); //convert 1 kpd true and vice versa
        isMute = boolConverter.intToBool(tempIsMute);
        isVibrate = boolConverter.intToBool(tempIsVibrate);

        SetInitialSettings(isMute, isVibrate);
        /* //debug
        Debug.Log("isMute is " + isMute + ", isVibrate is " + isVibrate);
        Debug.Log("onIsSound is " + onIsSound + ", oIsVibrate is " + onIsVibrate);
        */
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            //keyboard 'S'
            MuteSoundSwitch();
        }
    }

    public void MuteSoundSwitch()
    {
        if (isMute)
        {
            isMute = false; //bukak sound
            SoundButtonIcon.GetComponent<CustomSpriteSwapper>().changeAlphaColour(!isMute);
            FindObjectOfType<GameManager>().isSound = !isMute;
        } else
        {
            isMute = true; //tutup sound
            SoundButtonIcon.GetComponent<CustomSpriteSwapper>().changeAlphaColour(!isMute);
            FindObjectOfType<GameManager>().isSound = !isMute;
            
        }
        
        Debug.Log("Sound is " + !isMute);
        PlayerPrefs.SetInt(SOUND_SETTING, boolConverter.boolToInt(isMute));
    }

    public void VibrateSwitch()
    {
        if (isVibrate) //akan berfungsi macam suiz
        {
            isVibrate = false; //akan bervibrate
            VibrateButtonIcon.GetComponent<CustomSpriteSwapper>().changeAlphaColour(isVibrate);
            FindObjectOfType<GameManager>().isVibrate = isVibrate;
        }
        else
        {
            isVibrate = true; //takkan tervibrate
            VibrateButtonIcon.GetComponent<CustomSpriteSwapper>().changeAlphaColour(isVibrate);
            FindObjectOfType<GameManager>().isVibrate = isVibrate;
        }
        
        Debug.Log("Vibrate is " + isVibrate);
        PlayerPrefs.SetInt(VIBRATE_SETTING, boolConverter.boolToInt(isVibrate));
    }

    private void SetInitialSettings(bool mute, bool vibrate)
    {
        if (vibrate)
        {
            VibrateButtonIcon.GetComponent<CustomSpriteSwapper>().changeAlphaColour(vibrate);
        }
        else
        {
            VibrateButtonIcon.GetComponent<CustomSpriteSwapper>().changeAlphaColour(vibrate);
        }
        
        if (mute)
        {
            SoundButtonIcon.GetComponent<CustomSpriteSwapper>().changeAlphaColour(false);
        } else
        {
            SoundButtonIcon.GetComponent<CustomSpriteSwapper>().changeAlphaColour(true);
        }
    }

    public void showPanel()
    {
        infoPanel.SetActive(!infoPanel.activeSelf);
    }

    public void openWebsite(string URL)
    {
        Application.OpenURL(URL);
    }
}
