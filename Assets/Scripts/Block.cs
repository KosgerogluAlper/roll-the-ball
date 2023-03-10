using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip hitSound;
    private bool isCollided = false;
    void OnCollisionEnter(Collision other)
    {
        if (isCollided == false && other.gameObject.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(hitSound, transform.position);
            GetComponent<MeshRenderer>().material.color = Color.red;
            ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
            scoreManager.Score -= 20;
            isCollided = true;
        }
    }
}
