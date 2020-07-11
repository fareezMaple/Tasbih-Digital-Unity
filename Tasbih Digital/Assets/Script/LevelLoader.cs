using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadNextLevel(int whichScene)
    {
        StartCoroutine(LoadLevel(whichScene));
        Debug.Log("Started qorontine");
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        //Play animation
        transition.SetTrigger("Start");
        
        //wait
        yield return new WaitForSeconds(1f);
        
        //loadscene
        SceneManager.LoadScene(levelIndex);

    }
    
}//brakeys
