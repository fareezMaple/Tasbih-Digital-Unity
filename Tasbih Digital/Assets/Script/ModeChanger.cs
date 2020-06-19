using UnityEngine;
using UnityEngine.SceneManagement;

public class ModeChanger : MonoBehaviour
{

    public void changeMode()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            SceneManager.LoadScene(1); //load dark scene

        }
        else if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            SceneManager.LoadScene(0); //load light scene
        }
    }
}
