using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ModeChanger : MonoBehaviour
{
    private LevelLoader loader;

    private void Awake()
    {
        loader = GameObject.Find("LevelLoader").GetComponent<LevelLoader>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            changeMode();
        }
    }

    public void changeMode()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            //load dark scene
            loader.LoadNextLevel(1);

        }
        else if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            //load light scene
            loader.LoadNextLevel(0); 
        }
    }
}
