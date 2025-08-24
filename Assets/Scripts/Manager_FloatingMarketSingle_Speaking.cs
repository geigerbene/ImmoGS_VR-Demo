using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using System.Linq;
using UnityEngine.SceneManagement;

public class Manager_FloatingMarketSingle_Speaking : MonoBehaviour
{

    // ***** Phases Overview *****

    // ***Phase 1***
    // UI:      Ton ;   Text ;  Übersetzung                  

    // *** Phase 2***
    // UI:      Ton ;   Text    

    // *** Phase 3***
    // UI:      Ton    


    // *** Dictionary ***
    public GameObject dictionary;

    // *** Variables for General Phrases ***
    // ** Audio **
    public AudioSource audio_hello_normal;
    public AudioSource audio_ok;

    public GameObject water1;
    public GameObject rice1;
    public GameObject book1;
    public GameObject shirt1;



    // ** Info Bubble **
    // * Vendor *
    public GameObject infoBubble_hello_translation;
    public GameObject infoBubble_ok_translation;

    // * Phases *
    public GameObject infoBubble_phase1;
    public GameObject infoBubble_phase2;
    public GameObject infoBubble_phase3;

    // * Tasks *
    public GameObject infoBubble_water;
    public GameObject infoBubble_book;
    public GameObject infoBubble_rice;
    public GameObject infoBubble_shirt;

    //Eine Variable vom Typ KeywordRecognizer wird deklariert.
    private KeywordRecognizer keywordRecognizer;

    // Variable which is used to get the current state (1, 2,or 3). This string is attached to the giving animations (e.g. "Giving Rice 2"), so the speech recognition can work with the animator. 
    private string state;

    //Ein neues Dictionary wird erstelltm welches bestimmte Befehle und damit zusammenhängende Aktionen enthält.
    Dictionary<string, System.Action> commands = new Dictionary<string, System.Action>();



    [SerializeField] private Animator animationController_FloatingMarketSpeaking;
    // Use this for initialization
    void Start()
    {
        water1.SetActive(false);
        book1.SetActive(false);
        rice1.SetActive(false);
        shirt1.SetActive(false);


        // TODO
        System.Globalization.CultureInfo thaiCultureInfo = new System.Globalization.CultureInfo("th-TH");

        // TODO Dem Dictionary wird eine neue Funktion "WaterCalled" hinzugefügt, welche mit dem Schlüsselwort "Stop" ausgeführt wird.
        // ***Water***
        commands.Add("Ao nam kha", () =>
        {
            WaterCalled();
        });

        commands.Add("Ao nam krab", () =>
        {
            WaterCalled();
        });

        // ***Shirt***
        commands.Add("Ao süa kha", () =>
        {
            ShirtCalled();
        });

        commands.Add("Ao süa krab", () =>
        {
            ShirtCalled();
        });

        // ***Book***
        commands.Add("Ao nangsü kha", () =>
        {
            BookCalled();
        });

        commands.Add("Ao nangsü krab", () =>
        {
            BookCalled();
        });

        // ***Reis***
        commands.Add("Ao kao kha", () =>
        {
            RiceCalled();
        });

        commands.Add("Ao kao krab", () =>
        {
            RiceCalled();
        });



        //Eine neue Variable vom Typ KeywordRecognizer wird deklariert, welche erkennen soll, ob ein Befehl, der im Dictionary enthalten ist, gesagt wird. 
        keywordRecognizer = new KeywordRecognizer(commands.Keys.ToArray());

        //Wenn ein Befehl wahrgenommen, so wird eine Funktion aufgerufen, welche erkennen soll, welcher Befehl erkannt wurde.
        keywordRecognizer.OnPhraseRecognized += commandRecognizer;
        keywordRecognizer.Start();
    }


    public void StartProgram()
    {
        animationController_FloatingMarketSpeaking.SetBool("Start Program", true);

        dictionary.SetActive(true);
    }


    //Die Funktion erkennt, welcher im Dictionary enthaltene Befehl gesagt wurde und ruft daraufhin die damit zusammenhängende Befehlsfunktion auf.
    void commandRecognizer(PhraseRecognizedEventArgs args)
    {
        System.Action commandAction;

        if (commands.TryGetValue(args.text, out commandAction))
        {
            commandAction.Invoke();
        }
    }

    // TODO Wurde der Befehl "Stop" erkannt, so wird die AR-Szene geladen.
    void WaterCalled()
    {
        animationController_FloatingMarketSpeaking.SetBool("Correct Request", true);
        animationController_FloatingMarketSpeaking.Play("Giving Water " + state);
        audio_ok.Play();

        water1.SetActive(true);
    }

    void ShirtCalled()
    {
        animationController_FloatingMarketSpeaking.SetBool("Correct Request", true);
        animationController_FloatingMarketSpeaking.Play("Giving Shirt " + state);
        audio_ok.Play();

        shirt1.SetActive(true);
    }

    void BookCalled()
    {
        animationController_FloatingMarketSpeaking.SetBool("Correct Request", true);
        animationController_FloatingMarketSpeaking.Play("Giving Book " + state);
        audio_ok.Play();

        book1.SetActive(true);
    }

    void RiceCalled()
    {
        animationController_FloatingMarketSpeaking.SetBool("Correct Request", true);
        animationController_FloatingMarketSpeaking.Play("Giving Rice " + state);
        audio_ok.Play();

        rice1.SetActive(true);
    }


    private void Update()
    {

        // ***** Greeting *****
        if (animationController_FloatingMarketSpeaking.GetCurrentAnimatorStateInfo(0).IsName("Greeting"))
        {

            // **** Audio **** 
            if (animationController_FloatingMarketSpeaking.GetCurrentAnimatorStateInfo(0).normalizedTime <= 0.14)
            {
                audio_hello_normal.Play();
            }

            deactivateInfoBubbles();
            infoBubble_hello_translation.SetActive(true);

        }

        
        if (animationController_FloatingMarketSpeaking.GetCurrentAnimatorStateInfo(0).IsName("Giving Water 1") || animationController_FloatingMarketSpeaking.GetCurrentAnimatorStateInfo(0).IsName("Giving Water 2") || animationController_FloatingMarketSpeaking.GetCurrentAnimatorStateInfo(0).IsName("Giving Water 3") || animationController_FloatingMarketSpeaking.GetCurrentAnimatorStateInfo(0).IsName("Giving Rice 1") || animationController_FloatingMarketSpeaking.GetCurrentAnimatorStateInfo(0).IsName("Giving Rice 2") || animationController_FloatingMarketSpeaking.GetCurrentAnimatorStateInfo(0).IsName("Giving Rice 3") || animationController_FloatingMarketSpeaking.GetCurrentAnimatorStateInfo(0).IsName("Giving Shirt 1") || animationController_FloatingMarketSpeaking.GetCurrentAnimatorStateInfo(0).IsName("Giving Shirt 2") || animationController_FloatingMarketSpeaking.GetCurrentAnimatorStateInfo(0).IsName("Giving Shirt 3") || animationController_FloatingMarketSpeaking.GetCurrentAnimatorStateInfo(0).IsName("Giving Book 1") || animationController_FloatingMarketSpeaking.GetCurrentAnimatorStateInfo(0).IsName("Giving Book 2") || animationController_FloatingMarketSpeaking.GetCurrentAnimatorStateInfo(0).IsName("Giving Book 3"))
        {
            deactivateInfoBubbles();
            infoBubble_ok_translation.SetActive(true);
        }
        


            // ***** Phases *****

            // **** Phase 1 ****
        if (animationController_FloatingMarketSpeaking.GetCurrentAnimatorStateInfo(0).IsName("Phase 1"))
        {
            state = "1";

            deactivateInfoBubbles();
            infoBubble_phase1.SetActive(true);
        }

        // **** Phase 2 ****
        if (animationController_FloatingMarketSpeaking.GetCurrentAnimatorStateInfo(0).IsName("Phase 2"))
        {
            state = "2";

            water1.SetActive(false);
            book1.SetActive(false);
            rice1.SetActive(false);
            shirt1.SetActive(false);


            deactivateInfoBubbles();
            infoBubble_phase2.SetActive(true);
        }

        // **** Phase 3 ****
        if (animationController_FloatingMarketSpeaking.GetCurrentAnimatorStateInfo(0).IsName("Phase 3"))
        {
            state = "3";

            water1.SetActive(false);
            book1.SetActive(false);
            rice1.SetActive(false);
            shirt1.SetActive(false);


            deactivateInfoBubbles();
            infoBubble_phase3.SetActive(true);
        }

        // **** Course Completed ****
        if (animationController_FloatingMarketSpeaking.GetCurrentAnimatorStateInfo(0).IsName("Course Completed"))
        {
            deactivateInfoBubbles();
            dictionary.SetActive(false);

            Invoke("award", 2);
        }



        // **** Water ****
        if (animationController_FloatingMarketSpeaking.GetCurrentAnimatorStateInfo(0).IsName("Water 1") || animationController_FloatingMarketSpeaking.GetCurrentAnimatorStateInfo(0).IsName("Water 2") || animationController_FloatingMarketSpeaking.GetCurrentAnimatorStateInfo(0).IsName("Water 3"))
        {
            // **** Animator Parameter ****
            animationController_FloatingMarketSpeaking.SetBool("Correct Request", false);


            deactivateInfoBubbles();
            infoBubble_water.SetActive(true);
        }



        // **** Books ****
        if (animationController_FloatingMarketSpeaking.GetCurrentAnimatorStateInfo(0).IsName("Book 1") || animationController_FloatingMarketSpeaking.GetCurrentAnimatorStateInfo(0).IsName("Book 2") || animationController_FloatingMarketSpeaking.GetCurrentAnimatorStateInfo(0).IsName("Book 3"))
        {
            // **** Animator Parameter ****
            animationController_FloatingMarketSpeaking.SetBool("Correct Request", false);


            deactivateInfoBubbles();
            infoBubble_book.SetActive(true);
        }

        // **** Rice ****
        if (animationController_FloatingMarketSpeaking.GetCurrentAnimatorStateInfo(0).IsName("Rice 1") || animationController_FloatingMarketSpeaking.GetCurrentAnimatorStateInfo(0).IsName("Rice 2") || animationController_FloatingMarketSpeaking.GetCurrentAnimatorStateInfo(0).IsName("Rice 3"))
        {
            // **** Animator Parameter ****
            animationController_FloatingMarketSpeaking.SetBool("Correct Request", false);


            deactivateInfoBubbles();
            infoBubble_rice.SetActive(true);
        }

        // **** Shirts ****
        if (animationController_FloatingMarketSpeaking.GetCurrentAnimatorStateInfo(0).IsName("Shirt 1") || animationController_FloatingMarketSpeaking.GetCurrentAnimatorStateInfo(0).IsName("Shirt 2") || animationController_FloatingMarketSpeaking.GetCurrentAnimatorStateInfo(0).IsName("Shirt 3"))
        {
            // **** Animator Parameter ****
            animationController_FloatingMarketSpeaking.SetBool("Correct Request", false);



            deactivateInfoBubbles();
            infoBubble_shirt.SetActive(true);
        }


    }


    private void deactivateInfoBubbles()
    {
        // *** Info Bubble ***
        // * Vendor *
        infoBubble_hello_translation.SetActive(false);
        infoBubble_ok_translation.SetActive(false);

        // * Phases *
        infoBubble_phase1.SetActive(false);
        infoBubble_phase2.SetActive(false);
        infoBubble_phase3.SetActive(false);

        // * Tasks *
        infoBubble_water.SetActive(false);
        infoBubble_book.SetActive(false);
        infoBubble_rice.SetActive(false);
        infoBubble_shirt.SetActive(false);
    }

    private void award()
    {
        SceneManager.LoadScene("02_FloatingMarketSingle_Award");
    }
}