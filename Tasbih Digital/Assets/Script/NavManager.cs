using System;
using UnityEngine;
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
    
    public void ResetAllPrefs()
    {
        throw new NotImplementedException("Future update");
        //TODO: implement to a button in settings or something.
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
