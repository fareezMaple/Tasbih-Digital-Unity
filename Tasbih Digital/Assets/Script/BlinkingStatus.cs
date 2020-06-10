using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BlinkingStatus : MonoBehaviour
{
    public GameObject blinkingBar;
    private Image barColourImage;
    public bool isBlinking;

    private void Start()
    {
        barColourImage = blinkingBar.GetComponent<Image>();
    }

    IEnumerator Blink()
    {
        while (true)
        {
            switch (barColourImage.color.a) 
            {
                case 0f:
                    var color = barColourImage.color;
                    color = new Color(color.r, color.g, color.b, 1);
                    barColourImage.color = color;
                    yield return new WaitForSeconds(.5f);
                    break;
                case 1f:
                    var color1 = barColourImage.color;
                    color1 = new Color(color1.r, color1.g, color1.b, 0);
                    barColourImage.color = color1;
                    yield return new WaitForSeconds(.5f);
                    break;    
            }
        }
    }

    public void StartBlinking()
    {
        StopAllCoroutines();
        StartCoroutine("Blink");
        isBlinking = true;
    }

    public void StopBlinking()
    {
        StopAllCoroutines();
        //turn to off
        var color = barColourImage.color;
        color.a = 0;
        barColourImage.color = color;
        isBlinking = false;
    }
    
} //https://answers.unity.com/questions/1112861/how-can-i-make-a-ui-image-blink-on-and-off.html source
