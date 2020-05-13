using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MaterialUI;
using UnityEngine.UI;

public class CustomSpriteSwapper : MonoBehaviour
{
    private Image spriteImage;
    private Color OriColour;

    // Start is called before the first frame update
    void Start()
    {
        spriteImage = GetComponent<Image>();
        OriColour = spriteImage.color;
    }

    public void changeAlphaColour(bool isFull) //AKAN di called pada function button masing2, apa2 adjust pada button tersebut
    {
        if (isFull)
        {
            OriColour.a = 1f;
        } else
        {
            OriColour.a = .45f;
        }

        spriteImage.color = OriColour;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
