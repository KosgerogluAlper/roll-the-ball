using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class Pickable : MonoBehaviour
{
    private int scoreIncrease;
    ScoreManager scoreManager;
    [SerializeField] GameObject effect;
    [SerializeField] AudioClip collectSound;
    public void Awake()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
    }
    void Update()
    {
        scoreIncrease = Random.Range(7,15);
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(collectSound, transform.position);
           Instantiate(effect,transform.position,Quaternion.identity);
           Destroy(this.gameObject,0f);
            scoreManager.Score += scoreIncrease;   
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(collectSound, transform.position);
            Instantiate(effect, transform.position, Quaternion.identity);
          Destroy(this.gameObject,0f);
            scoreManager.Score += scoreIncrease; 
        }
    }
}
