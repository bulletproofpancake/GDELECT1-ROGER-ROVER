using System.Collections;
using System.Collections.Generic;
using Core;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenes : Singleton<Scenes>
{
    public void StartGame(string sceneName)
    {
        //AudioManager.Instance.Play("button");
        SceneManager.LoadScene(sceneName);
        //GameManager.Instance.StartGame();
        
    }

    public void Load(string sceneName)
    {
        gameManager.Instance.SetExitStats();
        SceneManager.LoadScene(sceneName);
    }

    public void QuitGame()
    {
        gameManager.Instance.SetExitStats();
        Application.Quit();
    }
}
