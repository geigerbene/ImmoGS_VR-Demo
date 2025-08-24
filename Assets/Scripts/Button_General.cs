using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Button_General : MonoBehaviour
{
    // Variable for the button, to which this script is attached to
    public GameObject button;
    // Unity event for pressing the button
    public UnityEvent onPress;
    // Unity event for releasing the button from pressing
    public UnityEvent onRelease;
    // Variable for the user who presses the button
    GameObject user;
    // Boolean to indicate whether the button is being pressed
    public bool isPressed;
    // Variable for the audio source which should be played when the button is pressed

    public float position_buttonPressed;
    public float position_buttonReleased;

    AudioSource clickSound;

    // Start is called before the first frame update
    void Start()
    {
        // Assign a audio file to the audio source which should be played when the button is pressed
        clickSound = GetComponent<AudioSource>();
        // Initially, the button is not being pressed
        isPressed = false;

    }

    // When GameObjectA (= user) collides with another GameObjectB (= interactable object), Unity calls OnTriggerEnter
    // Both GameObjects must contain a Collider component
    // GameObjectB (= interactable object) must have Collider.isTrigger enabled, and contain a Rigidbody
    // The variable Collider other refers to the user
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("PRESSED");

        // The following operations can only happen, when the button is not currently already pressed
        if (!isPressed)
        {
            // When the button is pressed, it should also move
            button.transform.localPosition = new Vector3(0, 0, position_buttonPressed);
            // GameObjectA = user 
            user = other.gameObject;
            // Invoke functions allow you to schedule method calls to occur at a later time. An invoke function "onPress" is created.
            onPress.Invoke();
            // The audio file is played when the button is pressed
            clickSound.Play();
            // Since the button is currently pressed, set isPressed to true
            isPressed = true;
        }
    }

    // When the collision between GameObjectA (= user) and GameObjectB (= interactable object) is released, Unity calls OnTriggerExit
    // Both GameObjects must contain a Collider component
    // GameObjectB (= interactable object) must have Collider.isTrigger enabled, and contain a Rigidbody
    // The variable Collider other refers to the user
    private void OnTriggerExit(Collider other)
    {
        // Check whether the collider which collides with the button is assigned to the user
        if (other.gameObject == user)
        {
            // When the button is released from pressing, it moves to its initial position
            button.transform.localPosition = new Vector3(0, 0, position_buttonReleased);
            // Invoke functions allow you to schedule method calls to occur at a later time. An invoke function "onRelease" is created.
            onRelease.Invoke();
            // Since the button is no longer pressed, set isPressed to false
            isPressed = false;
        }
    }

}
