using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlinkingStatus : MonoBehaviour
{
    public GameObject blinkingBar;
    private Image barColourImage;
    
    // Start is called before the first frame update
    void Start()
    {
        barColourImage = gameObject.GetComponent<Image>();
    }

    IEnumerator Blink()
    {
        while (true)
        {
            switch (barColourImage.color.a.ToString()) 
            {
                case "0":
                    var color = barColourImage.color;
                    color = new Color(color.r, color.g, color.b, 1);
                    barColourImage.color = color;
                    yield return new WaitForSeconds(.5f);
                    break;
                case "1":
                    var color1 = barColourImage.color;
                    color1 = new Color(color1.r, color1.g, color1.b, 0);
                    barColourImage.color = color1;
                    yield return new WaitForSeconds(.5f);
                    break;    
            }
        }
    }

    private void StartBlinking()
    {
        StopAllCoroutines();
        StartCoroutine(Blink());
    }

    private void StopBlinking()
    {
        StopAllCoroutines();
    }
    
} //https://answers.unity.com/questions/1112861/how-can-i-make-a-ui-image-blink-on-and-off.html source
