using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    //public AudioSource soundPlayer;

    public void PlayGame()
    {
        SceneManager.LoadScene("BattleScene");
    }
    public void BackToMenu ()
    {
        SceneManager.LoadScene("MainHub");
        //CardManager.Instance.StartCardManager();
    }
    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void playAudio()
    {
        //soundPlayer.Play();
    }


    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
        
    }

    /*
    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "battlescene")
        {
            Debug.Log("battlescene test");
        }
    }
    */
}
