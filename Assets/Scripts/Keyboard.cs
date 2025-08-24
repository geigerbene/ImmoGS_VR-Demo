using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Keyboard : MonoBehaviour
{
    // Editable text input field which is displayed in the Canvas
    public TMP_InputField inputField;

    // Function to add a character when the user presses the corresponding keyboard button
    // Display the resulting string in the input field
    public void addCharacter(string character)
    {
        // Maximum 9 characters can be written as username
        if (inputField.text.Length <= 9)
        {
            // Add the character to the input field
            inputField.text += character;
        }
    }

    // Function to remove the last character of the string in te input field when the user presses the delete-button
    // Display the resulting string in the input field
    public void removeCharacter(string character)
    {
        // Check whether there are characters to delete
        if (inputField.text.Length > 0)
        {
            // Delete the last character of the string
            inputField.text = inputField.text.Substring(0, inputField.text.Length - 1);
        }
    }

}
