using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Manager_TempleSingle_Intro : MonoBehaviour
{
    public GameObject uIVocabularySelection;
    public GameObject activationArea;

    public GameObject uiTourGuide_1;
    public GameObject uiTourGuide_2;
    public GameObject uiTourGuide_3;
    public GameObject uiTourGuide_4;

    public AudioSource audioIntroduction;

    [SerializeField] private Animator animationController_02TempleIntro;


    // Start is called before the first frame update
    void Start()
    {
        Invoke("waving", 3);
        Invoke("startDialogue", 5);
    }

    // Update is called once per frame
    void Update()
    {
        if (animationController_02TempleIntro.GetCurrentAnimatorStateInfo(0).IsName("Waiting For Decision"))
        {
            animationController_02TempleIntro.SetBool("Conversation Complete", true);
            deactivateUIs();
            uIVocabularySelection.SetActive(true);
        }



    }

    private void waving()
    {
        animationController_02TempleIntro.Play("Waving");
        
    }

    private void startDialogue()
    {
        animationController_02TempleIntro.Play("Conversation");

        if (animationController_02TempleIntro.GetCurrentAnimatorStateInfo(0).normalizedTime <= 0.5)
        {
            audioIntroduction.Play();
        }

        uiTourGuide_1.SetActive(true);

        Invoke("deactivateUIs", 8);
        Invoke("activateUI2", 8);

        Invoke("deactivateUIs", 20);
        Invoke("activateUI3", 20);

        Invoke("deactivateUIs", 31);
        Invoke("activateUI4", 31);

        Invoke("deactivateUIs", 41);
    }
    
    private void deactivateUIs()
    {
        uiTourGuide_1.SetActive(false);
        uiTourGuide_2.SetActive(false);
        uiTourGuide_3.SetActive(false);
        uiTourGuide_4.SetActive(false);
    }

    private void activateUI2()
    {
        uiTourGuide_2.SetActive(true);
    }
    private void activateUI3()
    {
        uiTourGuide_3.SetActive(true);
    }
    private void activateUI4()
    {
        uiTourGuide_4.SetActive(true);
    }
}
