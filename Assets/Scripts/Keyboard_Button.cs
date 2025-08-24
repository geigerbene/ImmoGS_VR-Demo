using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Keyboard_Button : MonoBehaviour
{
    // Variable to access the GameObject of the keyboard, which holds the individual buttons
    Keyboard keyboard;
    // Variable for the text on the button
    TextMeshProUGUI buttonText;


    // Start is called before the first frame update
    void Start()
    {
        // Assign the GameObject of the keyboard to the corresponding variable
        keyboard = GetComponentInParent<Keyboard>();
        // Access the "TextMeshProUGUI" of the GameObject children of the current GameObject with the goal to display the name of the button-GameObject on the button's Canvas with the help of TextMeshProUGUI
        // Example: When the button is named "q", then the name "q" should be displayed on the button with the help of its component TextMeshProUGUI
        buttonText = GetComponentInChildren<TextMeshProUGUI>();


        // Check whether the length of the name of the button GameObject is 1, since a keyboard button should only have 1 character on it 
        if (buttonText.text.Length == 1)
        {
            // Call a function to store the name of the button-GameObject in a TextMeshProUGUI-variable
            nameToButtonText();
            // Access the "onRelease"-function of the "Button_General"-script
            // When the user presses and releases the button, the name of the button (= character on the button) is added to the string of the keyboard-text (= the typed username)
            GetComponentInChildren<Button_General>().onRelease.AddListener(delegate { keyboard.addCharacter(buttonText.text); });
        }
    }

    // Function to store the name of the button-GameObject in a TextMeshProUGUI-variable
    public void nameToButtonText()
    {
        // Access the text-component of the TextMeshProUGUI-variable "buttonText"
        // Store the name of the button-GameObject in the text-component of the TextMeshProUGUI-variable "buttonText"
        // With this variable, the name of the button-GameObject can subsequently be displayed on the button during runtime
        buttonText.text = gameObject.name;
    }

}
