using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NavManager : MonoBehaviour
{
    public GameObject resetButton;
    public GameObject navBottom;

    public void resetGame()
    {
        PlayerPrefs.SetInt("mainCount", 0); //set to zero
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        resetButton.SetActive(false);
    }

    public void exitGame()
    {
        Debug.Log("APPLICATION IS EXIT");
        navBottom.SetActive(false);
        Application.Quit();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
