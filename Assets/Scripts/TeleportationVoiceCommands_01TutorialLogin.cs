using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class TeleportationVoiceCommands_01TutorialLogin : MonoBehaviour
{

    public float activeTime = 5;

    public GameObject user;
    
    public GameObject position_interaction;
    public GameObject position_laser;
    public GameObject position_logIn;
    

    //Eine Variable vom Typ KeywordRecognizer wird deklariert.
    private KeywordRecognizer keywordRecognizer;

    // Variable which is used to get the current state (1, 2,or 3). This string is attached to the giving animations (e.g. "Giving Rice 2"), so the speech recognition can work with the animator. 
    private string state;

    //Ein neues Dictionary wird erstelltm welches bestimmte Befehle und damit zusammenhängende Aktionen enthält.
    Dictionary<string, System.Action> commands = new Dictionary<string, System.Action>();




    // Start is called before the first frame update
    void Start()
    {
        // TODO
        System.Globalization.CultureInfo englishCultureInfo = new System.Globalization.CultureInfo("en-EN");



        // ***Show possible locations to teleport to***
        commands.Add("Destinations", () =>
        {
            position_interaction.SetActive(true);
            position_laser.SetActive(true);
            position_logIn.SetActive(true);

            Invoke("deactivatePositions", activeTime);

        });


        // ***Position Voice Commands***

        commands.Add("Interaction", () =>
        {
            position_interaction_Called();
            deactivatePositions();
        });

        commands.Add("Laser", () =>
        {
            position_laser_Called();
            deactivatePositions();
        });

        commands.Add("Log in", () =>
        {
            position_logIn_Called();
            deactivatePositions();
        });



        //Eine neue Variable vom Typ KeywordRecognizer wird deklariert, welche erkennen soll, ob ein Befehl, der im Dictionary enthalten ist, gesagt wird. 
        keywordRecognizer = new KeywordRecognizer(commands.Keys.ToArray());

        //Wenn ein Befehl wahrgenommen, so wird eine Funktion aufgerufen, welche erkennen soll, welcher Befehl erkannt wurde.
        keywordRecognizer.OnPhraseRecognized += commandRecognizer;
        keywordRecognizer.Start();


    }

    void deactivatePositions()
    {
        position_interaction.SetActive(false);
        position_laser.SetActive(false);
        position_logIn.SetActive(false);
    }

    void commandRecognizer(PhraseRecognizedEventArgs args)
    {
        System.Action commandAction;

        if (commands.TryGetValue(args.text, out commandAction))
        {
            commandAction.Invoke();
        }
    }




    // ****Teleport to Positions***
    void position_interaction_Called()
    {
        user.transform.position = position_interaction.transform.position;
    }

    void position_laser_Called()
    {
        user.transform.position = position_laser.transform.position;
    }

    void position_logIn_Called()
    {
        user.transform.position = position_logIn.transform.position;
    }



    // Update is called once per frame
    void Update()
    {
    }
}
