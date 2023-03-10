using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class RotateScript : MonoBehaviour
{
    private Vector3 angle = new Vector3(1,1,1);
    void FixedUpdate()
    {
        transform.Rotate(angle);
    }
}
