using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void Reset()
    {
        int currrentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currrentSceneIndex);
    }
    public void NextLevel()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        int totalSceneIndex = SceneManager.sceneCountInBuildSettings - 1;

        if (nextSceneIndex <= totalSceneIndex)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        if (nextSceneIndex > totalSceneIndex)
        {
            SceneManager.LoadScene(0);
        }
    }
}
