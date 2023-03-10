using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallControl : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject);
        if (collision.gameObject.tag == "Player")
        { FindObjectOfType<Manager>().isGameOver = true; }
    }
}
