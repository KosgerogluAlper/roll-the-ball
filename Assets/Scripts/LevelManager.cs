using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public int CurrentSceneIndex
    {
        get
        {
            return currrentSceneIndex;
        }
        set
        {
            currrentSceneIndex = value;
        }
    }
    private int currrentSceneIndex;
    Manager manager;
    public void Awake()
    {
        manager = GameObject.FindObjectOfType<Manager>();
    }
    private void Update()
    {
        currrentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    public void startPanelButton()
    {
        manager.StartPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Reset()
    {
        SceneManager.LoadScene(currrentSceneIndex);
    }

    public void nextLevel()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        int totalSceneIndex = SceneManager.sceneCountInBuildSettings - 1;

        if (nextSceneIndex <= totalSceneIndex)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        if (nextSceneIndex > totalSceneIndex)
        {
            PlayerPrefs.DeleteAll(); 
            SceneManager.LoadScene(0);
           
        }

    }
    public void exitEvent()
    {
        PlayerPrefs.DeleteAll();
        Application.Quit();
    }
    public void cancelEvent()
    {
       manager.EndPanel.SetActive(false);
        Time.timeScale = 1f;
    }

}
