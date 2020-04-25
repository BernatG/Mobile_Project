using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderController : MonoBehaviour
{
    public float rotation = 0; //50
    public float rotationAddition = 0;

    void Update()
    {
        rotation = rotation + rotationAddition;
        transform.Rotate(0, 0, rotation * Time.deltaTime); 

    }
}
