using UnityEngine;
using UnityEngine.SceneManagement;

public class ModeChanger : MonoBehaviour
{
    private string LAST_MODE = "lastMode";
    private void Awake()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt(LAST_MODE, 0));
    }

    public void changeMode()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            SceneManager.LoadScene(1); //load dark scene
            
        } else if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            SceneManager.LoadScene(0); //load light scene
        }
        
        PlayerPrefs.SetInt(LAST_MODE, SceneManager.GetActiveScene().buildIndex);
    }
    
}
