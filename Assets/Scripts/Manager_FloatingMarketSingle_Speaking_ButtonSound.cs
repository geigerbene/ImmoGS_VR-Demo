using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager_FloatingMarketSingle_Speaking_ButtonSound : MonoBehaviour
{
    // ***** Variables: Buttones *****
    public GameObject audioButtonBase;
    public GameObject audioButtonPress;
    public GameObject audioButtonCollider;

    // ***** Variables: Dictionary UI *****
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


    // ***** Variables: Audio Files *****
    public AudioSource male_water_sound;
    public AudioSource male_book_sound;
    public AudioSource male_rice_sound;
    public AudioSource male_shirt_sound;    
    
    public AudioSource female_water_sound;
    public AudioSource female_book_sound;
    public AudioSource female_rice_sound;
    public AudioSource female_shirt_sound;


    [SerializeField] private Animator animationController_FloatingMarketSpeaking;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Deactivate the open dictionary (for the previous voacbulary) when a new vocabulary is asked
        if (animationController_FloatingMarketSpeaking.IsInTransition(0))
        {
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

            dictionary_female_water_soundTextTranslation.SetActive(false);
            dictionary_female_water_soundText.SetActive(false);
            dictionary_female_water_sound.SetActive(false);

            dictionary_female_book_soundTextTranslation.SetActive(false);
            dictionary_female_book_soundText.SetActive(false);
            dictionary_female_book_sound.SetActive(false);

            dictionary_female_rice_soundTextTranslation.SetActive(false);
            dictionary_female_rice_soundText.SetActive(false);
            dictionary_female_rice_sound.SetActive(false);

            dictionary_female_shirt_soundTextTranslation.SetActive(false);
            dictionary_female_shirt_soundText.SetActive(false);
            dictionary_female_shirt_sound.SetActive(false);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "RightHand Base Controller" || other.name == "LeftHand Base Controller")
        {
            stopAudio();

            // ***** Male *****

            // **** Water ****
            if (dictionary_male_water_soundTextTranslation.activeSelf || dictionary_male_water_soundText.activeSelf || dictionary_male_water_sound.activeSelf)
            {
                male_water_sound.Play();
            }

            // **** Book ****
            if (dictionary_male_book_soundTextTranslation.activeSelf || dictionary_male_book_soundText.activeSelf || dictionary_male_book_sound.activeSelf)
            {
                male_book_sound.Play();
            }

            // **** Rice ****
            if (dictionary_male_rice_soundTextTranslation.activeSelf || dictionary_male_rice_soundText.activeSelf || dictionary_male_rice_sound.activeSelf)
            {
                male_rice_sound.Play();
            }

            // **** Shirt ****
            if (dictionary_male_shirt_soundTextTranslation.activeSelf || dictionary_male_shirt_soundText.activeSelf || dictionary_male_shirt_sound.activeSelf)
            {
                male_shirt_sound.Play();
            }


            // ***** Female *****

            // **** Water ****
            if (dictionary_female_water_soundTextTranslation.activeSelf || dictionary_female_water_soundText.activeSelf || dictionary_female_water_sound.activeSelf)
            {
                female_water_sound.Play();
            }

            // **** Book ****
            if (dictionary_female_book_soundTextTranslation.activeSelf || dictionary_female_book_soundText.activeSelf || dictionary_female_book_sound.activeSelf)
            {
                female_book_sound.Play();
            }

            // **** Rice ****
            if (dictionary_female_rice_soundTextTranslation.activeSelf || dictionary_female_rice_soundText.activeSelf || dictionary_female_rice_sound.activeSelf)
            {
                female_rice_sound.Play();
            }

            // **** Shirt ****
            if (dictionary_female_shirt_soundTextTranslation.activeSelf || dictionary_female_shirt_soundText.activeSelf || dictionary_female_shirt_sound.activeSelf)
            {
                female_shirt_sound.Play();
            }
        }
    }


    private void stopAudio()
    {
        male_water_sound.Stop();
        male_book_sound.Stop();
        male_rice_sound.Stop();
        male_shirt_sound.Stop();
        female_water_sound.Stop();
        female_book_sound.Stop();
        female_rice_sound.Stop();
        female_shirt_sound.Stop();
    }


}
