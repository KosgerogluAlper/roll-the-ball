using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject coinPrefab;
    [SerializeField] private GameObject EnemyPrefab;
    [SerializeField] private Transform[] spawnPozitions;
    [SerializeField] private GameObject[] randomGameObject;
    GameObject[] enemies;
 //   GameObject[] effects;

    private float enemySpawnPeriod = 4f;
    private float TotalTime = 0f;
    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        spawnObjects();
       // effects = GameObject.FindGameObjectsWithTag("Effect");
   
    }

    private void spawnObjects()
    {
        if (Time.timeSinceLevelLoad > TotalTime)
        {
            Manager m1 = FindObjectOfType<Manager>();
            if (m1.isGameFinish == false && m1.isGameOver == false && enemies.Length <= 3)
            {
                TotalTime += enemySpawnPeriod;
                spawnObject(randomGameObject[randomSpawnObjectNumber()], spawnPozitions[randomSpawnNumber()]);
            }
        }
    }
    private int randomSpawnNumber()
    {
        return Random.Range(0, spawnPozitions.Length);
    }
    private int randomSpawnObjectNumber()
    {
        return Random.Range(0, randomGameObject.Length);
    }
    private void spawnObject(GameObject objectToSpawn, Transform newPosition)
    {
        Instantiate(objectToSpawn, newPosition.position, newPosition.rotation);
    }
}
