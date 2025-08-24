using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager_FrontDesk : MonoBehaviour
{

    public AudioSource audio_hello_woman;
    public AudioSource audio_hello_man;
    public AudioSource audio_introduction;

    public float timeUntilPlayIntroductionAudio;


    // Variable for the animation controller of the female Asian customer character in scene 
    [SerializeField] private Animator animationController_FrontDesk_Woman;
    [SerializeField] private Animator animationController_FrontDesk_Man;

    // Start is called before the first frame update
    void Start()
    {
        animationWomanIdle();
        animationManIdle();

        Invoke("animationWomanWave", 2);
        Invoke("animationManWave", 4);

        Invoke("playIntroduction", timeUntilPlayIntroductionAudio);
    }

    // Update is called once per frame
    void Update()
    {
        if (animationController_FrontDesk_Woman.GetCurrentAnimatorStateInfo(0).IsName("Greeting"))
        {
            if (animationController_FrontDesk_Woman.GetCurrentAnimatorStateInfo(0).normalizedTime <= 0.1)
            {
                audio_hello_woman.Play();
            }
        }

        if (animationController_FrontDesk_Man.GetCurrentAnimatorStateInfo(0).IsName("Greeting"))
        {
            if (animationController_FrontDesk_Man.GetCurrentAnimatorStateInfo(0).normalizedTime <= 0.1)
            {
                audio_hello_man.Play();
            }
        }

    }

    private void animationWomanIdle()
    {
        animationController_FrontDesk_Woman.Play("Idle01");
    }


    private void animationManIdle()
    {
        animationController_FrontDesk_Woman.Play("Idle01");
    }


    private void animationWomanWave()
    {
        animationController_FrontDesk_Woman.Play("Greeting");
    }

    private void animationManWave()
    {
        animationController_FrontDesk_Man.Play("Greeting");
    }

    private void playIntroduction()
    {
        audio_introduction.Play();
    }

}
