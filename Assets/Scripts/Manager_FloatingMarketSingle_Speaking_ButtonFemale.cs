using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager_FloatingMarketSingle_Speaking_ButtonFemale : MonoBehaviour
{
    [SerializeField] private Animator animationController_FloatingMarketSpeaking;


    public GameObject dictionary_male_water_soundTextTranslation;
    public GameObject dictionary_male_water_soundText;
    public GameObject dictionary_male_water_sound;
    public GameObject dictionary_male_book_soundTextTranslation;
    public GameObject dictionary_male_book_soundText;
    public GameObject dictionary_male_book_sound;
    public GameObject dictionary_male_rice_soundTextTranslation;
    public GameObject dictionary_male_rice_soundText;
    public GameObject dictionary_male_rice_sound;
    public GameObject dictionary_male_shirt_soundTextTranslation;
    public GameObject dictionary_male_shirt_soundText;
    public GameObject dictionary_male_shirt_sound;

    public GameObject dictionary_female_water_soundTextTranslation;
    public GameObject dictionary_female_water_soundText;
    public GameObject dictionary_female_water_sound;
    public GameObject dictionary_female_book_soundTextTranslation;
    public GameObject dictionary_female_book_soundText;
    public GameObject dictionary_female_book_sound;
    public GameObject dictionary_female_rice_soundTextTranslation;
    public GameObject dictionary_female_rice_soundText;
    public GameObject dictionary_female_rice_sound;
    public GameObject dictionary_female_shirt_soundTextTranslation;
    public GameObject dictionary_female_shirt_soundText;
    public GameObject dictionary_female_shirt_sound;

    

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(animationController_FloatingMarketSpeaking.GetCurrentAnimatorStateInfo(0).IsName("Phase 1"))
        {
            deactivatePhase2Dictionaries();
            deactivatePhase3Dictionaries();
        }
        if (animationController_FloatingMarketSpeaking.GetCurrentAnimatorStateInfo(0).IsName("Phase 2"))
        {
            deactivatePhase1Dictionaries();
            deactivatePhase3Dictionaries();
        }
        if (animationController_FloatingMarketSpeaking.GetCurrentAnimatorStateInfo(0).IsName("Phase 3"))
        {
            deactivatePhase1Dictionaries();
            deactivatePhase2Dictionaries();
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "RightHand Base Controller" || other.name == "LeftHand Base Controller")
        {
            // ***** Deactivate Male Buttons *****
            dictionary_male_water_soundTextTranslation.SetActive(false);
            dictionary_male_water_soundText.SetActive(false);
            dictionary_male_water_sound.SetActive(false);
            dictionary_male_book_soundTextTranslation.SetActive(false);
            dictionary_male_book_soundText.SetActive(false);
            dictionary_male_book_sound.SetActive(false);
            dictionary_male_rice_soundTextTranslation.SetActive(false);
            dictionary_male_rice_soundText.SetActive(false);
            dictionary_male_rice_sound.SetActive(false);
            dictionary_male_shirt_soundTextTranslation.SetActive(false);
            dictionary_male_shirt_soundText.SetActive(false);
            dictionary_male_shirt_sound.SetActive(false);


            // ***** Phase 1 *****

            if (animationController_FloatingMarketSpeaking.GetCurrentAnimatorStateInfo(0).IsName("Water 1"))
            {
                deactivatePhase1Dictionaries();

                dictionary_female_water_soundTextTranslation.SetActive(true);
            }

            if (animationController_FloatingMarketSpeaking.GetCurrentAnimatorStateInfo(0).IsName("Book 1"))
            {
                deactivatePhase1Dictionaries();

                dictionary_female_book_soundTextTranslation.SetActive(true);


            }

            if (animationController_FloatingMarketSpeaking.GetCurrentAnimatorStateInfo(0).IsName("Rice 1"))
            {
                deactivatePhase1Dictionaries();

                dictionary_female_rice_soundTextTranslation.SetActive(true);

            }

            if (animationController_FloatingMarketSpeaking.GetCurrentAnimatorStateInfo(0).IsName("Shirt 1"))
            {
                deactivatePhase1Dictionaries();

                dictionary_female_shirt_soundTextTranslation.SetActive(true);
            }



            // ***** Phase 2 *****

            if (animationController_FloatingMarketSpeaking.GetCurrentAnimatorStateInfo(0).IsName("Water 2"))
            {
                deactivatePhase2Dictionaries();

                dictionary_female_water_soundText.SetActive(true);
            }

            if (animationController_FloatingMarketSpeaking.GetCurrentAnimatorStateInfo(0).IsName("Book 2"))
            {
                deactivatePhase2Dictionaries();

                dictionary_female_book_soundText.SetActive(true);
            }

            if (animationController_FloatingMarketSpeaking.GetCurrentAnimatorStateInfo(0).IsName("Rice 2"))
            {
                deactivatePhase2Dictionaries();

                dictionary_female_rice_soundText.SetActive(true);
            }

            if (animationController_FloatingMarketSpeaking.GetCurrentAnimatorStateInfo(0).IsName("Shirt 2"))
            {
                deactivatePhase2Dictionaries();

                dictionary_female_shirt_soundText.SetActive(true);
            }


            // ***** Phase 3 *****

            if (animationController_FloatingMarketSpeaking.GetCurrentAnimatorStateInfo(0).IsName("Water 3"))
            {
                deactivatePhase3Dictionaries();

                dictionary_female_water_sound.SetActive(true);
            }

            if (animationController_FloatingMarketSpeaking.GetCurrentAnimatorStateInfo(0).IsName("Book 3"))
            {
                deactivatePhase3Dictionaries();

                dictionary_female_book_sound.SetActive(true);
            }

            if (animationController_FloatingMarketSpeaking.GetCurrentAnimatorStateInfo(0).IsName("Rice 3"))
            {
                deactivatePhase3Dictionaries();

                dictionary_female_rice_sound.SetActive(true);
            }

            if (animationController_FloatingMarketSpeaking.GetCurrentAnimatorStateInfo(0).IsName("Shirt 3"))
            {
                deactivatePhase3Dictionaries();

                dictionary_female_shirt_sound.SetActive(true);
            }

        }
    }




    private void deactivatePhase1Dictionaries()
    {
        dictionary_female_water_soundTextTranslation.SetActive(false);
        dictionary_female_book_soundTextTranslation.SetActive(false);
        dictionary_female_rice_soundTextTranslation.SetActive(false);
        dictionary_female_shirt_soundTextTranslation.SetActive(false);
    }

    private void deactivatePhase2Dictionaries()
    {
        dictionary_female_water_soundText.SetActive(false);
        dictionary_female_book_soundText.SetActive(false);
        dictionary_female_rice_soundText.SetActive(false);
        dictionary_female_shirt_soundText.SetActive(false);
    }

    private void deactivatePhase3Dictionaries()
    {
        dictionary_female_water_sound.SetActive(false);
        dictionary_female_book_sound.SetActive(false);
        dictionary_female_rice_sound.SetActive(false);
        dictionary_female_shirt_sound.SetActive(false);
    }

}
