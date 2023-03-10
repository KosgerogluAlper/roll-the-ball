using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    private Transform target;
    private void Awake()
    {
        target = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }
    void Update()
    {
        if (target != null)
        {
            transform.LookAt(target);
            float distance = Vector3.Distance(transform.position, target.position);
            if (distance > 1f)
            {
                transform.position += transform.forward * speed * Time.deltaTime;
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Manager timemanager = FindObjectOfType<Manager>();
            timemanager.isGameOver = true;
            Destroy(collision.gameObject);
        }
    }
}
