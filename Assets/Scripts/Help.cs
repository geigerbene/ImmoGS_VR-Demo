using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using System.Linq;

public class Help : MonoBehaviour
{
    public GameObject uiControls;

    //Eine Variable vom Typ KeywordRecognizer wird deklariert.
    private KeywordRecognizer keywordRecognizer;


    //Ein neues Dictionary wird erstelltm welches bestimmte Befehle und damit zusammenhängende Aktionen enthält.
    Dictionary<string, System.Action> commands = new Dictionary<string, System.Action>();


    // Start is called before the first frame update
    void Start()
    {
        // TODO
        // System.Globalization.CultureInfo thaiCultureInfo = new System.Globalization.CultureInfo("en-EN");

        // TODO Dem Dictionary wird eine neue Funktion "WaterCalled" hinzugefügt, welche mit dem Schlüsselwort "Stop" ausgeführt wird.
        // ***Water***
        commands.Add("Help", () =>
        {
            helpCalled();
        });


        //Eine neue Variable vom Typ KeywordRecognizer wird deklariert, welche erkennen soll, ob ein Befehl, der im Dictionary enthalten ist, gesagt wird. 
        keywordRecognizer = new KeywordRecognizer(commands.Keys.ToArray());

        //Wenn ein Befehl wahrgenommen, so wird eine Funktion aufgerufen, welche erkennen soll, welcher Befehl erkannt wurde.
        keywordRecognizer.OnPhraseRecognized += commandRecognizer;
        keywordRecognizer.Start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void commandRecognizer(PhraseRecognizedEventArgs args)
    {
        System.Action commandAction;

        if (commands.TryGetValue(args.text, out commandAction))
        {
            commandAction.Invoke();
        }
    }

    void helpCalled()
    {
        uiControls.SetActive(true);
        Invoke("deactivateUI", 10);
    }

    private void deactivateUI()
    {
        uiControls.SetActive(false);
    }
}
