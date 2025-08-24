using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightObject : MonoBehaviour
{
    // Variable for the interactable object which should be highlighted
    public GameObject highlightedObject;

    // Variables for the r-,g-,b- and alpha values of the interactable object
    public int colorValueRed;
    public int colorValueGreen;
    public int colorValueBlue;
    public int colorValueAlpha;


    // Variable to indicate whether the ineteractable object is currently highlighted
    public bool highlighted = false;

    public GameObject particleSystemHighlight;

    // Variable for the initial position of the ineteractable object
    private Vector3 initialPosition;


    private void Start()
    {
        // Start the process of highlighting the interactable object
        startHighlightingObject();

        // Store the initial position values of the ineteractable object
        initialPosition = highlightedObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Set the colour of the material of the interactable object by accessing its red, green, blue, and alpha values
        highlightedObject.GetComponent<Renderer>().material.color = new Color32((byte)colorValueRed, (byte)colorValueGreen, (byte)colorValueBlue, (byte)colorValueAlpha);

        // When the interactalbe object has been moved by the user (and thus its current position != its initial position), stop the highlighting process, since the user already knows that the object is interactable
        if (Vector3.Distance(highlightedObject.transform.position, initialPosition) > 0.1f)
        {
            stopHighlightingObject();
        }

    }


    public void startHighlightingObject()
    {
        // Start the coroutine of highlighting the interactable object
        // A coroutine is used to create a smooth transition between the colour values, since the time it takes a method to count to certain threshold (here: 255) is faster than a frame on Unity
        StartCoroutine(highlightObject());
    }

    public void stopHighlightingObject()
    {
        // Stop the coroutine of highlighting the interactable object
        StopCoroutine(highlightObject());

        // Set the colour of the material of the interactable object to its default values
        highlightedObject.GetComponent<Renderer>().material.color = new Color32(255, 255, 255, 255);

        // To save performance, this instance of the script of the interactable object is disabled, since the interactable object won't be highlighted anymore and thus its script is no longer needed
        this.GetComponent<HighlightObject>().enabled = false;

        particleSystemHighlight.SetActive(false);
    }

    // Coroutine is a method from MonoBehavior that has an IEnumerator return type
    IEnumerator highlightObject()
    {

        while (true)
        {
            // Suspend the coroutine execution for the given amount of seconds
            yield return new WaitForSeconds(0.00001f);

            // Check whether the interactable object is highlighted
            if (highlighted == true)
            {
                // When the colour value (here the blue value is checked, but it doesn't matter which colour value is checked) reaches a minimum threshold, increase the r-,g-,b- valeus
                if (colorValueBlue <= 100)
                {
                    highlighted = false;
                }
                else
                {
                    colorValueRed -= 1;
                    colorValueGreen -= 1;
                    colorValueBlue -= 1;
                }
            }
            else
            {
                // When the colour value (here the blue value is checked, but it doesn't matter which colour value is checked) reaches a maximum threshold, decrease the r-,g-,b- valeus
                if (colorValueBlue >= 255)
                {
                    highlighted = true;
                }
                else
                {
                    colorValueRed += 1;
                    colorValueGreen += 1;
                    colorValueBlue += 1;
                }
            }

        }


    }

}
