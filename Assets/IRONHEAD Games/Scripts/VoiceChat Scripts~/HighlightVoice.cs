using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Voice.PUN;

public class HighlightVoice : MonoBehaviour
{
    // - Global variable for an UI-element which displays the local user whether their voice is recorded when they are currently speaking
    // - Serialization of the UI-element "micImage":
    // -- Conversion of "micImage" to a sequence of bytes, which holds information about the GameObjects characteristics, type, state, etc.
    // -- The sequence of bytes can be stored in memory, a database or a file
    // -- Subsequently, the sequence of bytes can be used to re-create the GameObject --> here: "micImage" is re-created in every virtual room to which the user might connect to (and subsequently leave)
    [SerializeField]
    private Image micImage;

    // - Global variable for an UI-element which displays the local user whether a remote user is currently speaking
    // - Serialization of the UI-element "speakerImage":
    // -- Conversion of "speakerImage" to a sequence of bytes, which holds information about the GameObjects characteristics, type, state, etc.
    // -- The sequence of bytes can be stored in memory, a database or a file
    // -- Subsequently, the sequence of bytes can be used to re-create the GameObject --> here: "speakerImage" is re-created in every virtual room to which the user might connect to (and subsequently leave)
    [SerializeField]
    private Image speakerImage;

    // - Global variable for the PhotonVoiceView component, which binds remote Recorder with local Speaker of the same networked prefab and makes automatic voice stream routing easy for users' characters
    // - Serialization of the variable for the PhotonVoiceView component:
    // -- Conversion of "photonVoiceView" to a sequence of bytes, which holds information about the GameObjects characteristics, type, state, etc.
    // -- The sequence of bytes can be stored in memory, a database or a file
    // -- Subsequently, the sequence of bytes can be used to re-create the GameObject --> here: "photonVoiceView" is re-created in every virtual room to which the user might connect to (and subsequently leave)
    [SerializeField]
    private PhotonVoiceView photonVoiceView;


    private void Awake()
    {
        // In the beginning, the UI elements "micImage" and "speakerImage" are disabled
        //micImage = GetComponentInParent<VoiceDebugUI>().transform.Find("Image_Mic").GetComponent<Image>();
        this.micImage.enabled = false;
        this.speakerImage.enabled = false;
    }
  

    // Update is called once per frame
    void Update()
    {
        // If the local user is currently speaking and PhotonVoiceView is transmitting the audio stream of the local user's voice via the recorder component, the UI element "micImage" is displyed
        this.micImage.enabled = this.photonVoiceView.IsRecording;
        // If the audio stream of a remote user is currently playing via the speaker component for the local user, the UI element "speakerImage" is displyed
        this.speakerImage.enabled = this.photonVoiceView.IsSpeaking;
    }
}
