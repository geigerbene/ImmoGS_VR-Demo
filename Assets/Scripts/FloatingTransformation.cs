using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: Random Amplitude


public class FloatingTransformation : MonoBehaviour
{

    // amplitude = maximum height with which the object floats up and down
    public float amplitude = 0.12f;


    // frequency = time interval in which the object floats up and down
    public float frequency = 0.5f;

    // Position Storage Variables
    Vector3 posOffset = new Vector3();
    Vector3 tempPos = new Vector3();

    // Use this for initialization
    void Start()
    {
        // Store the starting position & rotation of the object
        posOffset = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        // Float up/down with a Sin()
        tempPos = posOffset;

        tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * this.amplitude;

        transform.position = tempPos;

    }

}
