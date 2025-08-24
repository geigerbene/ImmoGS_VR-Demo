using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager_FloatingMarketSingle_Listening : MonoBehaviour
{

    // ***** Phases Overview *****
    
    // ***Phase 1***
    // Charakter: 	Ton Normal; Ton Langsam; Text ; Übersetzung
    // Vokabel: 	Ton Normal; Ton Langsam; Text

    // *** Phase 2***
    // Charakter: 	Ton Normal; Ton Langsam; Text
    // Vokabel: 	Ton Normal; Ton Langsam; Text

    // *** Phase 3***
    // Charakter: 	Ton Normal; Ton Langsam;
    // Vokabel: 	Ton Normal; Ton Langsam;

    // ***Phase 4***
    // Charakter: 	Ton Normal
    // Vokabel:
    
    
    /*

            infoBubble_phase1.SetActive(false);
            infoBubble_phase2.SetActive(false);
            infoBubble_phase3.SetActive(false);
            infoBubble_phase4.SetActive(false);

            infoBubble_hello_translation.SetActive(false);
            infoBubble_thankYou_translation.SetActive(false);
            infoBubble_iDontWant_translation.SetActive(false);
            infoBubble_thankYou.SetActive(false);
            infoBubble_iDontWant.SetActive(false);

            infoBubble_iWantWater_translation.SetActive(false);
            infoBubble_iWantBook_translation.SetActive(false);
            infoBubble_iWantRice_translation.SetActive(false);
            infoBubble_iWantShirt_translation.SetActive(false);

            infoBubble_iWantWater.SetActive(false);
            infoBubble_iWantBook.SetActive(false);
            infoBubble_iWantRice.SetActive(false);
            infoBubble_iWantShirt.SetActive(false);

    */




    // ***** General Variables *****
    // Variables for the initial positions of the interactable vocabulary objects
    private Vector3 water_originalPosition;
    private Vector3 book_originalPosition;
    private Vector3 rice_originalPosition;
    private Vector3 shirt_originalPosition;

    // UI
    public GameObject ui_programCompleted;

    // *** Audio ***
    public AudioSource audio_dropPlatform;
    
    // *** Variables for General Phrases ***
    // ** Audio **
    public AudioSource audio_hello_normal;
    public AudioSource audio_thankYou_normal;
    public AudioSource audio_iDontWant_normal;

    public AudioSource audio_askingForWater_normalSlow;
    public AudioSource audio_askingForBook_normalSlow;
    public AudioSource audio_askingForRice_normalSlow;
    public AudioSource audio_askingForShirt_normalSlow;

    public AudioSource audio_askingForWater_normal;
    public AudioSource audio_askingForBook_normal;
    public AudioSource audio_askingForRice_normal;
    public AudioSource audio_askingForShirt_normal;

    // ** Info Bubble **
    public GameObject infoBubble_hello_translation;
    public GameObject infoBubble_thankYou_translation;
    public GameObject infoBubble_iDontWant_translation;
    public GameObject infoBubble_thankYou;
    public GameObject infoBubble_iDontWant;

    public GameObject infoBubble_iWantWater_translation;
    public GameObject infoBubble_iWantBook_translation;
    public GameObject infoBubble_iWantRice_translation;
    public GameObject infoBubble_iWantShirt_translation;

    public GameObject infoBubble_iWantWater;
    public GameObject infoBubble_iWantBook;
    public GameObject infoBubble_iWantRice;
    public GameObject infoBubble_iWantShirt;


    // ***** Phase 1 *****
    public GameObject infoBubble_phase1;
    // Variables for interactable vocabulary objects
    public GameObject water1;
    public GameObject book1;
    public GameObject rice1;
    public GameObject shirt1;


    // ***** Phase 2 *****
    public GameObject infoBubble_phase2;
    // Variables for interactable vocabulary objects
    public GameObject water2;
    public GameObject book2;
    public GameObject rice2;
    public GameObject shirt2;


    // ***** Phase 3 *****
    public GameObject infoBubble_phase3;
    // Variables for interactable vocabulary objects
    public GameObject water3;
    public GameObject book3;
    public GameObject rice3;
    public GameObject shirt3;


    // ***** Phase 4 *****
    public GameObject infoBubble_phase4;
    // Variables for interactable vocabulary objects
    public GameObject water4;
    public GameObject book4;
    public GameObject rice4;
    public GameObject shirt4;

    // Variable for the animation controller of the female Asian customer character in scene 
    [SerializeField] private Animator AnimatorController_FemaleAsian01;


    void Start()
    {
        // Get the initial positions of the interactable vocabulary objects
        water_originalPosition = new Vector3(water1.transform.position.x, water1.transform.position.y, water1.transform.position.z);
        book_originalPosition = new Vector3(book1.transform.position.x, book1.transform.position.y, book1.transform.position.z);
        rice_originalPosition = new Vector3(rice1.transform.position.x, rice1.transform.position.y, rice1.transform.position.z);
        shirt_originalPosition = new Vector3(shirt1.transform.position.x, shirt1.transform.position.y, shirt1.transform.position.z);

    }


    // Start the language program when the user presses the "Start"-button
    public void StartProgram()
    {
        AnimatorController_FemaleAsian01.SetBool("Start Program", true);
    }


    // ***** Animations *****
    // When the object which collides with the drag table is the currently required the interactable vocabulary objects, then play the corresponding animation
    // When the object which collides with the drag table is not the currently required the interactable vocabulary objects, then play the corresponding animation
    private void OnTriggerEnter(Collider other)
    {

        Debug.Log(" ***** Name: " + other.name + ", Layer: " + other.gameObject.layer + " *****");

        // ***** Play drop-audio when user drops item on drop platfrom *****
        if(other.gameObject.layer == 9)
        { 
            audio_dropPlatform.Play();
        }

        // ***** Phase 1 *****

        // **** Water ****
        if ( (AnimatorController_FemaleAsian01.GetCurrentAnimatorStateInfo(0).IsName("Waiting: Water 1") || AnimatorController_FemaleAsian01.GetCurrentAnimatorStateInfo(0).IsName("Asking: Water 1")) )
        {
            if(other.name == "Water1" || other.name == "Water Attach Transform")
            {
                AnimatorController_FemaleAsian01.SetBool("Correct Selection", true);
                water1.SetActive(false);
                AnimatorController_FemaleAsian01.Play("Correct: Water 1");
                AnimatorController_FemaleAsian01.SetBool("Correct Selection", false);

            }
            // ***** Hand Bug Fix *****
            else if (other.gameObject.layer != 9)
            {
                // audio_askingForWater_normalSlow.Play();
            }
            else
            {
                AnimatorController_FemaleAsian01.SetBool("Correct Selection", false);
                AnimatorController_FemaleAsian01.Play("Incorrect: Water 1");
            }
        }

        // **** Book ****
        if ((AnimatorController_FemaleAsian01.GetCurrentAnimatorStateInfo(0).IsName("Waiting: Book 1") || AnimatorController_FemaleAsian01.GetCurrentAnimatorStateInfo(0).IsName("Asking: Book 1")))
        {
            if (other.name == "Book1" || other.name == "Book Attach Transform")
            {
                AnimatorController_FemaleAsian01.SetBool("Correct Selection", true);
                book1.SetActive(false);
                AnimatorController_FemaleAsian01.Play("Correct: Book 1");
                AnimatorController_FemaleAsian01.SetBool("Correct Selection", false);

            }
            // ***** Hand Bug Fix *****
            else if (other.gameObject.layer != 9)
            {
                // audio_askingForBook_normalSlow.Play();
            }
            else
            {
                AnimatorController_FemaleAsian01.SetBool("Correct Selection", false);
                AnimatorController_FemaleAsian01.Play("Incorrect: Book 1");
            }
        }

        // **** Rice ****
        if ((AnimatorController_FemaleAsian01.GetCurrentAnimatorStateInfo(0).IsName("Waiting: Rice 1") || AnimatorController_FemaleAsian01.GetCurrentAnimatorStateInfo(0).IsName("Asking: Rice 1")))
        {
            if (other.name == "Rice1" || other.name == "Rice Attach Transform")
            {
                AnimatorController_FemaleAsian01.SetBool("Correct Selection", true);
                rice1.SetActive(false);
                AnimatorController_FemaleAsian01.Play("Correct: Rice 1");
                AnimatorController_FemaleAsian01.SetBool("Correct Selection", false);

            }
            // ***** Hand Bug Fix *****
            else if (other.gameObject.layer != 9)
            {
                // audio_askingForRice_normalSlow.Play();
            }
            else
            {
                AnimatorController_FemaleAsian01.SetBool("Correct Selection", false);
                AnimatorController_FemaleAsian01.Play("Incorrect: Rice 1");
            }
        }

        // **** Shirt ****
        if ((AnimatorController_FemaleAsian01.GetCurrentAnimatorStateInfo(0).IsName("Waiting: Shirt 1") || AnimatorController_FemaleAsian01.GetCurrentAnimatorStateInfo(0).IsName("Asking: Shirt 1")))
        {
            if (other.name == "Shirt1" || other.name == "Shirt Attach Transform")
            {
                AnimatorController_FemaleAsian01.SetBool("Correct Selection", true);
                shirt1.SetActive(false);
                AnimatorController_FemaleAsian01.Play("Correct: Shirt 1");
                AnimatorController_FemaleAsian01.SetBool("Correct Selection", false);
                AnimatorController_FemaleAsian01.SetBool("Phase Completed", true);
            }
            // ***** Hand Bug Fix *****
            else if (other.gameObject.layer != 9)
            {
                // audio_askingForShirt_normalSlow.Play();
            }
            else
            {
                AnimatorController_FemaleAsian01.SetBool("Correct Selection", false);
                AnimatorController_FemaleAsian01.Play("Incorrect: Shirt 1");
            }
        }



        // **** Reset Positions ****
        // When the object which collides with the drag table is not the currently required the interactable vocabulary objects, then reset the object's position

        // Water
        if ( (!AnimatorController_FemaleAsian01.GetCurrentAnimatorStateInfo(0).IsName("Waiting: Water 1") || !AnimatorController_FemaleAsian01.GetCurrentAnimatorStateInfo(0).IsName("Asking: Water 1")) && other.name == "Water1" )
        {
            water1.transform.position = water_originalPosition;
        }

        // Book
        if ( (!AnimatorController_FemaleAsian01.GetCurrentAnimatorStateInfo(0).IsName("Waiting: Book 1") || !AnimatorController_FemaleAsian01.GetCurrentAnimatorStateInfo(0).IsName("Asking: Book 1")) && other.name == "Book1" )
        {
            book1.transform.position = book_originalPosition;
        }

        // Rice
        if ( (!AnimatorController_FemaleAsian01.GetCurrentAnimatorStateInfo(0).IsName("Waiting: Rice 1") || !AnimatorController_FemaleAsian01.GetCurrentAnimatorStateInfo(0).IsName("Asking: Rice 1")) && other.name == "Rice1" )
        {
            rice1.transform.position = rice_originalPosition;
        }

        // Shirt
        if ( (!AnimatorController_FemaleAsian01.GetCurrentAnimatorStateInfo(0).IsName("Waiting: Shirt 1") || !AnimatorController_FemaleAsian01.GetCurrentAnimatorStateInfo(0).IsName("Asking: Shirt 1")) && other.name == "Shirt1" )
        {
            shirt1.transform.position = shirt_originalPosition;
        }





        // ***** Phase 2 *****

        // **** Water ****
        if ((AnimatorController_FemaleAsian01.GetCurrentAnimatorStateInfo(0).IsName("Waiting: Water 2") || AnimatorController_FemaleAsian01.GetCurrentAnimatorStateInfo(0).IsName("Asking: Water 2")))
        {
            if (other.name == "Water2" || other.name == "Water Attach Transform")
            {
                AnimatorController_FemaleAsian01.SetBool("Correct Selection", true);
                water2.SetActive(false);
                AnimatorController_FemaleAsian01.Play("Correct: Water 2");
                AnimatorController_FemaleAsian01.SetBool("Correct Selection", false);

            }
            // ***** Hand Bug Fix *****
            else if (other.gameObject.layer != 9)
            {
                // audio_askingForWater_normalSlow.Play();
            }
            else
            {
                AnimatorController_FemaleAsian01.SetBool("Correct Selection", false);
                AnimatorController_FemaleAsian01.Play("Incorrect: Water 2");
            }
        }

        // **** Book ****
        if ((AnimatorController_FemaleAsian01.GetCurrentAnimatorStateInfo(0).IsName("Waiting: Book 2") || AnimatorController_FemaleAsian01.GetCurrentAnimatorStateInfo(0).IsName("Asking: Book 2")))
        {
            if (other.name == "Book2" || other.name == "Book Attach Transform")
            {
                AnimatorController_FemaleAsian01.SetBool("Correct Selection", true);
                book2.SetActive(false);
                AnimatorController_FemaleAsian01.Play("Correct: Book 2");
                AnimatorController_FemaleAsian01.SetBool("Correct Selection", false);

            }
            // ***** Hand Bug Fix *****
            else if (other.gameObject.layer != 9)
            {
                // audio_askingForBook_normalSlow.Play();
            }
            else
            {
                AnimatorController_FemaleAsian01.SetBool("Correct Selection", false);
                AnimatorController_FemaleAsian01.Play("Incorrect: Book 2");
            }
        }

        // **** Rice ****
        if ((AnimatorController_FemaleAsian01.GetCurrentAnimatorStateInfo(0).IsName("Waiting: Rice 2") || AnimatorController_FemaleAsian01.GetCurrentAnimatorStateInfo(0).IsName("Asking: Rice 2")))
        {
            if (other.name == "Rice2" || other.name == "Rice Attach Transform")
            {
                AnimatorController_FemaleAsian01.SetBool("Correct Selection", true);
                rice2.SetActive(false);
                AnimatorController_FemaleAsian01.Play("Correct: Rice 2");
                AnimatorController_FemaleAsian01.SetBool("Correct Selection", false);
                AnimatorController_FemaleAsian01.SetBool("Phase Completed", true);
            }
            // ***** Hand Bug Fix *****
            else if (other.gameObject.layer != 9)
            {
                // audio_askingForRice_normalSlow.Play();
            }
            else
            {
                AnimatorController_FemaleAsian01.SetBool("Correct Selection", false);
                AnimatorController_FemaleAsian01.Play("Incorrect: Rice 2");
            }
        }

        // **** Shirt ****
        if ((AnimatorController_FemaleAsian01.GetCurrentAnimatorStateInfo(0).IsName("Waiting: Shirt 2") || AnimatorController_FemaleAsian01.GetCurrentAnimatorStateInfo(0).IsName("Asking: Shirt 2")))
        {
            if (other.name == "Shirt2" || other.name == "Shirt Attach Transform")
            {
                AnimatorController_FemaleAsian01.SetBool("Correct Selection", true);
                shirt2.SetActive(false);
                AnimatorController_FemaleAsian01.Play("Correct: Shirt 2");
                AnimatorController_FemaleAsian01.SetBool("Correct Selection", false);
            }
            // ***** Hand Bug Fix *****
            else if (other.gameObject.layer != 9)
            {
                // audio_askingForShirt_normalSlow.Play();
            }
            else
            {
                AnimatorController_FemaleAsian01.SetBool("Correct Selection", false);
                AnimatorController_FemaleAsian01.Play("Incorrect: Shirt 2");
            }
        }



        // **** Reset Positions ****
        // When the object which collides with the drag table is not the currently required the interactable vocabulary objects, then reset the object's position

        // Water
        if ((!AnimatorController_FemaleAsian01.GetCurrentAnimatorStateInfo(0).IsName("Waiting: Water 2") || !AnimatorController_FemaleAsian01.GetCurrentAnimatorStateInfo(0).IsName("Asking: Water 2")) && other.name == "Water2")
        {
            water2.transform.position = water_originalPosition;
        }

        // Book
        if ((!AnimatorController_FemaleAsian01.GetCurrentAnimatorStateInfo(0).IsName("Waiting: Book 2") || !AnimatorController_FemaleAsian01.GetCurrentAnimatorStateInfo(0).IsName("Asking: Book 2")) && other.name == "Book2")
        {
            book2.transform.position = book_originalPosition;
        }

        // Rice
        if ((!AnimatorController_FemaleAsian01.GetCurrentAnimatorStateInfo(0).IsName("Waiting: Rice 2") || !AnimatorController_FemaleAsian01.GetCurrentAnimatorStateInfo(0).IsName("Asking: Rice 2")) && other.name == "Rice2")
        {
            rice2.transform.position = rice_originalPosition;
        }

        // Shirt
        if ((!AnimatorController_FemaleAsian01.GetCurrentAnimatorStateInfo(0).IsName("Waiting: Shirt 2") || !AnimatorController_FemaleAsian01.GetCurrentAnimatorStateInfo(0).IsName("Asking: Shirt 2")) && other.name == "Shirt2")
        {
            shirt2.transform.position = shirt_originalPosition;
        }




        // ***** Phase 3 *****

        // **** Water ****
        if ((AnimatorController_FemaleAsian01.GetCurrentAnimatorStateInfo(0).IsName("Waiting: Water 3") || AnimatorController_FemaleAsian01.GetCurrentAnimatorStateInfo(0).IsName("Asking: Water 3")))
        {
            if (other.name == "Water3" || other.name == "Water Attach Transform")
            {
                AnimatorController_FemaleAsian01.SetBool("Correct Selection", true);
                water3.SetActive(false);
                AnimatorController_FemaleAsian01.Play("Correct: Water 3");
                AnimatorController_FemaleAsian01.SetBool("Correct Selection", false);

            }
            // ***** Hand Bug Fix *****
            else if (other.gameObject.layer != 9)
            {
                // audio_askingForWater_normalSlow.Play();
            }
            else
            {
                AnimatorController_FemaleAsian01.SetBool("Correct Selection", false);
                AnimatorController_FemaleAsian01.Play("Incorrect: Water 3");
            }
        }

        // **** Book ****
        if ((AnimatorController_FemaleAsian01.GetCurrentAnimatorStateInfo(0).IsName("Waiting: Book 3") || AnimatorController_FemaleAsian01.GetCurrentAnimatorStateInfo(0).IsName("Asking: Book 3")))
        {
            if (other.name == "Book3" || other.name == "Book Attach Transform")
            {
                AnimatorController_FemaleAsian01.SetBool("Correct Selection", true);
                book3.SetActive(false);
                AnimatorController_FemaleAsian01.Play("Correct: Book 3");
                AnimatorController_FemaleAsian01.SetBool("Correct Selection", false);
                AnimatorController_FemaleAsian01.SetBool("Phase Completed", true);
            }
            // ***** Hand Bug Fix *****
            else if (other.gameObject.layer != 9)
            {
                // audio_askingForBook_normalSlow.Play();
            }
            else
            {
                AnimatorController_FemaleAsian01.SetBool("Correct Selection", false);
                AnimatorController_FemaleAsian01.Play("Incorrect: Book 3");
            }
        }

        // **** Rice ****
        if ((AnimatorController_FemaleAsian01.GetCurrentAnimatorStateInfo(0).IsName("Waiting: Rice 3") || AnimatorController_FemaleAsian01.GetCurrentAnimatorStateInfo(0).IsName("Asking: Rice 3")))
        {
            if (other.name == "Rice3" || other.name == "Rice Attach Transform")
            {
                AnimatorController_FemaleAsian01.SetBool("Correct Selection", true);
                rice3.SetActive(false);
                AnimatorController_FemaleAsian01.Play("Correct: Rice 3");
                AnimatorController_FemaleAsian01.SetBool("Correct Selection", false);
                
            }
            // ***** Hand Bug Fix *****
            else if (other.gameObject.layer != 9)
            {
                // audio_askingForRice_normalSlow.Play();
            }
            else
            {
                AnimatorController_FemaleAsian01.SetBool("Correct Selection", false);
                AnimatorController_FemaleAsian01.Play("Incorrect: Rice 3");
            }
        }

        // **** Shirt ****
        if ((AnimatorController_FemaleAsian01.GetCurrentAnimatorStateInfo(0).IsName("Waiting: Shirt 3") || AnimatorController_FemaleAsian01.GetCurrentAnimatorStateInfo(0).IsName("Asking: Shirt 3")))
        {
            if (other.name == "Shirt3" || other.name == "Shirt Attach Transform")
            {
                AnimatorController_FemaleAsian01.SetBool("Correct Selection", true);
                shirt3.SetActive(false);
                AnimatorController_FemaleAsian01.Play("Correct: Shirt 3");
                AnimatorController_FemaleAsian01.SetBool("Correct Selection", false);
            }
            // ***** Hand Bug Fix *****
            else if (other.gameObject.layer != 9)
            {
                // audio_askingForShirt_normalSlow.Play();
            }
            else
            {
                AnimatorController_FemaleAsian01.SetBool("Correct Selection", false);
                AnimatorController_FemaleAsian01.Play("Incorrect: Shirt 3");
            }
        }



        // **** Reset Positions ****
        // When the object which collides with the drag table is not the currently required the interactable vocabulary objects, then reset the object's position

        // Water
        if ((!AnimatorController_FemaleAsian01.GetCurrentAnimatorStateInfo(0).IsName("Waiting: Water 3") || !AnimatorController_FemaleAsian01.GetCurrentAnimatorStateInfo(0).IsName("Asking: Water 3")) && other.name == "Water3")
        {
            water3.transform.position = water_originalPosition;
        }

        // Book
        if ((!AnimatorController_FemaleAsian01.GetCurrentAnimatorStateInfo(0).IsName("Waiting: Book 3") || !AnimatorController_FemaleAsian01.GetCurrentAnimatorStateInfo(0).IsName("Asking: Book 3")) && other.name == "Book3")
        {
            book3.transform.position = book_originalPosition;
        }

        // Rice
        if ((!AnimatorController_FemaleAsian01.GetCurrentAnimatorStateInfo(0).IsName("Waiting: Rice 3") || !AnimatorController_FemaleAsian01.GetCurrentAnimatorStateInfo(0).IsName("Asking: Rice 3")) && other.name == "Rice3")
        {
            rice3.transform.position = rice_originalPosition;
        }

        // Shirt
        if ((!AnimatorController_FemaleAsian01.GetCurrentAnimatorStateInfo(0).IsName("Waiting: Shirt 3") || !AnimatorController_FemaleAsian01.GetCurrentAnimatorStateInfo(0).IsName("Asking: Shirt 3")) && other.name == "Shirt3")
        {
            shirt3.transform.position = shirt_originalPosition;
        }




        // ***** Phase 4 *****

        // **** Water ****
        if ((AnimatorController_FemaleAsian01.GetCurrentAnimatorStateInfo(0).IsName("Waiting: Water 4") || AnimatorController_FemaleAsian01.GetCurrentAnimatorStateInfo(0).IsName("Asking: Water 4")))
        {
            if (other.name == "Water4" || other.name == "Water Attach Transform")
            {
                AnimatorController_FemaleAsian01.SetBool("Correct Selection", true);
                water4.SetActive(false);
                AnimatorController_FemaleAsian01.Play("Correct: Water 4");
                AnimatorController_FemaleAsian01.SetBool("Correct Selection", false);
                AnimatorController_FemaleAsian01.SetBool("Phase Completed", true);
            }
            // ***** Hand Bug Fix *****
            else if (other.gameObject.layer != 9)
            {
                // audio_askingForWater_normalSlow.Play();
            }
            else
            {
                AnimatorController_FemaleAsian01.SetBool("Correct Selection", false);
                AnimatorController_FemaleAsian01.Play("Incorrect: Water 4");
            }
        }

        // **** Book ****
        if ((AnimatorController_FemaleAsian01.GetCurrentAnimatorStateInfo(0).IsName("Waiting: Book 4") || AnimatorController_FemaleAsian01.GetCurrentAnimatorStateInfo(0).IsName("Asking: Book 4")))
        {
            if (other.name == "Book4" || other.name == "Book Attach Transform")
            {
                AnimatorController_FemaleAsian01.SetBool("Correct Selection", true);
                book4.SetActive(false);
                AnimatorController_FemaleAsian01.Play("Correct: Book 4");
                AnimatorController_FemaleAsian01.SetBool("Correct Selection", false);
            }
            // ***** Hand Bug Fix *****
            else if (other.gameObject.layer != 9)
            {
                // audio_askingForBook_normalSlow.Play();
            }
            else
            {
                AnimatorController_FemaleAsian01.SetBool("Correct Selection", false);
                AnimatorController_FemaleAsian01.Play("Incorrect: Book 4");
            }
        }

        // **** Rice ****
        if ((AnimatorController_FemaleAsian01.GetCurrentAnimatorStateInfo(0).IsName("Waiting: Rice 4") || AnimatorController_FemaleAsian01.GetCurrentAnimatorStateInfo(0).IsName("Asking: Rice 4")))
        {
            if (other.name == "Rice4" || other.name == "Rice Attach Transform")
            {
                AnimatorController_FemaleAsian01.SetBool("Correct Selection", true);
                rice4.SetActive(false);
                AnimatorController_FemaleAsian01.Play("Correct: Rice 4");
                AnimatorController_FemaleAsian01.SetBool("Correct Selection", false);

            }
            // ***** Hand Bug Fix *****
            else if (other.gameObject.layer != 9)
            {
                // audio_askingForRice_normalSlow.Play();
            }
            else
            {
                AnimatorController_FemaleAsian01.SetBool("Correct Selection", false);
                AnimatorController_FemaleAsian01.Play("Incorrect: Rice 4");
            }
        }

        // **** Shirt ****
        if ((AnimatorController_FemaleAsian01.GetCurrentAnimatorStateInfo(0).IsName("Waiting: Shirt 4") || AnimatorController_FemaleAsian01.GetCurrentAnimatorStateInfo(0).IsName("Asking: Shirt 4")))
        {
            if (other.name == "Shirt4" || other.name == "Shirt Attach Transform")
            {
                AnimatorController_FemaleAsian01.SetBool("Correct Selection", true);
                shirt4.SetActive(false);
                AnimatorController_FemaleAsian01.Play("Correct: Shirt 4");
                AnimatorController_FemaleAsian01.SetBool("Correct Selection", false);
            }
            // ***** Hand Bug Fix *****
            else if (other.gameObject.layer != 9)
            {
                // audio_askingForShirt_normalSlow.Play();
            }
            else
            {
                AnimatorController_FemaleAsian01.SetBool("Correct Selection", false);
                AnimatorController_FemaleAsian01.Play("Incorrect: Shirt 4");
            }
        }



        // **** Reset Positions ****
        // When the object which collides with the drag table is not the currently required the interactable vocabulary objects, then reset the object's position

        // Water
        if ((!AnimatorController_FemaleAsian01.GetCurrentAnimatorStateInfo(0).IsName("Waiting: Water 4") || !AnimatorController_FemaleAsian01.GetCurrentAnimatorStateInfo(0).IsName("Asking: Water 4")) && other.name == "Water4")
        {
            water4.transform.position = water_originalPosition;
        }

        // Book
        if ((!AnimatorController_FemaleAsian01.GetCurrentAnimatorStateInfo(0).IsName("Waiting: Book 4") || !AnimatorController_FemaleAsian01.GetCurrentAnimatorStateInfo(0).IsName("Asking: Book 4")) && other.name == "Book4")
        {
            book4.transform.position = book_originalPosition;
        }

        // Rice
        if ((!AnimatorController_FemaleAsian01.GetCurrentAnimatorStateInfo(0).IsName("Waiting: Rice 4") || !AnimatorController_FemaleAsian01.GetCurrentAnimatorStateInfo(0).IsName("Asking: Rice 4")) && other.name == "Rice4")
        {
            rice4.transform.position = rice_originalPosition;
        }

        // Shirt
        if ((!AnimatorController_FemaleAsian01.GetCurrentAnimatorStateInfo(0).IsName("Waiting: Shirt 4") || !AnimatorController_FemaleAsian01.GetCurrentAnimatorStateInfo(0).IsName("Asking: Shirt 4")) && other.name == "Shirt4")
        {
            shirt4.transform.position = shirt_originalPosition;
        }


    }


    private void Update()
    {
        // ***** Greeting *****
        if (AnimatorController_FemaleAsian01.GetCurrentAnimatorStateInfo(0).IsName("Greeting"))
        {

            // **** Audio **** 
            if (AnimatorController_FemaleAsian01.GetCurrentAnimatorStateInfo(0).normalizedTime <= 0.14)
            {
                audio_hello_normal.Play();
            }

            // **** Info Bubble ****
            deactivateInfoBubbles();
            infoBubble_hello_translation.SetActive(true);
        }



        // ***** Phase 1 *****

        // **** General ****
        if (AnimatorController_FemaleAsian01.GetCurrentAnimatorStateInfo(0).IsName("Phase 1"))
        {
            // **** Info Bubble ****
            deactivateInfoBubbles();
            infoBubble_phase1.SetActive(true);

        }

        // **** Water ****
        if (AnimatorController_FemaleAsian01.GetCurrentAnimatorStateInfo(0).IsName("Asking: Water 1"))
        {

            // *** Audio ***
            if (AnimatorController_FemaleAsian01.GetCurrentAnimatorStateInfo(0).normalizedTime <= 0.14)
            {
                audio_askingForWater_normalSlow.Play();
            }

            // **** Info Bubble ****
            deactivateInfoBubbles();
            infoBubble_iWantWater_translation.SetActive(true);
        }

        // **** Book ****
        if (AnimatorController_FemaleAsian01.GetCurrentAnimatorStateInfo(0).IsName("Asking: Book 1"))
        {

            // *** Audio ***
            if (AnimatorController_FemaleAsian01.GetCurrentAnimatorStateInfo(0).normalizedTime <= 0.14)
            {
                audio_askingForBook_normalSlow.Play();
            }


            // **** Info Bubble ****
            deactivateInfoBubbles();
            infoBubble_iWantBook_translation.SetActive(true);
        }

        // **** Rice ****
        if (AnimatorController_FemaleAsian01.GetCurrentAnimatorStateInfo(0).IsName("Asking: Rice 1"))
        {

            // *** Audio ***
            if (AnimatorController_FemaleAsian01.GetCurrentAnimatorStateInfo(0).normalizedTime <= 0.14)
            {
                audio_askingForRice_normalSlow.Play();
            }

            // **** Info Bubble ****
            deactivateInfoBubbles();
            infoBubble_iWantRice_translation.SetActive(true);
        }

        // **** Shirt ****
        if (AnimatorController_FemaleAsian01.GetCurrentAnimatorStateInfo(0).IsName("Asking: Shirt 1"))
        {

            // *** Audio ***
            if (AnimatorController_FemaleAsian01.GetCurrentAnimatorStateInfo(0).normalizedTime <= 0.14)
            {
                audio_askingForShirt_normalSlow.Play();
            }

            // **** Info Bubble ****
            deactivateInfoBubbles();
            infoBubble_iWantShirt_translation.SetActive(true);
        }

        // **** Correct ****
        if (AnimatorController_FemaleAsian01.GetCurrentAnimatorStateInfo(0).IsName("Correct: Water 1") || AnimatorController_FemaleAsian01.GetCurrentAnimatorStateInfo(0).IsName("Correct: Book 1") || AnimatorController_FemaleAsian01.GetCurrentAnimatorStateInfo(0).IsName("Correct: Rice 1") || AnimatorController_FemaleAsian01.GetCurrentAnimatorStateInfo(0).IsName("Correct: Shirt 1"))
        {

            // *** Audio ***
            if (AnimatorController_FemaleAsian01.GetCurrentAnimatorStateInfo(0).normalizedTime <= 0.14)
            {
                stopAudioCharacter();
                audio_thankYou_normal.Play();
            }

            // **** Info Bubble ****
            deactivateInfoBubbles();
            infoBubble_thankYou_translation.SetActive(true);
        }

        // **** Incorrect ****
        if (AnimatorController_FemaleAsian01.GetCurrentAnimatorStateInfo(0).IsName("Incorrect: Water 1") || AnimatorController_FemaleAsian01.GetCurrentAnimatorStateInfo(0).IsName("Incorrect: Book 1") || AnimatorController_FemaleAsian01.GetCurrentAnimatorStateInfo(0).IsName("Incorrect: Rice 1") || AnimatorController_FemaleAsian01.GetCurrentAnimatorStateInfo(0).IsName("Incorrect: Shirt 1"))
        {

            // *** Audio ***
            if (AnimatorController_FemaleAsian01.GetCurrentAnimatorStateInfo(0).normalizedTime <= 0.14)
            {
                stopAudioCharacter();
                audio_iDontWant_normal.Play();
            }

            // **** Info Bubble ****
            deactivateInfoBubbles();
            infoBubble_iDontWant_translation.SetActive(true);
        }





        // ***** Phase 2 *****

        // **** General ****
        if (AnimatorController_FemaleAsian01.GetCurrentAnimatorStateInfo(0).IsName("Phase 2"))
        {
            AnimatorController_FemaleAsian01.SetBool("Phase Completed", false);

            // **** Info Bubble ****
            deactivateInfoBubbles();
            infoBubble_phase2.SetActive(true);


            // **** Objects ****
            water2.SetActive(true);
            book2.SetActive(true);
            rice2.SetActive(true);
            shirt2.SetActive(true);
        }

        // **** Water ****
        if (AnimatorController_FemaleAsian01.GetCurrentAnimatorStateInfo(0).IsName("Asking: Water 2"))
        {

            // *** Audio ***
            if (AnimatorController_FemaleAsian01.GetCurrentAnimatorStateInfo(0).normalizedTime <= 0.14)
            {
                audio_askingForWater_normalSlow.Play();
            }

            // **** Info Bubble ****
            deactivateInfoBubbles();
            infoBubble_iWantWater.SetActive(true);
        }

        // **** Book ****
        if (AnimatorController_FemaleAsian01.GetCurrentAnimatorStateInfo(0).IsName("Asking: Book 2"))
        {

            // *** Audio ***
            if (AnimatorController_FemaleAsian01.GetCurrentAnimatorStateInfo(0).normalizedTime <= 0.14)
            {
                audio_askingForBook_normalSlow.Play();
            }

            // **** Info Bubble ****
            deactivateInfoBubbles();
            infoBubble_iWantBook.SetActive(true);
        }

        // **** Rice ****
        if (AnimatorController_FemaleAsian01.GetCurrentAnimatorStateInfo(0).IsName("Asking: Rice 2"))
        {

            // *** Audio ***
            if (AnimatorController_FemaleAsian01.GetCurrentAnimatorStateInfo(0).normalizedTime <= 0.14)
            {
                audio_askingForRice_normalSlow.Play();
            }

            // **** Info Bubble ****
            deactivateInfoBubbles();
            infoBubble_iWantRice.SetActive(true);
        }

        // **** Shirt ****
        if (AnimatorController_FemaleAsian01.GetCurrentAnimatorStateInfo(0).IsName("Asking: Shirt 2"))
        {

            // *** Audio ***
            if (AnimatorController_FemaleAsian01.GetCurrentAnimatorStateInfo(0).normalizedTime <= 0.14)
            {
                audio_askingForShirt_normalSlow.Play();
            }

            // **** Info Bubble ****
            deactivateInfoBubbles();
            infoBubble_iWantShirt.SetActive(true);
        }

        // **** Correct ****
        if (AnimatorController_FemaleAsian01.GetCurrentAnimatorStateInfo(0).IsName("Correct: Water 2") || AnimatorController_FemaleAsian01.GetCurrentAnimatorStateInfo(0).IsName("Correct: Book 2") || AnimatorController_FemaleAsian01.GetCurrentAnimatorStateInfo(0).IsName("Correct: Rice 2") || AnimatorController_FemaleAsian01.GetCurrentAnimatorStateInfo(0).IsName("Correct: Shirt 2"))
        {

            // *** Audio ***
            if (AnimatorController_FemaleAsian01.GetCurrentAnimatorStateInfo(0).normalizedTime <= 0.14)
            {
                stopAudioCharacter();
                audio_thankYou_normal.Play();
            }

            // **** Info Bubble ****
            deactivateInfoBubbles();
            infoBubble_thankYou.SetActive(true);
        }

        // **** Incorrect ****
        if (AnimatorController_FemaleAsian01.GetCurrentAnimatorStateInfo(0).IsName("Incorrect: Water 2") || AnimatorController_FemaleAsian01.GetCurrentAnimatorStateInfo(0).IsName("Incorrect: Book 2") || AnimatorController_FemaleAsian01.GetCurrentAnimatorStateInfo(0).IsName("Incorrect: Rice 2") || AnimatorController_FemaleAsian01.GetCurrentAnimatorStateInfo(0).IsName("Incorrect: Shirt 2"))
        {

            // *** Audio ***
            if (AnimatorController_FemaleAsian01.GetCurrentAnimatorStateInfo(0).normalizedTime <= 0.14)
            {
                stopAudioCharacter();
                audio_iDontWant_normal.Play();
            }

            // **** Info Bubble ****
            deactivateInfoBubbles();
            infoBubble_iDontWant.SetActive(true);
        }





        // ***** Phase 3 *****

        // **** General ****
        if (AnimatorController_FemaleAsian01.GetCurrentAnimatorStateInfo(0).IsName("Phase 3"))
        {
            AnimatorController_FemaleAsian01.SetBool("Phase Completed", false);

            // **** Info Bubble ****
            deactivateInfoBubbles();
            infoBubble_phase3.SetActive(true);

            // **** Objects ****
            water3.SetActive(true);
            book3.SetActive(true);
            rice3.SetActive(true);
            shirt3.SetActive(true);
        }

        // **** Water ****
        if (AnimatorController_FemaleAsian01.GetCurrentAnimatorStateInfo(0).IsName("Asking: Water 3"))
        {

            // *** Audio ***
            if (AnimatorController_FemaleAsian01.GetCurrentAnimatorStateInfo(0).normalizedTime <= 0.14)
            {
                audio_askingForWater_normalSlow.Play();
            }

            // **** Info Bubble ****
            deactivateInfoBubbles();

        }

        // **** Book ****
        if (AnimatorController_FemaleAsian01.GetCurrentAnimatorStateInfo(0).IsName("Asking: Book 3"))
        {

            // *** Audio ***
            if (AnimatorController_FemaleAsian01.GetCurrentAnimatorStateInfo(0).normalizedTime <= 0.14)
            {
                audio_askingForBook_normalSlow.Play();
            }

            // **** Info Bubble ****
            deactivateInfoBubbles();

        }

        // **** Rice ****
        if (AnimatorController_FemaleAsian01.GetCurrentAnimatorStateInfo(0).IsName("Asking: Rice 3"))
        {

            // *** Audio ***
            if (AnimatorController_FemaleAsian01.GetCurrentAnimatorStateInfo(0).normalizedTime <= 0.14)
            {
                audio_askingForRice_normalSlow.Play();
            }

            // **** Info Bubble ****
            deactivateInfoBubbles();

        }

        // **** Shirt ****
        if (AnimatorController_FemaleAsian01.GetCurrentAnimatorStateInfo(0).IsName("Asking: Shirt 3"))
        {

            // *** Audio ***
            if (AnimatorController_FemaleAsian01.GetCurrentAnimatorStateInfo(0).normalizedTime <= 0.14)
            {
                audio_askingForShirt_normalSlow.Play();
            }

            // **** Info Bubble ****
            deactivateInfoBubbles();

        }

        // **** Correct ****
        if (AnimatorController_FemaleAsian01.GetCurrentAnimatorStateInfo(0).IsName("Correct: Water 3") || AnimatorController_FemaleAsian01.GetCurrentAnimatorStateInfo(0).IsName("Correct: Book 3") || AnimatorController_FemaleAsian01.GetCurrentAnimatorStateInfo(0).IsName("Correct: Rice 3") || AnimatorController_FemaleAsian01.GetCurrentAnimatorStateInfo(0).IsName("Correct: Shirt 3"))
        {

            // *** Audio ***
            if (AnimatorController_FemaleAsian01.GetCurrentAnimatorStateInfo(0).normalizedTime <= 0.14)
            {
                stopAudioCharacter();
                audio_thankYou_normal.Play();
            }

            // **** Info Bubble ****
            deactivateInfoBubbles();

        }

        // **** Incorrect ****
        if (AnimatorController_FemaleAsian01.GetCurrentAnimatorStateInfo(0).IsName("Incorrect: Water 3") || AnimatorController_FemaleAsian01.GetCurrentAnimatorStateInfo(0).IsName("Incorrect: Book 3") || AnimatorController_FemaleAsian01.GetCurrentAnimatorStateInfo(0).IsName("Incorrect: Rice 3") || AnimatorController_FemaleAsian01.GetCurrentAnimatorStateInfo(0).IsName("Incorrect: Shirt 3"))
        {

            // *** Audio ***
            if (AnimatorController_FemaleAsian01.GetCurrentAnimatorStateInfo(0).normalizedTime <= 0.14)
            {
                stopAudioCharacter();
                audio_iDontWant_normal.Play();
            }

            // **** Info Bubble ****
            deactivateInfoBubbles();
        }





        // ***** Phase 4 *****

        // **** General ****
        if (AnimatorController_FemaleAsian01.GetCurrentAnimatorStateInfo(0).IsName("Phase 4"))
        {
            AnimatorController_FemaleAsian01.SetBool("Phase Completed", false);

            // **** Info Bubble ****
            deactivateInfoBubbles();
            infoBubble_phase4.SetActive(true);

            // **** Objects ****
            water4.SetActive(true);
            book4.SetActive(true);
            rice4.SetActive(true);
            shirt4.SetActive(true);
        }

        // **** Water ****
        if (AnimatorController_FemaleAsian01.GetCurrentAnimatorStateInfo(0).IsName("Asking: Water 4"))
        {

            // *** Audio ***
            if (AnimatorController_FemaleAsian01.GetCurrentAnimatorStateInfo(0).normalizedTime <= 0.14)
            {
                audio_askingForWater_normalSlow.Play();
            }

        }

        // **** Book ****
        if (AnimatorController_FemaleAsian01.GetCurrentAnimatorStateInfo(0).IsName("Asking: Book 4"))
        {
            deactivateInfoBubbles();

            // *** Audio ***
            if (AnimatorController_FemaleAsian01.GetCurrentAnimatorStateInfo(0).normalizedTime <= 0.14)
            {
                audio_askingForBook_normalSlow.Play();
            }

        }

        // **** Rice ****
        if (AnimatorController_FemaleAsian01.GetCurrentAnimatorStateInfo(0).IsName("Asking: Rice 4"))
        {

            // *** Audio ***
            if (AnimatorController_FemaleAsian01.GetCurrentAnimatorStateInfo(0).normalizedTime <= 0.14)
            {
                audio_askingForRice_normalSlow.Play();
            }

        }

        // **** Shirt ****
        if (AnimatorController_FemaleAsian01.GetCurrentAnimatorStateInfo(0).IsName("Asking: Shirt 4"))
        {

            // *** Audio ***
            if (AnimatorController_FemaleAsian01.GetCurrentAnimatorStateInfo(0).normalizedTime <= 0.14)
            {
                audio_askingForShirt_normalSlow.Play();
            }
        }

        // **** Correct ****
        if (AnimatorController_FemaleAsian01.GetCurrentAnimatorStateInfo(0).IsName("Correct: Water 4") || AnimatorController_FemaleAsian01.GetCurrentAnimatorStateInfo(0).IsName("Correct: Book 4") || AnimatorController_FemaleAsian01.GetCurrentAnimatorStateInfo(0).IsName("Correct: Rice 4") || AnimatorController_FemaleAsian01.GetCurrentAnimatorStateInfo(0).IsName("Correct: Shirt 4"))
        {

            // *** Audio ***
            if (AnimatorController_FemaleAsian01.GetCurrentAnimatorStateInfo(0).normalizedTime <= 0.14)
            {
                stopAudioCharacter();
                audio_thankYou_normal.Play();
            }

        }

        // **** Incorrect ****
        if (AnimatorController_FemaleAsian01.GetCurrentAnimatorStateInfo(0).IsName("Incorrect: Water 4") || AnimatorController_FemaleAsian01.GetCurrentAnimatorStateInfo(0).IsName("Incorrect: Book 4") || AnimatorController_FemaleAsian01.GetCurrentAnimatorStateInfo(0).IsName("Incorrect: Rice 4") || AnimatorController_FemaleAsian01.GetCurrentAnimatorStateInfo(0).IsName("Incorrect: Shirt 4"))
        {

            // *** Audio ***
            if (AnimatorController_FemaleAsian01.GetCurrentAnimatorStateInfo(0).normalizedTime <= 0.14)
            {
                stopAudioCharacter();
                audio_iDontWant_normal.Play();
            }
        }


        // ***** Program Complted *****
        if (AnimatorController_FemaleAsian01.GetCurrentAnimatorStateInfo(0).IsName("Program Completed"))
        {
            ui_programCompleted.SetActive(true);
        }
    }


    private void deactivateInfoBubbles()
    {
        infoBubble_phase1.SetActive(false);
        infoBubble_phase2.SetActive(false);
        infoBubble_phase3.SetActive(false);
        infoBubble_phase4.SetActive(false);

        infoBubble_hello_translation.SetActive(false);
        infoBubble_thankYou_translation.SetActive(false);
        infoBubble_iDontWant_translation.SetActive(false);
        infoBubble_thankYou.SetActive(false);
        infoBubble_iDontWant.SetActive(false);

        infoBubble_iWantWater_translation.SetActive(false);
        infoBubble_iWantBook_translation.SetActive(false);
        infoBubble_iWantRice_translation.SetActive(false);
        infoBubble_iWantShirt_translation.SetActive(false);

        infoBubble_iWantWater.SetActive(false);
        infoBubble_iWantBook.SetActive(false);
        infoBubble_iWantRice.SetActive(false);
        infoBubble_iWantShirt.SetActive(false);
    }

    private void stopAudioCharacter()
    {
        audio_askingForWater_normalSlow.Stop();
        audio_askingForWater_normal.Stop();
        audio_askingForBook_normalSlow.Stop();
        audio_askingForBook_normal.Stop();
        audio_askingForRice_normalSlow.Stop();
        audio_askingForRice_normal.Stop();
        audio_askingForShirt_normalSlow.Stop();
        audio_askingForShirt_normal.Stop();
        audio_iDontWant_normal.Stop();
    }

}
