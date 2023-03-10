using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    [SerializeField] private List<GameObject> DestroyAftergameObjects=new List<GameObject>();
    [SerializeField] GameObject WinPanel;
    [SerializeField] GameObject LosePanel;
    [SerializeField] private Text Timetext;
    [SerializeField] private Text Skor;
    public bool isGameFinish = false;
    public bool isGameOver = false;
    ScoreManager scoreManager;
    public void Awake()
    {
      scoreManager =GameObject.FindObjectOfType<ScoreManager>();
    }
    void Update()
    {
        timeShow();
        showPanel();
    }
    private void showPanel()
    {
        if ((int)scoreManager.Score >= 200 && isGameOver == false)
        {
            destroyObjects();
            foreach (GameObject allObject in DestroyAftergameObjects)
            {
                Destroy(allObject);
            }
            isGameFinish = true;
            WinPanel.SetActive(true);
            LosePanel.SetActive(false);
        }
        if (isGameOver == true)
        {
            destroyObjects();
            foreach (GameObject allobject in DestroyAftergameObjects)
            {
                Destroy(allobject);
            }
            LosePanel.SetActive(true);
            WinPanel.SetActive(false);
        }
    }
    private void destroyObjects()
    {
        DestroyAftergameObjects.AddRange(GameObject.FindGameObjectsWithTag("Objects"));
        DestroyAftergameObjects.AddRange(GameObject.FindGameObjectsWithTag("Enemy"));
    }
    private void timeShow()
    {
        Timetext.text = "Time : "+(int)Time.timeSinceLevelLoad;
        Skor.text = "Skor : "+(int)scoreManager.Score;
    }
}

