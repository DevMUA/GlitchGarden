using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] int timeToWait = 4;
    int currentSceneIndex;

    private void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if(currentSceneIndex == 0)
        {
            LoadStartScreen();
        }
    }

    public void LoadStartScreen()
    {
        StartCoroutine(DelayLevelLoad());
    }

    public void LoadSplashScreen()
    {
        SceneManager.LoadScene("Splash Screen");
    }

    public void LoadYouLose()
    {
        SceneManager.LoadScene("Lose Screen");
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Start Screen");
    }

    public void LoadOptionsMenu()
    {
        SceneManager.LoadScene("Options");
    }

    public void RestartScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
    IEnumerator DelayLevelLoad()
    {
        yield return new WaitForSeconds(timeToWait);
        LoadNextScene();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
