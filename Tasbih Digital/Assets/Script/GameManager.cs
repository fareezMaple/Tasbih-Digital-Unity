using RDG;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text MainCountText;

    public GameObject resetButton;
    public Text buttonText;
    public Button mainButton;
    public float SecondsUntukVibarate;

    [HideInInspector]
    public int MainCount = 0;

    public bool isVibrateOn;
    public bool isSound;

    private AudioSource beepAudio;
    public AudioClip beepClip;

    public void updateCount()
    {
        buttonText.text = "+1";
        MainCount++;
        MainCountText.text = MainCount.ToString();
        PlayerPrefs.SetInt("mainCount", MainCount);
        
        if (isVibrateOn)
            hapticButton();

        if (isSound)
            beepAudio.PlayOneShot(beepClip);

    }

    public void hapticButton()
    {
        Vibration.Vibrate(49);
    }

    // Start is called before the first frame update
    void Start()
    {
        beepAudio = GetComponent<AudioSource>();
        MainCount = PlayerPrefs.GetInt("mainCount");
        MainCountText.text = MainCount.ToString();
        isVibrateOn = true;

        if (MainCount == 0)
            buttonText.text = "MULA";
        else
            buttonText.text = "SAMBUNG";
    }

    // Update is called once per frame
    void Update()
    {
        if (MainCount > 0)
            resetButton.SetActive(true);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            mainButton.onClick.Invoke(); //simulate 'space' button seolah2 tekan button
        }
    }
}
