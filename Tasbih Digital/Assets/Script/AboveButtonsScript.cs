using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AboveButtonsScript : MonoBehaviour
{
    public GameObject VibrateButtonIcon;
    public GameObject SoundButtonIcon;

    private bool isMute;
    private bool isVibrate;

    // Start is called before the first frame update
    void Start()
    {
        isMute = false;
        isVibrate = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MuteSoundSwitch()
    {
        if (isMute)
        {
            isMute = false; //bukak sound
            SoundButtonIcon.GetComponent<CustomSpriteSwapper>().changeAlphaColour(!isMute);
            Debug.Log("Sound is ON");
        } else
        {
            isMute = true; //tutup sound
            SoundButtonIcon.GetComponent<CustomSpriteSwapper>().changeAlphaColour(!isMute);
            Debug.Log("Sound is OFF");
        }
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
}
