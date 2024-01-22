using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] int timeToWait=4;
    int currentSceneIndex;
    // Start is called before the first frame update
    void Start()
    {
        
        currentSceneIndex=SceneManager.GetActiveScene().buildIndex;
        if(currentSceneIndex==0)
        {
            StartCoroutine(WaitForTime());
    
        }
    }

    IEnumerator WaitForTime()
    {
        yield return new WaitForSeconds(timeToWait);
        LoadNextScene();


    }
    public void LoadNextScene()
    {
        currentSceneIndex=SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex+1);
    }

    public void RestartScene()
    {
        Time.timeScale=1;
        currentSceneIndex=SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void MainMenuScene()
    {
        Time.timeScale=1;
        SceneManager.LoadScene("Start Screen");
    }
    public void LoadLoseLevel(){
        SceneManager.LoadScene("Lose Screen");
    }
    // public void LoadWinLevel(){
    //     SceneManager.LoadScene("Win Screen");
    // }
    public void OptionsLevel(){
        SceneManager.LoadScene("Options Screen");
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
