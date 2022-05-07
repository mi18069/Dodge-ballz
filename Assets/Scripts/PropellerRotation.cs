using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PropellerRotation : MonoBehaviour
{
    [SerializeField, Range(1,5)] private float rotationSpeed = 1.5f;
    private double height = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        getHeight();
        rotation();
    }

    private void getHeight()
    {
        GameObject body = transform.parent.gameObject;
        float yPos = body.transform.position.y;
        height = Math.Pow(1.0f+yPos, 3.0f); // exponential accelerating
    }

    private void rotation() // Rotating the propeller along Y axis
    {
        transform.Rotate(0, 0, 180*rotationSpeed*Time.deltaTime*(float)height, Space.Self);
    }
}
