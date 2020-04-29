using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] float waitForNewSceneLoad = 3;
    public void LoadNextScene()
    {
        //StartCoroutine(WaitForSceneToLoad());
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadFirstLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
    public void LoadStartScene()
    {
        //int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        //StartCoroutine(WaitForSceneToLoad());
        FindObjectOfType<GameState>().DestroyOnGameOver();
        SceneManager.LoadScene(0);
    }

    //private IEnumerator WaitForSceneToLoad()
    //{
    //    yield return new WaitForSeconds(waitForNewSceneLoad);
        
    //}

    public void Quit()
    {
        Application.Quit();
    }
}
