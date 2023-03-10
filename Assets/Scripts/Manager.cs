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
    [SerializeField] private List<GameObject> DestroyAftergameObjects = new List<GameObject>();
    [SerializeField] GameObject WinPanel;
    [SerializeField] GameObject LosePanel;
    [SerializeField] GameObject startPanel;
    [SerializeField] private Text Timetext;
    [SerializeField] private Text Skor;
    [SerializeField] private Text LevelText;
    private bool isStartPanelShow=false;
    public bool isGameFinish = false;
    public bool isGameOver = false;
    ScoreManager scoreManager;
    LevelManager levelManager;


    public GameObject StartPanel
    {
        get
        {
            return startPanel;
        }
        set
        {
            startPanel = value;
        }
    }

    public void Awake()
    {
        scoreManager = GameObject.FindObjectOfType<ScoreManager>();
        levelManager = GameObject.FindObjectOfType<LevelManager>();
    }
    public void Start()
    {
        if (isStartPanelShow == false &&!PlayerPrefs.HasKey("gameStarted"))
        {
            startPanel.SetActive(true);
            isStartPanelShow = false;
            PlayerPrefs.SetInt("gameStarted", 0);
        }
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
        Timetext.text = "Time : " + (int)Time.timeSinceLevelLoad;
        Skor.text = "Skor : " + (int)scoreManager.Score;
        LevelText.text = "Level : " + (levelManager.CurrentSceneIndex + 1);
    }
}

