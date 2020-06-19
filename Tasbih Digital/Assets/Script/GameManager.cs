using RDG;
using UnityEngine;
using UnityEngine.UI;
// ReSharper disable InconsistentNaming

public class GameManager : MonoBehaviour
{
    public Text MainCountText;
    public Slider progressBar;
    
    private int targetCount = 33;
    private int tempCount;

    public GameObject resetButton;
    public Text buttonText;
    public Button mainButton;
    public float SecondsUntukVibarate;

    [HideInInspector]
    public int MainCount = 0;

    public bool isVibrate;
    public bool isSound;

    private AudioSource beepAudio;

    private AboveButtonsScript buttonSettingScript;
    private BlinkingStatus blinkingStatus;

    public void updateCount()
    {
        buttonText.text = "+1";
        MainCount++;
        MainCountText.text = MainCount.ToString();
        
        tempCount++;
        
        progressBar.value++;

        if (blinkingStatus.isBlinking)
        {
            blinkingStatus.StopBlinking();
        }
        
        if (tempCount == targetCount)
        {
            progressBar.value = 0;
            tempCount = 0;
            //blink
            blinkingStatus.StartBlinking();
        }


        PlayerPrefs.SetInt("mainCount", MainCount);

        if (isVibrate)
            hapticButton();
        
        if (isSound)
            beepAudio.Play();
    }

    private void hapticButton()
    {
        Vibration.Vibrate(45); //45ms
    }

    // Start is called before the first frame update
    void Start()
    {
        buttonSettingScript = GameObject.Find("NavPanelAbove").GetComponent<AboveButtonsScript>();
        blinkingStatus = GetComponent<BlinkingStatus>();
        beepAudio = GetComponent<AudioSource>();
        MainCount = PlayerPrefs.GetInt("mainCount");

        tempCount = MainCount; //tempCount is used in progressBar
        
        MainCountText.text = MainCount.ToString(); //set the text in view

        if (MainCount >= targetCount) //logic to set the initial progressbar value
        {
            while (tempCount >= targetCount)
            {
                tempCount -= targetCount;
            }
        }

        progressBar.value = tempCount; //set progressbar in view

        //setting
        isVibrate = buttonSettingScript.onIsVibrate;
        isSound = buttonSettingScript.onIsSound;
        
        // Debug.Log("From GameManager, isSound is " + isSound + ", isVibrate is " + isVibrate);

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
