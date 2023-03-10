using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private float speed;
    private new Rigidbody rigidbody = null;
    private Vector3 movement;
    private Manager manager;
    private float xInput;
    private float zInput;
    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        manager = FindObjectOfType<Manager>();

    }
    void Update()
    {
        getInput();
    }
    private void FixedUpdate()
    {
        if (manager.isGameFinish == false && manager.isGameOver == false)
        {
            playerMove();
        }
        if (manager.isGameFinish || manager.isGameOver)
        {
            rigidbody.isKinematic = true;
        }
    }
    private void getInput()
    {
        xInput = Input.GetAxis("Horizontal");
        zInput = Input.GetAxis("Vertical");

        if(Input.GetKeyDown(KeyCode.Escape)) 
        {
            manager.EndPanel.SetActive(true);
            Time.timeScale = 0f;
        }
    }
    private void playerMove()
    {
        xInput *= speed;
        zInput *= speed;
        movement = new Vector3(xInput,0f,zInput);
        rigidbody.AddForce(movement);
    }

}
